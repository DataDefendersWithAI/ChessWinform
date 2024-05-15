using Ardalis.SmartEnum.Core;
using Chess;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChessAI
{
    public partial class ChessAIClient : Form
    {
        private BoardRenderer boardRenderer;
        private ChessBoard chessBoard;
        private PieceColor Side;
        private bool gameStarted = false;

        // Connections
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;

        // Random player name
        private string PlayerName = "Player" + Guid.NewGuid().ToString();

        public ChessAIClient()
        {
            InitializeComponent();
            DoubleBuffered = true; // Remove the small blinking when Invalidate()



            chessBoard = new ChessBoard() { AutoEndgameRules = AutoEndgameRules.All }; // Init new board
            boardRenderer = new BoardRenderer(); // Init new renderer

            this.Size = new System.Drawing.Size(1000, 800); // Add minimum offset is 75 and maybe some space
            this.FormClosed += ClientForm_FormClosed; // Add event when form is closed
        }
        private void InitGame(string message)
        {
            if(gameStarted) return; // If game already started, return
            // Set the side
            Side = message.Contains("White") ? PieceColor.White : PieceColor.Black; 
            // Set the game started
            gameStarted = true;
            LogMessage("Game started! You are: " + Side);
            Invalidate(); // Redraw whole screen
        }
        private void boardPaint(object sender, PaintEventArgs e) // Update continuously
        {
            if(!gameStarted) return; // If game not started, return
            boardRenderer.DrawBoard(e.Graphics, chessBoard, 500, isDebug: true, side: Side); // Draw the board
            richTextBox1.Text = chessBoard.ToPgn(); // Show the moves       
        }

        private void boardClick(object sender, MouseEventArgs e)
        {
            if (!gameStarted) return; // If game not started, return
            Debug.WriteLine("X: " + e.X + " Y: " + e.Y);
            chessBoard = boardRenderer.onClicked(new Position(e.X, e.Y), chessBoard, isNormalized: false, side: Side); // Handle the click
            Invalidate(); // Redraw whole screen
            LogMessage(chessBoard.MovesToSan.Any() ? chessBoard.MovesToSan.Last() : "none");
            SendMessage(chessBoard.MovesToSan.Any() ? chessBoard.MovesToSan.Last() : "none");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!gameStarted) return; // If game not started, return
            if (chessBoard.Turn == Side) return; // Simulate opponent

            var moves = chessBoard.Moves();
            if (chessBoard.IsEndGame)
            {
                Debug.WriteLine("Game end " + chessBoard.EndGame.WonSide + " won!");
                return;
            }
            chessBoard.Move(moves[Random.Shared.Next(moves.Length)]);
            Invalidate();
        }

        private void MoveAsMessage(string message)
        {
            Move move;
            if (!chessBoard.TryParseFromSan(message, out move)) return;
            if (chessBoard.IsEndGame)
            {
                Debug.WriteLine("Game end " + chessBoard.EndGame.WonSide + " won!");
                return;
            }
            chessBoard.Move(move);
            Invalidate();
        }


        private void ClientForm_Load(object sender, EventArgs e)
        {
            try // Attempt to connect to server
            {
                ConnectToServer();
                receiveThread = new Thread(new ThreadStart(ReceiveMessages));
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                LogMessage("Error: " + ex.Message);
            }
        }

        private void ConnectToServer()
        {
            client = new TcpClient();
            client.Connect("127.0.0.1", 9099);
            stream = client.GetStream();
            LogMessage(PlayerName + " connected to server.");
        }

        private void ReceiveMessages()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while (true)
                {
                    bytesRead = 0;
                    try
                    {
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                    }
                    catch
                    {
                        break;
                    }

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    LogMessage("Rcv: " + message);
                    if(message.Contains("BG*#"))
                    {
                        InitGame(message); // Init the game and set side
                    }
                    else
                    {
                        MoveAsMessage(message);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                LogMessage("Error: " + ex.Message);
            }
        }

        private void SendMessage(string message)
        {
            try
            {
                if (client != null && client.Connected)
                {
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    LogMessage("Snd: " + message);
                }
                else
                {
                    LogMessage("Not connected to server.");
                }
            }
            catch (Exception ex)
            {
                LogMessage("Error: " + ex.Message);
            }
        }

        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }
            richTextBox2.AppendText(message + "\n");
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Send last message to server
            SendMessage("Client " + PlayerName + " disconnected!");
            // Close the stream
            if (stream != null)
            {
                stream.Close();
            }
            // Close the client
            if (client != null)
            {
                client.Close();
            }
            // Stop receiving messages
            if (receiveThread != null && receiveThread.IsAlive)
            {
                receiveThread.Abort();
            }
        }

        private void cntSvr_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectToServer();
                receiveThread = new Thread(new ThreadStart(ReceiveMessages));
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                LogMessage("Error: " + ex.Message);
            }
        }
    }
}
