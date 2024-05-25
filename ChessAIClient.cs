using Ardalis.SmartEnum.Core;
using Chess;
using ChessAI;
using Stockfish.NET;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using winforms_chat;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace ChessAI
{
    public partial class ChessAIClient : Form
    {
        private BoardRenderer boardRenderer;
        private ChessBoard chessBoard;
        private PieceColor Side;

        private TimeSpan timeOur;
        private TimeSpan timeOpponent;

        private int timeIncrement = 0; // Time increment in seconds

        private bool gameStarted = false;
        private bool isDebug = false;
        private bool isOffline = false; // Playing offline with bots/ AI

        private PromotionType selectedPromotion;
        ChatClientJoin x;
        ChatMainForm currenChatMainForm;
        string chessLastMove; // prevent sending too much when clicking on the board

        // Random player name
        private string PlayerName = "Player" + new Random().Next(1000, 24000);
        // Random player number in range 1-2000
        private int PlayerNumber = new Random().Next(1, 2000);
        // Stockfish module
        private IStockfish Stockfish { get; set; }

        public ChessAIClient(int modeDepth = 1, bool isDebug = true)
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null,
           panel1, new object[] { true });   // Double buffer the panel prevent it from flickering

            chessBoard = new ChessBoard() { AutoEndgameRules = AutoEndgameRules.All }; // Init new board
            chessBoard.OnPromotePawn += PromotePawn; // Add event when pawn is promoted
            boardRenderer = new BoardRenderer(); // Init new renderer

            this.Size = new System.Drawing.Size(1300, 750); // Add minimum offset is 75 and maybe some space
                                                            // this.FormClosed += ClientForm_FormClosed; // Add event when form is closed
                                                            // panel1.Size = new System.Drawing.Size(this.Size.Height - 100 , this.Size.Height - 100 ); // Set the panel size
            panel1.Size = new System.Drawing.Size(650, 650);

            this.MaximizeBox = false; // Prevent maximizing the window
            this.MinimizeBox = false; // Prevent minimizing the window

            if (isDebug == false)
            {
                OppMoveButton.Visible = false; // Hide the debug button
                OfflineButton.Visible = false; // Hide the offline button
                cntSvr.Visible = false; // Hide the server button
                richTextBox2.Visible = false; // Hide the log
            }

            //Generate stockfish default
            var pathStockFish = GetStockfishDir();
            Stockfish = new Stockfish.NET.Stockfish(pathStockFish, modeDepth);
        }

        /// <summary>
        /// Begin the game when the message is received/ Connected to another player
        /// </summary>
        /// <param name="message"></param>
        private void InitGame(PieceColor side, string timeCtrl, bool isOffl = true)
        {
            if (gameStarted) return; // If game already started, return
            // Set the side
            Side = side;
            // isOflineMode
            isOffline = isOffl;
            // Set the game started
            gameStarted = true;
            LogMessage("Game started! You are: " + Side);
            panel1.Invalidate(); // Redraw whole board
            timeControlInitialize(timeCtrl);
            InitUserInfo();
        }

        private void timeControlInitialize(string timeControl)
        {
            string[] timeCtrl = timeControl.Split("|");
            if(timeCtrl.Length != 2) return;
            int timeToComplete = Convert.ToInt32(timeCtrl[0]);
            timeIncrement = Convert.ToInt32(timeCtrl[1]);
            timeOur = TimeSpan.FromMinutes(timeToComplete);
            timeOpponent = TimeSpan.FromMinutes(timeToComplete);
            opponentTimer.Text = timeOpponent.ToString(@"mm\:ss");
            ourTimer.Text = timeOur.ToString(@"mm\:ss");
        }

        private void boardResize(object sender, EventArgs e)
        {
            panel1.Size = new System.Drawing.Size(650, 650); //this.Size.Height - 100, this.Size.Height - 100); // Set the panel size
            panel1.Invalidate(); // Redraw whole board
            this.Size = new System.Drawing.Size(1300, 750); // Add minimum offset is 75 and maybe some space
                                                            // this.FormClosed += ClientForm_FormClosed; // Add event when form is closed
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
        }

        /// <summary>
        /// Event when the board is clicked
        /// </summary>
        /// <param name="message"></param>
        private void boardClick(object sender, MouseEventArgs e)
        {
            if (!gameStarted) return; // If game not started, return
            Debug.WriteLineIf(isDebug, "X: " + e.X + " Y: " + e.Y);
            chessBoard = boardRenderer.onClicked(new Position(e.X, e.Y), chessBoard, isNormalized: false, side: Side); // Handle the click

            panel1.Invalidate(); // Redraw whole board
            var mv = "MV#*" + (chessBoard.MovesToSan.Any() ? chessBoard.MovesToSan.Last() : "none"); //move
            LogMessage(mv);
            //  SendMessage(mv);
            if (currenChatMainForm != null
                && mv != chessLastMove // prevent  spamming the same move
                && mv != "MV#*none" // prevent sending none move
                && chessBoard.Turn != Side  //prevent sending move when it's not our turn // using != because it's end of our turn
                && isOffline == false // prevent sending move when offline
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
            if (!gameStarted) return; // If game not started, return
            if (chessBoard.Turn == Side) return; // Simulate opponent when offline
            if (isOffline == false) return; // If it's not offline mode, return
            //var moves = chessBoard.Moves();
            if (chessBoard.IsEndGame)
            {
                Debug.WriteLine("Game end " + chessBoard.EndGame.WonSide + " won!");
                return;
            }
            Stockfish.SetFenPosition(chessBoard.ToFen());
            var bestMove = Stockfish.GetBestMove();
            var move = new Move(bestMove.Substring(0, 2), bestMove.Substring(2, 2));
            //chessBoard.Move(moves[Random.Shared.Next(moves.Length)]);
            chessBoard.Move(move);
            panel1.Invalidate();
        }

        /// <summary>
        /// Parsing mesage and moving the piece as other player move receive from server
        /// </summary>
        /// <param name="message"></param>
        public void MoveAsMessage(string message)
        {
            message = message.Replace("MV#*", ""); //Normalize message as SAN
            // EX: split e4e5 to e4 e5
            //string Sfrom = message.Substring(0, 2);
            //string Sto = message.Substring(2, 2);

            if (!gameStarted) return; // If game not started, return
            if (chessBoard.Turn == Side) return; // If it's our turn, return
            if (isOffline == true) return; // If it's offline mode, return
            if (message == "none") return; // If no move, return

            // Opponent move
            Move move;
            if (!chessBoard.TryParseFromSan(message, out move)) return;
            if (chessBoard.IsEndGame)
            {
                Debug.WriteLine("Game end " + chessBoard.EndGame.WonSide + " won!");
                return;
            }
            chessBoard.Move(move);
            panel1.Invalidate();
        }

        /// <summary>
        /// Promotion UI for the pawn/ not implemeted yet
        /// </summary>
        /// <param name="message"></param>
        public PromotionType PromotePawnUIAsync()
        {
            if (Side == PieceColor.White) // set up images for promotion
            {
                Queen.ImageKey = "WQueen";
                Knight.ImageKey = "WKnight";
                Rook.ImageKey = "WRook";
                Bishop.ImageKey = "WBishop";
            }
            else
            {
                Queen.ImageKey = "BQueen";
                Knight.ImageKey = "BKnight";
                Rook.ImageKey = "BRook";
                Bishop.ImageKey = "BBishop";
            }

            Queen.Click += (s, ev) => { selectedPromotion = PromotionType.ToQueen; };
            Knight.Click += (s, ev) => { selectedPromotion = PromotionType.ToKnight; };
            Rook.Click += (s, ev) => { selectedPromotion = PromotionType.ToRook; };
            Bishop.Click += (s, ev) => { selectedPromotion = PromotionType.ToBishop; };

            flowLayoutPanel1.Visible = true;
            var selectedPromote = selectedPromotion;
            return selectedPromote;
        }

        private void PromotePawn(object sender, PromotionEventArgs e)
        {
            e.PromotionResult = selectedPromotion == null ? selectedPromotion : PromotionType.Default;
            //e.PromotionResult = PromotionType.ToRook;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            if(isOffline) return; // If offline mode, return
            // Do something when form is loaded
            x = new ChatClientJoin();
            x.Show();
            x.JoiningRoom(PlayerName, this);
            x.Joined += Room_Joined;
        }

        private void Room_Joined(object sender, EventArgs e)
        {
            currenChatMainForm = x.currentChatMainForm;
            // Add any additional actions needed once the chat is joined
            if (currenChatMainForm != null)
            {
                Console.WriteLine("Joined room with : " + currenChatMainForm.Side);
                InitGame(currenChatMainForm.Side,"10|0");
            }
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
            InitGame(Side, "10|0", true);
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
            Console.WriteLine(fullPath);
            return fullPath;
        }
        private void InitUserInfo()
        {
            ourName.Text = PlayerName + " ( " + PlayerNumber + " )";
            opponentName.Text = "Opponent";
           

        }
        private void beginTimer()
        {
            timeOur = TimeSpan.FromMinutes(1);
            timeOpponent = TimeSpan.FromMinutes(1);
            opponentTimer.BackColor = Color.LightGray;
            ourTimer.BackColor = Color.DarkGray;

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                if (chessBoard.Turn == Side)
                {
                    timeOur = timeOur.Subtract(TimeSpan.FromSeconds(1));
                    ourTimer.Text = timeOur.ToString(@"mm\:ss");
                    ourTimer.BackColor = Color.DarkGray;
                    opponentTimer.BackColor = Color.LightGray;
                    if (timeOur.TotalSeconds <= 0)
                    {
                        timer1.Stop();
                        LogMessage(PlayerName + "'s time is up!");
                    }
                }
                else
                {
                    timeOpponent = timeOpponent.Subtract(TimeSpan.FromSeconds(1));
                    opponentTimer.Text = timeOpponent.ToString(@"mm\:ss");
                    opponentTimer.BackColor = Color.DarkGray;
                    ourTimer.BackColor = Color.LightGray;
                    if (timeOpponent.TotalSeconds <= 0)
                    {
                        timer1.Stop();
                        LogMessage("Opponent's time is up!");
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

      
    }
}
