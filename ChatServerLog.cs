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

namespace winforms_chat
{
    public partial class ChatServerLog : Form
    {

        // Temporaly init server to not null
        private TcpListener server;
        private Thread serverThread;
        private List<TcpClient> connectedClients = new List<TcpClient>();
        public ChatServerLog()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            serverThread = new Thread(new ThreadStart(ListenForClients));
            serverThread.IsBackground = true;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            serverThread.Start();
            LogMessage("Server running on 127.0.0.1:9999");
        }

        private void ListenForClients()
        {
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
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
        }

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

            //LogMessage($"Broadcasted: {message}");
            LogMessage($"{message}");

        }

        private void LogMessage(string message)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(LogMessage), message);
                    return;
                }
                rtb_chatLog.AppendText(message + "\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }
    }
}
