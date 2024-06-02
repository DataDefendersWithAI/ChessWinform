using Chess;
using ChessAI_Bck;
using FireSharp.Config;
using FireSharp.Interfaces;
using Stockfish.NET;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using winforms_chat;
using System.Security.Cryptography;
using winform_chat;


namespace ChessAI
{
    public partial class ChessAIClient : Form
    {
        //Firebase config
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RZxEKkX6ffq8XZgw9p0jbPYhqLYXQOeH1FIcmGIa",
            BasePath = "https://chess-database-a25f7-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient Client;

        // Current username:

        //public string current_username { get; set; }

        private BoardRenderer boardRenderer;
        private ChessBoard chessBoard;
        public PieceColor Side;
        private PieceColor presetSide;

        private TimeSpan timeOur;
        private TimeSpan timeOpponent;
        private bool isTimeoutEndGame = false;

        private int timeIncrement = 0; // Time increment in seconds

        private float initialDpi = 96f; // 100% =96  125% = 120, 150% = 144, 175% = 168, 200% = 192
        private float currentScale = 1.0f; // Current scale of the form
        private string timeControl; // time control

        private string PgnReview; // PGN for reviewing the game

        private bool gameStarted;
        private bool isDebug;
        private bool isOffline; // Playing offline with bots/ AI
        private bool isReview; // Reviewing the game
        private int currentMoveIndex = 0;

        private string reasonEndGame = "Checkmate";

        public PromotionType selectedPromotion;

        ChatMainForm currenChatMainForm;

        string chessLastMove; // prevent sending too much when clicking on the board

        // Random player name
        private User playerUser;
        private User opponentUser;
        // Stockfish module
        private IStockfish Stockfish { get; set; }

        /// <summary>
        /// Handle the sync time when msg is sent
        /// </summary>
        public void timeSyncSend()
        {
            try
            {
                string timeSyncStr = Side == PieceColor.White ? timeOur.TotalSeconds + "|" + timeOpponent.TotalSeconds : timeOpponent.TotalSeconds + "|" + timeOur.TotalSeconds;
                if (currenChatMainForm != null)
                {
                    currenChatMainForm.timeSyncSendHandler(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.TimeSync) + timeSyncStr); // sync display time
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in timeSyncStr: " + e.Message);
                return;
            }
        }

        public ChessAIClient(int modeDepth = 1, string timeCtrl = "10|0", bool isOffl = false, bool DebugMode = false, PieceColor setSide = null, User pUser = null, User oUser = null, ChatMainForm chatMainForm = null, bool setUpGame = true, bool isRvw = false)
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            panel1, new object[] { true });   // Double buffer the panel prevent it from flickering

            isDebug = DebugMode; // Set the debug mode 

            currentScale = initialDpi / this.DeviceDpi; // Get the current scale of the form

            //  this.Width = (int)(this.Width * currentScale); // Scale the width
            this.Height = (int)(this.Height * currentScale); // Scale the height
            // panel1.Size = new System.Drawing.Size((int)Math.Floor(this.Size.Height - 100 * currentScale) , (int)Math.Floor(this.Size.Height - 100 * currentScale));

            this.MaximizeBox = false; // Prevent maximizing the window
            this.MinimizeBox = false; // Prevent minimizing the window
            if (!setUpGame) return; // Prevent setting up the game when the form is loaded for the first time
            SetupGame(modeDepth: modeDepth, timeCtrl: timeCtrl, isOffl: isOffl, setSide: setSide, pUser: pUser, oUser: oUser, chatMainForm: chatMainForm, isRvw: isRvw);
        }

        public void SetupGame(int modeDepth = 1, string timeCtrl = "10|0", bool isOffl = false, PieceColor setSide = null, PieceColor side = null, User pUser = null, User oUser = null, ChatMainForm chatMainForm = null, bool isRvw = false)
        {
            currenChatMainForm = chatMainForm;

            isReview = isRvw;
            isOffline = isOffl; // Set the offline mode
            gameStarted = false; // Set the game started 
            Side = side; // Set the side
            presetSide = setSide; // Set the preset side // Offline only
            isOffline = isOffl;
            timeControl = timeCtrl; // Set the time control

            if (currenChatMainForm == null)
            {
                isOffline = true;
                Debug.WriteLine("Offline mode enabled due to found no ChatMainForm");
            }

            //Create new board tha exist through the game
            chessBoard = new ChessBoard() { AutoEndgameRules = AutoEndgameRules.All }; // Init new board
            chessBoard.OnPromotePawn += PromotePawn; // Add event when pawn is promoted
            chessBoard.OnEndGame += GameEnded; // Add event when game is ended
            // create a renderer
            boardRenderer = new BoardRenderer(); // Init new renderer

            // Hide some unessesary things
            WLouterPanel.Visible = false;
            AgainBtn.Visible = false;
            HomeBtn.Visible = false;
            DrawAsk.Visible = false;
            RestartAsk.Visible = false;

            lastRev.Visible = false;
            nextRev.Visible = false;
            playRev.Visible = false;

            //Set name player:
            if (pUser != null)
            {
                playerUser = pUser;
            }
            else
            {
                playerUser = new User(username: "You", elo: 404);
            }

            if (oUser != null)
            {
                opponentUser = oUser;
            }
            else
            {
                opponentUser = new User(username: "Opponent", elo: 404);
            }

            if (isDebug == false)
            {
                OppMoveButton.Visible = false; // Hide the debug button
                OfflineButton.Visible = false; // Hide the offline button
                cntSvr.Visible = false; // Hide the server button
                richTextBox2.Visible = false; // Hide the log
            }

            if (isOffline && !isReview) // if player playing Offline
            {
                //Generate stockfish default
                var pathStockFish = GetStockfishDir();
                Stockfish = new Stockfish.NET.Stockfish(pathStockFish, modeDepth);
                Stockfish.SkillLevel = 0;
                // Set the side randomly or preset
                Side = presetSide != null ? presetSide : Random.Shared.Next(2) == 0 ? PieceColor.White : PieceColor.Black;
                opponentUser = new User(username: "AI", elo: 1);
            }

            if (isReview) // if player reviewing the game
            {
                Side = presetSide;
                resignBtn.Visible = false;
                drawBtn.Visible = false;
                lastRev.Visible = true;
                nextRev.Visible = true;
                playRev.Visible = true;
            }

            InitGame();

        }
        /// <summary>
        /// Begin the game when the message is received/ Connected to another player
        /// </summary>
        /// <param name="message"></param>
        private void InitGame()
        {

            if (gameStarted) return; // If game already started, return

            new SoundFXHandler(chessBoard, "", "start"); // start game sound
            if (!isReview)
            {
                resignBtn.Visible = true;
                drawBtn.Visible = true;
            }
            // Set the game started
            gameStarted = true;
            if (Side == PieceColor.Black && isOffline && !isReview)
            {
                OpponentAIMove(); // first move for AI white
            }

            LogMessage("Game started! You are: " + Side);
            panel1.Invalidate(); // Redraw whole board
            timeControlInitialize();
            InitUserInfo();
            Invalidate();
        }

        /// <summary>
        /// Handle the end game
        /// </summary>
        private void GameEnded(object sender, EndgameEventArgs e)
        {
            // Hide components on end game
            flowLayoutPanel1.Visible = false;
            resignBtn.Visible = false;
            drawBtn.Visible = false;
            //
            timer1.Stop();
            new SoundFXHandler(chessBoard, "", "end"); // end game sound
            //
            if (chessBoard.EndGame.WonSide == Side) // won
            {
                if (chessBoard.EndGame.EndgameType == EndgameType.Checkmate) { reasonEndGame = playerUser.Username + " checkmated " + opponentUser.Username + " king! "; }
                if (chessBoard.EndGame.EndgameType == EndgameType.Resigned && !isTimeoutEndGame) { reasonEndGame = opponentUser.Username + " resigned!"; }
                if (chessBoard.EndGame.EndgameType == EndgameType.Resigned && isTimeoutEndGame) { reasonEndGame = opponentUser + " timeout!"; }
            }
            if (chessBoard.EndGame.WonSide == Side.OppositeColor()) // lose
            {
                if (chessBoard.EndGame.EndgameType == EndgameType.Checkmate) { reasonEndGame = opponentUser.Username + " checkmate " + playerUser.Username + " king! "; }
                if (chessBoard.EndGame.EndgameType == EndgameType.Resigned && !isTimeoutEndGame) { reasonEndGame = playerUser.Username + " resigned!"; }
                if (chessBoard.EndGame.EndgameType == EndgameType.Resigned && isTimeoutEndGame) { reasonEndGame = playerUser.Username + " timeout!"; }
            }

            if (chessBoard.EndGame.EndgameType == EndgameType.Stalemate) { reasonEndGame = "Stalemate"; }
            if (chessBoard.EndGame.EndgameType == EndgameType.DrawDeclared) { reasonEndGame = "Draw declared"; }
            if (chessBoard.EndGame.EndgameType == EndgameType.Repetition) { reasonEndGame = "Repetition"; }
            if (chessBoard.EndGame.EndgameType == EndgameType.FiftyMoveRule) { reasonEndGame = "Fifty Move Rule"; }
            if (chessBoard.EndGame.EndgameType == EndgameType.InsufficientMaterial) { reasonEndGame = "Insufficient material"; }


            if (chessBoard.EndGame.WonSide == Side) // won
            {
                WLText.Text = "You won!";
                reasonText.Text = reasonEndGame;
                userPanel.BackColor = System.Drawing.Color.GreenYellow;
                oppPanel.BackColor = System.Drawing.Color.Transparent;
                WLinnerPanel.BackColor = System.Drawing.Color.LightGreen;
                Score01.Text = (Side == PieceColor.White ? "1 : 0" : "0 : 1");
                uELO.Text = "ELO: " + playerUser.ELO + " +15";
                if (isOffline) uELO.Text = "ELO: " + playerUser.ELO + " +0";
            }
            else if (chessBoard.EndGame.WonSide == Side.OppositeColor()) // lose
            {
                WLText.Text = "You lose!";
                reasonText.Text = reasonEndGame;
                userPanel.BackColor = System.Drawing.Color.Transparent;
                oppPanel.BackColor = System.Drawing.Color.GreenYellow;
                WLinnerPanel.BackColor = System.Drawing.Color.LightCoral;
                Score01.Text = (Side == PieceColor.White ? "0 : 1" : "1 : 0");
                uELO.Text = "ELO:" + playerUser.ELO + " -15";
                if (isOffline) uELO.Text = "ELO:" + playerUser.ELO + " -0";
            }
            else // draw
            {
                WLText.Text = "Draw!";
                reasonText.Text = reasonEndGame;
                userPanel.BackColor = System.Drawing.Color.Transparent;
                oppPanel.BackColor = System.Drawing.Color.Transparent;
                WLinnerPanel.BackColor = System.Drawing.Color.LightGray;
                Score01.Text = "1/2 : 1/2";
                uELO.Text = "ELO:" + playerUser.ELO + " -0";
            }
            Parallel.Invoke(() => ShowPanelWithDelay(), () => SaveToDatabase());
        }

        private async void SaveToDatabase()
        {
            if (isReview) return; // if reviewing the game, return
            if (!playerUser.IsAValidUser()) return; // if user is not valid, return

            try
            {
                Client = new FireSharp.FirebaseClient(config);
                if (Client != null)
                {
                    var current_username = playerUser.Username;
                    if (current_username == null) return;

                    var load_user = await Client.GetAsync("Users/" + EncodeSha256(current_username));
                    User Getuser = load_user.ResultAs<User>();

                    if (Getuser == null)
                    {
                        Debug.WriteLine("Error: User not found in the database.");
                        return;
                    }

                    var match_id = Guid.NewGuid().ToString();
                    var pgn = chessBoard.ToPgn();
                    var save_PGN = new PGNLog
                    {
                        ID = match_id,
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),

                        White = (Side == PieceColor.White ? playerUser.Username : opponentUser.Username),
                        Black = (Side == PieceColor.Black ? playerUser.Username : opponentUser.Username),

                        Result = string.IsNullOrEmpty(Score01.Text)
                        ? (pgn.Contains("1-0") ? "1 : 0" : (pgn.Contains("0-1") ? "0 : 1" : "1/2 : 1/2"))
                        : Score01.Text,


                        WhiteELO = (Side == PieceColor.White ? playerUser.ELO : opponentUser.ELO),
                        BlackELO = (Side == PieceColor.Black ? playerUser.ELO : opponentUser.ELO),

                        TimeControl = timeControl,
                        Termination = reasonEndGame,
                        PGN = pgn,
                    };

                    Getuser.AddMatch(save_PGN);
                    if (!isOffline)
                    {
                        if (chessBoard.EndGame.WonSide == Side)
                        {
                            Getuser.ELO += 15;
                        }
                        else if (chessBoard.EndGame.WonSide == Side.OppositeColor())
                        {
                            Getuser.ELO -= 15;
                        }
                        else
                        {
                            Getuser.ELO += 0;
                        }
                    }               

                    playerUser = Getuser;
                    // Save the updated user back to the database
                    var save_match = await Client.SetAsync("Users/" + EncodeSha256(current_username), Getuser);
                    if (save_match.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Debug.WriteLine("Match saved successfully.");
                       
                    }
                    else
                    {
                        Debug.WriteLine("Error saving match: " + save_match.StatusCode);
                    }
                }
                else
                {
                    Debug.WriteLine("Firebase client is null.");
                    return;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in SaveToDatabase: " + e.Message);
            }
        }


        private string EncodeSha256(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] inputHashByte = SHA256.Create().ComputeHash(inputBytes);
            string result = BitConverter.ToString(inputHashByte).Replace("-", string.Empty).ToLower();
            return result;
        }
        /// <summary>
        /// Show the end game panel with delay
        /// </summary>
        private async void ShowPanelWithDelay()
        {
            // Add a 2-second delay
            await Task.Delay(2000);

            new SoundFXHandler(chessBoard, "", side: Side); // win or lose sound
            // Make the panel visible after the delay
            WLouterPanel.Visible = true;
            HomeBtn.Visible = true;

            if (isReview) return; // if reviewing the game, return

            AgainBtn.Visible = true;
            WLAgain.Visible = true;

            if (RestartAsk.Visible)
            {
                WLAgain.Visible = false;
                AgainBtn.Visible = false;
                return;
            }

        }

        /// <summary>
        /// Handle the end game when online/ received message
        /// </summary>
        public void EndGameOnline(string message)
        {
            if (isReview) return; // if reviewing the game, return
            if (message == "Resign")
            {
                if (chessBoard.IsEndGame) return; // if game already ended, return; 
                chessBoard.Resign(Side.OppositeColor());
            }
            if (message == "DrawAsk")
            {
                AskingForDraw();
            }
            if (message == "DrawAccept")
            {
                chessBoard.Draw();
            }
            if (message == "DrawDecline")
            {
                DrawAsk.Visible = false;
                drawBtn.Visible = true;
                resignBtn.Visible = true;
            }
            if (message == "Timeout")
            {
                isTimeoutEndGame = true;
                chessBoard.Resign(Side.OppositeColor());
            }
        }

        /// <summary>
        /// Display the asking for draw message
        /// </summary>
        private void AskingForDraw()
        {
            new SoundFXHandler(chessBoard, "", "Offer");
            DrawAsk.Visible = true;
            DrawText.Text = opponentUser.Username + " asking for a draw. Would you accept?";
            drawBtn.Visible = false;
            resignBtn.Visible = false;
        }

        /// <summary>
        /// Handle the restart/rematch game when offline
        /// </summary>
        private void RestartGame()
        {
            if (isReview) return; // if reviewing the game, return
            WLouterPanel.Visible = false;
            AgainBtn.Visible = false;
            HomeBtn.Visible = false;
            if (isOffline)
            {
                Debug.WriteLine("Restarting game...");
                Debug.WriteLine("presetSide: " + presetSide);
                chessBoard.Clear();
                panel1.Invalidate();
                gameStarted = false;
                // Set the side randomly or preset
                Side = presetSide != null ? presetSide : Random.Shared.Next(2) == 0 ? PieceColor.White : PieceColor.Black;
                InitGame();
            }
            else
            {
                if (currenChatMainForm != null)
                {
                    currenChatMainForm.moveSendHandler(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.Rematch) + "RestartAsk");
                }
            }
        }

        /// <summary>
        /// Handle the restart/rematch game when the message is received online
        /// </summary>
        public void RestartGameOnline(string message)
        {
            if (isReview) return; // if reviewing the game, return
            if (message == "RestartAsk")
            {
                new SoundFXHandler(chessBoard, "", "Offer");
                RestartAsk.Visible = true;
                RestartText.Text = opponentUser.Username + " asking for a rematch. Would you accept?";
                AgainBtn.Visible = false;
                WLAgain.Visible = false;
            }
            if (message.Contains("RestartAccept"))
            {
                new SoundFXHandler(chessBoard, "", "accept");
                WLouterPanel.Visible = false;
                AgainBtn.Visible = false;
                HomeBtn.Visible = false;

                var side = message.Split('-')[1];
                Side = side.ToLower().Contains("white") ? PieceColor.White : PieceColor.Black;
                Debug.WriteLine("Restarting game...");
                Debug.WriteLineIf(isDebug, "presetSide: " + presetSide);
                chessBoard.Clear();
                panel1.Invalidate();
                gameStarted = false;
                InitGame();
            }
            if (message == "RestartDecline")
            {
                new SoundFXHandler(chessBoard, "", "decline");
                RestartAsk.Visible = false;
                AgainBtn.Visible = true;
                HomeBtn.Visible = true;
            }
        }

        /// <summary>
        /// Initialize the time control for the game
        /// </summary>
        private void timeControlInitialize()
        {
            if (isReview || timeControl == "none") // No time limit for offline mode
            {
                opponentTimer.Visible = false;
                ourTimer.Visible = false;
                return;
            }

            string[] timeCtrl = timeControl.Split("|");
            if (timeCtrl.Length != 2) return;

            timeIncrement = Convert.ToInt32(timeCtrl[1]);
            if (timeCtrl[0].Contains("s")) // if time is in seconds
            {
                timeCtrl[0] = timeCtrl[0].Replace("s", "");
                timeOur = TimeSpan.FromSeconds(Convert.ToInt32(timeCtrl[0]));
                timeOpponent = TimeSpan.FromSeconds(Convert.ToInt32(timeCtrl[0]));
            }
            else
            {
                timeOur = TimeSpan.FromMinutes(Convert.ToInt32(timeCtrl[0]));
                timeOpponent = TimeSpan.FromMinutes(Convert.ToInt32(timeCtrl[0]));
            }
            opponentTimer.Text = timeOpponent.ToString(@"mm\:ss");
            ourTimer.Text = timeOur.ToString(@"mm\:ss");
            beginTimer();
        }

        /// <summary>
        /// Rescale the board when the form is resized
        /// </summary>
        private void boardResize(object sender, EventArgs e)
        {
            panel1.Invalidate(); // Redraw whole board
        }


        /// <summary>
        /// Redraw the board
        /// </summary>
        /// <param name="message"></param>
        private void boardPaint(object sender, PaintEventArgs e) // Update continuously
        {
            if (!gameStarted) return; // If game not started, return
            boardRenderer.DrawBoard(e.Graphics, chessBoard, panel1.Size.Height, isDebug: isDebug, side: Side); // Draw the board
            richTextBox1.Text = chessBoard.ToPgn(); // Show the moves
            panel1.BackColor = chessBoard.Turn == PieceColor.White ? System.Drawing.Color.Gainsboro : System.Drawing.Color.Gray; // Change the background color
        }

        /// <summary>
        /// Event when the board is clicked
        /// </summary>
        /// <param name="message"></param>
        private void boardClick(object sender, MouseEventArgs e)
        {
            if (!gameStarted) return; // If game not started, return
            Debug.WriteLineIf(isDebug, "X: " + e.X + " Y: " + e.Y);

            chessBoard = boardRenderer.onClicked(new Position(e.X, e.Y), chessBoard, isNormalized: false, side: Side, chessClientUI: this); // Handle the click

            panel1.Invalidate(); // Redraw whole board
            var mv = ChatCommandExt.ToString(ChatCommandExt.ChatCommand.Move) + (chessBoard.MovesToSan.Any() ? chessBoard.MovesToSan.Last() : "none"); //move
            LogMessage(mv);

            if (chessBoard.Turn != Side)
            {
                timeOur = timeOur.Add(TimeSpan.FromSeconds(timeIncrement));
                ourTimer.Text = timeOur.ToString(@"mm\:ss");
                if (isOffline && !isReview)
                {
                    OpponentAIMove();
                }
            }

            //  SendMessage(mv);
            if (currenChatMainForm != null
                && mv != chessLastMove // prevent  spamming the same move
                && mv != (ChatCommandExt.ToString(ChatCommandExt.ChatCommand.Move) + "none") // prevent sending none move
                && chessBoard.Turn != Side  //prevent sending move when it's not our turn // using != because it's end of our turn
                && isOffline == false // prevent sending move when offline
                && isReview == false // prevent sending move when reviewing
                )
            {
                currenChatMainForm.moveSendHandler(mv);
                chessLastMove = mv;
            }

        }

        /// <summary>
        /// Simulate the opponent move/ Offline mode
        /// </summary>
        /// <param name="message"></param>
        private void OpponentMoveButton_Click(object sender, EventArgs e)
        {
            OpponentAIMove();
        }

        public void OpponentAIMove(bool isDum = false)
        {
            //var moves = chessBoard.Moves();
            if (chessBoard.IsEndGame)
            {
                Debug.WriteLine("Game end " + chessBoard.EndGame.WonSide + " won!");
                return;
            }
            Stockfish.SetFenPosition(chessBoard.ToFen());

            Move move;

            if (isDum)
            {
                // Option 1: dumb AI
                var moves = chessBoard.Moves();
                move = moves[Random.Shared.Next(moves.Length)];
            }
            else
            {
                // Option 2: smart AI (StockFish)
                var bestMove = Stockfish.GetBestMove();
                move = new Move(bestMove.Substring(0, 2), bestMove.Substring(2, 2));
            }

            //add sound FX
            new SoundFXHandler(chessBoard, move.NewPosition.ToString(), side: Side.OppositeColor(), isOfflGame: true);
            chessBoard.Move(move);
            //add sound FX
            new SoundFXHandler(chessBoard, "", side: Side.OppositeColor(), isOfflGame: true); // castle?

            timeOpponent = timeOpponent.Add(TimeSpan.FromSeconds(timeIncrement));
            opponentTimer.Text = timeOpponent.ToString(@"mm\:ss");
            panel1.Invalidate();
        }
        /// <summary>
        /// Parsing mesage and moving the piece as other player move receive from server
        /// </summary>
        /// <param name="message"></param>
        public void MoveAsMessage(string message)
        {
            // EX: split e4e5 to e4 e5
            //string Sfrom = message.Substring(0, 2);
            //string Sto = message.Substring(2, 2);

            if (!gameStarted) return; // If game not started, return
            if (chessBoard.Turn == Side) return; // If it's our turn, return
            if (isOffline == true) return; // If it's offline mode, return
            if (isReview) return; // if reviewing the game, return
            if (message == "none") return; // If no move, return

            // Opponent move
            Move move;
            if (!chessBoard.TryParseFromSan(message, out move)) return;
            if (chessBoard.IsEndGame)
            {
                Debug.WriteLine("Game end " + chessBoard.EndGame.WonSide + " won!");
                return;
            }
            new SoundFXHandler(chessBoard, move.NewPosition.ToString(), side: Side.OppositeColor());
            chessBoard.Move(move);
            //add sound FX
            new SoundFXHandler(chessBoard, "", side: Side.OppositeColor()); // castle?

            panel1.Invalidate();
        }


        /// <summary>
        /// Promotion UI for the pawn/ not implemeted yet
        /// </summary>
        /// <param name="message"></param>
        private void PromotePawn(object sender, PromotionEventArgs e)
        {
            e.PromotionResult = selectedPromotion == null ? PromotionType.Default : selectedPromotion;
            new SoundFXHandler(chessBoard, "", "promote");
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            ScaleControls(currentScale);
            if (isOffline) return; // If offline mode, return
            // Do something when form is loaded
            //x = new ChatClientJoin();
            //x.Show();
            //x.JoiningRoom(playerName, this);
            //x.Joined += Room_Joined;
        }

        /// <summary>
        /// Log message for debugging
        /// </summary>
        /// <param name="message"></param>
        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }
            richTextBox2.AppendText(message + "\n");
        }

        /// <summary>
        /// Begin offline game
        /// </summary>
        /// <param name="message"></param>
        private void OfflineButton_Click(object sender, EventArgs e)
        {
            // Set the side randomly
            Side = Random.Shared.Next(2) == 0 ? PieceColor.White : PieceColor.Black;
            isOffline = true;

            opponentUser = new User();
            opponentUser.Username = "AI";
            opponentUser.ELO = 1;

            InitGame();
        }

        public static string GetStockfishDir()
        {
            // Determine the relative path to the Stockfish executable
            string relativePath = "./Stockfish/stockfish_20090216_x64.exe";

            // Determine the full path based on the operating system
            string fullPath;
            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            {
                // Convert relative path to absolute path for Windows
                fullPath = Path.GetFullPath(relativePath);
            }
            else
            {
                // Use a different path for non-Windows OS
                fullPath = "/usr/games/stockfish";
            }

            // Print the determined path
            Debug.WriteLine(fullPath);
            return fullPath;
        }
        private void InitUserInfo()
        {
            // init display
            ourName.Text = playerUser.Username + " ( " + playerUser.ELO + " )";
            opponentName.Text = opponentUser.Username + " ( " + opponentUser.ELO + " )";
            // init end game
            uName1.Text = playerUser.Username;
            uName2.Text = opponentUser.Username;

        }
        private void beginTimer()
        {
            opponentTimer.BackColor = Color.LightGray;
            ourTimer.BackColor = Color.DarkGray;

            timer1.Interval = 1000;
            timer1.Start();
        }

        public void syncTimer(string timeSync)
        {
            try
            {
                if (timeSync == "") return;
                string[] timeLeft = timeSync.Split("|");
                if (timeLeft.Length != 2) return;
                if (Side == PieceColor.White)
                {
                    timeOur = TimeSpan.FromSeconds(Convert.ToInt32(timeLeft[0]));
                    timeOpponent = TimeSpan.FromSeconds(Convert.ToInt32(timeLeft[1]));
                }
                else if (Side == PieceColor.Black)
                {
                    timeOur = TimeSpan.FromSeconds(Convert.ToInt32(timeLeft[1]));
                    timeOpponent = TimeSpan.FromSeconds(Convert.ToInt32(timeLeft[0]));
                }
                ourTimer.Text = timeOur.ToString(@"mm\:ss");
                opponentTimer.Text = timeOpponent.ToString(@"mm\:ss");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in syncTimer: " + e.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                if (chessBoard.Turn == Side)
                {
                    timeOur = timeOur.Subtract(TimeSpan.FromSeconds(1));
                    ourTimer.Text = timeOur.ToString(@"mm\:ss");
                    ourTimer.BackColor = Color.Chartreuse;
                    opponentTimer.BackColor = Color.LightGray;
                    if (timeOur.TotalSeconds <= 30)
                    {
                        new SoundFXHandler(chessBoard, "", "tenSec"); // time sound
                        ourTimer.BackColor = Color.Salmon;
                    }
                    if (timeOur.TotalSeconds <= 0)
                    {
                        timer1.Stop();
                        LogMessage("Your's time is up!");
                        isTimeoutEndGame = true;
                        chessBoard.Resign(Side);

                        if (currenChatMainForm != null)
                        {
                            currenChatMainForm.moveSendHandler(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.EndGame) + "Timeout");
                        }
                    }
                }
                else
                {

                    timeOpponent = timeOpponent.Subtract(TimeSpan.FromSeconds(1));
                    opponentTimer.Text = timeOpponent.ToString(@"mm\:ss");
                    opponentTimer.BackColor = Color.Chartreuse;
                    ourTimer.BackColor = Color.LightGray;
                    if (timeOpponent.TotalSeconds <= 0)
                    {
                        timer1.Stop();
                        LogMessage("Opponent's time is up!");
                        isTimeoutEndGame = true;
                        chessBoard.Resign(Side.OppositeColor());

                    }
                }
            }
        }

        private void cntSvr_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void WLok_Click(object sender, EventArgs e)
        {
            WLouterPanel.Visible = false;
            new SoundFXHandler(null, "", "click");
        }

        private void WLAgain_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void WLHome_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(null, "", "click");
            this.Close();
            this.Dispose();
        }

        private void Again_Click(object sender, EventArgs e)
        {
            RestartGame();

        }

        private void Home_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(null, "", "click");
            this.Close();
            this.Dispose();
        }

        private void drawBtn_Click(object sender, EventArgs e)
        {
            if (isReview) return; // if reviewing the game, return
            if (!gameStarted) return; // If game not started, return
            if (chessBoard.IsEndGame == true) return;
            new SoundFXHandler(chessBoard, "", "drawOffer"); // draw offer sound
            if (isOffline)
            {
                chessBoard.Draw();
            }
            else
            {
                if (currenChatMainForm != null)
                {
                    drawBtn.Visible = false;
                    resignBtn.Visible = false;
                    currenChatMainForm.moveSendHandler(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.EndGame) + "DrawAsk");
                }
            }
        }

        private void resignBtn_Click(object sender, EventArgs e)
        {
            if (isReview) return; // if reviewing the game, return
            if (!gameStarted) return; // If game not started, return
            if (chessBoard.IsEndGame == true) return;
            if (isOffline)
            {
                chessBoard.Resign(Side);
            }
            else
            {
                if (currenChatMainForm != null)
                {
                    currenChatMainForm.moveSendHandler(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.EndGame) + "Resign");
                    chessBoard.Resign(Side);
                }
            }
        }

        private void DrawY_Click(object sender, EventArgs e)
        {
            DrawAsk.Visible = false;
            chessBoard.Draw();
            if (currenChatMainForm != null)
            {
                new SoundFXHandler(chessBoard, "", "accept"); //accept sound
                currenChatMainForm.moveSendHandler(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.EndGame) + "DrawAccept");

            }
        }

        private void DrawN_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(chessBoard, "", "decline"); // decline sound
            DrawAsk.Visible = false;
            drawBtn.Visible = true;
            resignBtn.Visible = true;
            if (currenChatMainForm != null)
            {
                currenChatMainForm.moveSendHandler(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.EndGame) + "DrawDecline");
            }
        }

        private void ResY_Click(object sender, EventArgs e)
        {
            RestartAsk.Visible = false;
            if (currenChatMainForm != null)
            {
                new SoundFXHandler(chessBoard, "", "accept"); // accept sound
                Side = Random.Shared.Next(2) == 0 ? PieceColor.White : PieceColor.Black;
                currenChatMainForm.moveSendHandler(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.Rematch) + "RestartAccept-" + Side.OppositeColor());
                RestartGameOnline(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.Rematch) + "RestartAccept-" + Side);
            }
        }

        private void ResN_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(chessBoard, "", "decline"); //accept sound
            RestartAsk.Visible = false;
            AgainBtn.Visible = true;
            HomeBtn.Visible = true;
            if (currenChatMainForm != null)
            {
                currenChatMainForm.moveSendHandler(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.Rematch) + "RestartDecline");
            }
        }

        private void ClientForm_Closed(object sender, FormClosingEventArgs e)
        {
            if (isOffline || isReview)
            {
                // Close the stockfish process?

            }
            else
            {
                if (currenChatMainForm != null)
                {
                    currenChatMainForm.moveSendHandler(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.EndGame) + "Resign");
                    if (chessBoard.IsEndGame) return; // if game already ended, return; 
                    chessBoard.Resign(Side);
                }
            }
        }

        private void ScaleControls(float scale)
        {
            //rescale the panel1
            var oldPanel1_Width = panel1.Width;
            panel1.Size = new System.Drawing.Size((int)Math.Floor(this.Size.Height - 100 * scale), (int)Math.Floor(this.Size.Height - 100 * scale));
            var deltaWidth = Math.Abs(panel1.Width - oldPanel1_Width);
            //this.Width = (int)(this.Width + deltaWidth); // Scale the width
            WLouterPanel.Left = (int)(WLouterPanel.Left + deltaWidth);

            foreach (Control control in this.Controls)
            {
                ///  Debug.WriteLine(control.Name);
                if (control.Name == "panel1") continue;
                ScaleControl(control, deltaWidth, true, scale);
            }
            foreach (Control childControl in panel1.Controls)
            {
                ScaleControl(childControl, deltaWidth, true, scale);
            }
        }
        private void ScaleControl(Control control, int deltaWidth, bool usingDelta, float scale)
        {
            control.Left = usingDelta ? (int)(control.Left + deltaWidth) : (int)(control.Left * scale);
            control.Width = (int)(control.Width * scale);
            control.Height = (int)(control.Height * scale);
            control.Top = (int)(control.Top * currentScale);
            control.Font = new System.Drawing.Font(control.Font.FontFamily, control.Font.Size * scale);

            foreach (Control childControl in control.Controls)
            {
                ScaleControl(childControl, deltaWidth, false, scale);
            }
        }

        public void LoadBoardFromPgn(string pgn)
        {
            //clear old chess board
            PgnReview = pgn;
            chessBoard.Clear();
            currentMoveIndex = 0;
            chessBoard = ChessBoard.LoadFromPgn(pgn);
            panel1.Invalidate();

        }


        private void nextRev_Click(object sender, EventArgs e)
        {
               
                //chessBoard.Next();

                panel1.Invalidate();
            
        }

        private void lastRev_Click(object sender, EventArgs e)
        {
                //chessBoard.Previous();
                panel1.Invalidate();
        }

        private void playRev_Click(object sender, EventArgs e)
        {
            // Auto continue the game as the pgn
            for (int i = currentMoveIndex; i < chessBoard.MovesToSan.Count; i++)
            {
                //chessBoard.Next();
                //panel1.Invalidate();
                nextRev_Click(sender, e);
                Thread.Sleep(1000);
            }
        }
    }
}
