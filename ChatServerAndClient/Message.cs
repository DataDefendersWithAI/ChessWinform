using System;
using System.Collections.Generic;
using System.Linq;
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
/// Communication Usages:
/// Init Communication: Communication comm = new Communication(IP, Port, LogMessage);
///     with LogMessage is a method to handle received messages.
/// All methods from connect to server, start thread in comm.ClientLoad();
/// Send message: comm.SendMessage("message");
/// Close connection: comm.ClientClose();
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
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private Action<string> receiveHandler;
        private string ipAddress;
        private int port;
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
            receiveHandler?.Invoke(message);
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
}
