using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessAI
{
    public partial class ChatBox_Server_Form : Form
    {
        private TcpListener server;
        private Thread serverThread;
        private List<TcpClient> connectedClients = new List<TcpClient>();
        private Dictionary<TcpClient, TcpClient> GameRooms = new Dictionary<TcpClient, TcpClient>();

        public ChatBox_Server_Form()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            serverThread = new Thread(new ThreadStart(ListenForClients));
            serverThread.IsBackground = true;
            serverThread.Start();
            LogMessage("Server running on 127.0.0.1:9099");
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            serverThread.Abort();
            serverThread = new Thread(new ThreadStart(ListenForClients));
            serverThread.IsBackground = true;
            serverThread.Start();
            LogMessage("Server running on 127.0.0.1:9099");
        }

        private void ListenForClients()
        {
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9099);
                server.Start();

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    LogMessage("New client connected from: " + ((IPEndPoint)client.Client.RemoteEndPoint).ToString());
                    connectedClients.Add(client);

                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                LogMessage("Error: " + ex.Message);
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient tcpClient = (TcpClient)obj;
            bool isFoundMatch = gameAutoMatch(tcpClient); // auto match the player to a game

            if (isFoundMatch)
            {
                TcpClient opponent = GameRooms[tcpClient]; // Get opponent TcpClient
                NetworkStream streamPlayer = tcpClient.GetStream(); // Stream for player
                NetworkStream streamOpponent = opponent.GetStream(); // Stream for opponent

                byte[] buffer = new byte[1024];
                byte[] bufferOpponent = new byte[1024];

                try
                {
                    Random random = new Random();
                    bool playerTurn = random.Next(2) == 0; // Randomly choose who goes first
                    string playerTurnMessage = playerTurn ? "You are: White" : "You are: Black";
                    string opponentTurnMessage = playerTurn ? "You are: Black" : "You are: White";

                    BroadcastMessage("BG*#" + playerTurnMessage, tcpClient);
                    BroadcastMessage("BG*#" + opponentTurnMessage, opponent);

                    while (true)
                    {
                        // Player's turn
                        int bytesRead = streamPlayer.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0)
                            break;

                        // Send player's move to the opponent
                        streamOpponent.Write(buffer, 0, bytesRead);

                        // Opponent's turn
                        int bytesReadOpponent = streamOpponent.Read(bufferOpponent, 0, bufferOpponent.Length);
                        if (bytesReadOpponent == 0)
                            break;

                        // Send opponent's move to the player
                        streamPlayer.Write(bufferOpponent, 0, bytesReadOpponent);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    // Close connections
                    tcpClient.Close();
                    opponent.Close();
                }
            }
            else
            {
                // If no opponent found, notify the player
                BroadcastMessage("Waiting for opponent ...", tcpClient);
            }
        }


        private bool gameAutoMatch(TcpClient client)
        {
            foreach (KeyValuePair<TcpClient, TcpClient> entry in GameRooms)
            {
                if (entry.Value == null)
                {
                    GameRooms[entry.Key] = client; // if there's an empty room, assign the player to the room
                    GameRooms[client] = entry.Key; // make them in reverse for ease of access
                    return true;
                }
            }
            GameRooms.Add(client, null); // if no empty room, create a new room and wait for another player
            return false;
        }

        private void BroadcastMessage(string message, TcpClient tcpClient)
        {
            if (tcpClient == null || !tcpClient.Connected)
            {
                return;
            }

            try
            {
                NetworkStream stream = tcpClient.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch
            {
                LogMessage("Error: Client disconnected.");
            }

            LogMessage($"{message}");
        }

        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }
            richTextBox.AppendText(message + "\n");
        }
    }
}
