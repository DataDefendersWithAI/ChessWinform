using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private List<TcpClient> connectedClients = new List<TcpClient>(); // List of connected clients
        private Dictionary<TcpClient, TcpClient> GameRooms = new Dictionary<TcpClient, TcpClient>(); // List of game rooms

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
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 29099);
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
            bool isFoundMatch = gameAutoMatch(tcpClient); // Attempt to match the player to a game
            Debug.WriteLine("Rooms Count: " + GameRooms.Count);

            if (isFoundMatch)
            {
                try
                {
                    TcpClient opponent = GameRooms[tcpClient]; // Get opponent TcpClient
                    if (!opponent.Connected)
                    {
                        GameRooms[tcpClient] = null; // Remove the opponent from the room
                        GameRooms.Remove(opponent);
                        connectedClients.Remove(opponent);
                        BroadcastMessage("Opponent disconnected. Please wait for another player ...", tcpClient);
                        return;
                    } // If opponent is not connected, return


                    NetworkStream streamPlayer = tcpClient.GetStream(); // Stream for player
                    NetworkStream streamOpponent = opponent.GetStream(); // Stream for opponent

                    Random random = new Random();
                    bool playerTurn = random.Next(2) == 0; // Randomly choose who goes first
                    string playerTurnMessage = playerTurn ? "You are: White" : "You are: Black";
                    string opponentTurnMessage = playerTurn ? "You are: Black" : "You are: White";

                    BroadcastMessage("BG*#" + playerTurnMessage, tcpClient);
                    BroadcastMessage("BG*#" + opponentTurnMessage, opponent);

                    byte[] buffer = new byte[1024];
                    byte[] bufferOpponent = new byte[1024];
                    int bytesRead = 0;
                    int bytesReadOpponent = 0;
                    while (true)
                    {
                        //Init
                        bytesRead = 0;
                        bytesReadOpponent = 0;
                        // Player's turn
                        try
                        {
                            bytesRead = streamPlayer.Read(buffer, 0, buffer.Length);
                        }
                        catch (Exception ex)
                        {
                            LogMessage($"Error: {ex.Message}");
                            break;

                        }
                      
                        if (bytesRead == 0)
                            break;

                        // Opponent's turn
                        try
                        {
                            bytesReadOpponent = streamOpponent.Read(bufferOpponent, 0, bufferOpponent.Length);
                        }
                        catch (Exception ex)
                        {
                            LogMessage($"Error: {ex.Message}");
                            break;
                        }

                        if (bytesReadOpponent == 0)
                            break;

                        // Send player's move to the opponent
                        streamOpponent.Write(buffer, 0, bytesRead);
                        // Send opponent's move to the player
                        streamPlayer.Write(bufferOpponent, 0, bytesReadOpponent);
                    }
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    LogMessage($"Error: {ex.Message}");
                }
                finally
                {
                    // Remove the player from the room
                    GameRooms.Remove(tcpClient);
                    connectedClients.Remove(tcpClient);
                    tcpClient.Close();
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
            if(client == null) return false; // prevent something :)))
            if (GameRooms.ContainsKey(client))
            {
                return false; // Player is already in a room
            }
           
            
            // Check if there's an available room
            foreach (KeyValuePair<TcpClient, TcpClient> entry in GameRooms)
            {

                if (entry.Value == null)
                {
                    // Assign the player to the room
                    GameRooms[entry.Key] = client; // Assign the player to the room
                    GameRooms[client] = entry.Key; // Assign the room to the player for ease of access
                    return true;
                }
            }

            // If no available room, create a new room
            GameRooms.Add(client, null);
            return false;
            
        }

        private void BroadcastMessage(string message, TcpClient tcpClient)
        {
            if (tcpClient == null || !tcpClient.Connected)
            {
                LogMessage("Error: Client is null or not connected.");
                return;
            }

            try
            {
                NetworkStream stream = tcpClient.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                LogMessage($"Sent message to {tcpClient.Client.RemoteEndPoint}: {message}");
               // stream.Close(); // Close the stream after sending the message
            }
            catch (IOException ex)
            {
                // Handle IOException, which occurs when the client disconnects abruptly
                LogMessage($"Error: Client disconnected unexpectedly. {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                LogMessage($"Error: {ex.Message}");
            }
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
