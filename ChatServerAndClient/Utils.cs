using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

/// <summary>
/// Usages:
/// From object to JSON:
/// Message message = new Message("TableCode", "type", "from", "to", "message", DateTime.Now);
/// string json = message.ToJson();
/// From JSON to object:
/// Message message = Message.FromJson(json);
/// Console.WriteLine(message.TableCode);
/// 
/// ClientCommunication Usages:
/// Init Communication: Communication comm = new Communication(IP, Port, LogMessage);
///     with LogMessage is a method to handle received messages.
/// All methods from connect to server, start thread in comm.ClientLoad();
/// Send message: comm.SendMessage("message");
/// Close connection: comm.ClientClose();
/// 
/// ServerCommunication Usages:
/// Init Communication: ServerCommunication comm = new Communication(IP, Port, LogMessage);
///     with LogMessage is a method to handle received messages.
/// Start server: comm.StartServer();
/// Close server: TODO
/// </summary>

namespace ChessAI.ChatServerAndClient
{
    /// <summary>
    /// Represents a chat message.
    /// </summary>
    public class Message
    {
        public string TableCode { get; set; }
        public string type { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="TableCode">The table code.</param>
        /// <param name="type">The message type.</param>
        /// <param name="from">The sender of the message.</param>
        /// <param name="to">The recipient of the message.</param>
        /// <param name="message">The message content.</param>
        /// <param name="date">The date and time of the message.</param>
        public Message(string TableCode, string type, string from, string to, string message, DateTime date)
        {
            this.TableCode = TableCode;
            this.type = type;
            this.from = from;
            this.to = to;
            this.message = message;
            this.date = date;
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <returns>The JSON representation of the object.</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Deserializes the JSON to an object.
        /// </summary>
        /// <param name="json">The JSON string.</param>
        /// <returns>The deserialized object.</returns>
        public static Message FromJson(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException(nameof(json));
            }
            return JsonSerializer.Deserialize<Message>(json);
        }
    }


    /// <summary>
    /// Handles TCP client communication, including connecting to the server,
    /// receiving messages, sending messages, and logging messages.
    /// </summary>
    public class Communication
    {
        [ThreadStatic]
        public static readonly bool isMainThread = true;
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private Action<string> receiveHandler;
        protected string ipAddress;
        protected int port;
        /// <summary>
        /// Initializes a new instance of the <see cref="Communication"/> class.
        /// </summary>
        /// <param name="ipAddress">The IP address of the server.</param>
        /// <param name="port">The port number to connect to.</param>
        /// <param name="receiveHandler">The handler to process received messages.</param>
        public Communication(string ipAddress, int port, Action<string> receiveHandler)
        {
            this.ipAddress = ipAddress;
            this.port = port;
            this.receiveHandler = receiveHandler;
        }
        /// <summary>
        /// Loads the client and starts the connection and message receiving process.
        /// </summary>
        public void ClientLoad()
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
        /// <summary>
        /// Connects to the server using the specified IP address and port.
        /// </summary>
        public void ConnectToServer()
        {
            client = new TcpClient();
            client.Connect(ipAddress, port);
            stream = client.GetStream();
            LogMessage("Connected to server.");
        }
        /// <summary>
        /// Receives messages from the server continuously.
        /// </summary>
        public void ReceiveMessages()
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
                    receiveHandler(message);
                }
            }
            catch (Exception ex)
            {
                LogMessage("Error: " + ex.Message);
            }
        }
        /// <summary>
        /// Sends a message to the server.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public void SendMessage(string message)
        {
            try
            {
                if (client != null && client.Connected)
                {
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    LogMessage(message);
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
        /// <summary>
        /// Logs a message using the receive handler.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void LogMessage(string message)
        {
            if (Communication.isMainThread)
            {
                // If message is error, MessageBox it
                if (message.Contains("Error:"))
                {
                   // MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Error: "+message);
                }
                // Invoke the receive handler to log the message
                receiveHandler?.Invoke(message);
            }
        }
        /// <summary>
        /// Closes the connection to the server.
        /// </summary>
        public void ClientClose()
        {
            if (stream != null)
            {
                stream.Close();
            }
            if (client != null)
            {
                client.Close();
            }
        }
    }

    /// <summary>
    /// Handles TCP client communication specifically.
    /// </summary>
    public class ClientCommunication : Communication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientCommunication"/> class.
        /// </summary>
        /// <param name="ipAddress">The IP address of the server.</param>
        /// <param name="port">The port number to connect to.</param>
        /// <param name="receiveHandler">The handler to process received messages.</param>
        public ClientCommunication(string ipAddress, int port, Action<string> receiveHandler)
            : base(ipAddress, port, receiveHandler)
        {
            // No additional constructor logic required
        }

        // No additional methods or properties needed, inherits all from Communication
    }


    /// <summary>
    /// Handles TCP server communication, including listening for clients,
    /// handling client connections, and broadcasting messages.
    /// </summary>
    public class ServerCommunication : Communication
    {
        private TcpListener server;
        private Thread serverThread;
        private List<TcpClient> connectedClients = new List<TcpClient>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerCommunication"/> class.
        /// </summary>
        /// <param name="ipAddress">The IP address for the server to listen on.</param>
        /// <param name="port">The port number for the server to listen on.</param>
        /// <param name="receiveHandler">The handler to process received messages.</param>
        public ServerCommunication(string ipAddress, int port, Action<string> receiveHandler)
            : base(ipAddress, port, receiveHandler)
        {
        }

        /// <summary>
        /// Starts the server and begins listening for client connections.
        /// </summary>
        public void StartServer()
        {
            serverThread = new Thread(new ThreadStart(ListenForClients));
            serverThread.IsBackground = true;
            serverThread.Start();
            LogMessage($"Server running on {base.ipAddress}:{base.port}");
        }

        /// <summary>
        /// Listens for incoming client connections.
        /// </summary>
        private void ListenForClients()
        {
            try
            {
                server = new TcpListener(IPAddress.Parse(base.ipAddress), base.port);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles communication with a connected client.
        /// </summary>
        /// <param name="obj">The client to handle.</param>
        private void HandleClient(object obj)
        {
            TcpClient tcpClient = (TcpClient)obj;
            NetworkStream stream = tcpClient.GetStream();

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
                BroadcastMessage(message, tcpClient);
            }

            tcpClient.Close();
            connectedClients.Remove(tcpClient);
        }

        /// <summary>
        /// Broadcasts a message to all connected clients except the sender.
        /// </summary>
        /// <param name="message">The message to broadcast.</param>
        /// <param name="senderClient">The client that sent the message.</param>
        private void BroadcastMessage(string message, TcpClient senderClient)
        {
            if (server == null)
            {
                return;
            }
            foreach (TcpClient client in connectedClients)
            {
                if (client != senderClient)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        byte[] data = Encoding.ASCII.GetBytes(message);
                        stream.Write(data, 0, data.Length);
                    }
                    catch
                    {
                        LogMessage("Error: Client disconnected.");
                    }
                }
            }

            LogMessage($"{message}");
        }

        public void CloseServer()
        {
            if (server != null)
            {
                server.Stop();
            }
        }   
        public bool IsServerRunning()
        {
            // Check if server is running
            if (server != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
