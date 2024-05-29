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
using ChessAI;
using ChessAI.ChatServerAndClient;

namespace winforms_chat
{
    public partial class ChatServerLog : Form
    {

        // Temporaly init server to not null
        private ServerCommunication serverComm;
        string serverIP = ChessAI.ChatServerAndClient.Constants.serverIP;
        int serverPort = ChessAI.ChatServerAndClient.Constants.serverPort;
        bool isFormHideOnLoad;
        ChatServerCode codeForm;
        public ChatServerLog(bool hidOnLoad = false)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.ServerForm_Closing);
            isFormHideOnLoad = hidOnLoad;
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            serverComm = new ServerCommunication(serverIP, serverPort, LogMessage);

            serverComm.StartServer(); // auto start server
            // Open the code form
            if(codeForm != null)
            {
                codeForm.Close(); // clear the code form
            }
            codeForm = new ChatServerCode();
            codeForm.Show();

            if (isFormHideOnLoad)
            {
                codeForm.Hide();
            }

        }

        private void ServerForm_Closing(object sender, FormClosingEventArgs e)
        {
            if(codeForm != null)
            {
                codeForm.Close();
                codeForm.Dispose();
            }
            if(serverComm != null)
            {
                // server close
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            serverComm.StartServer();
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
                //MessageBox.Show(ex.Message, "Warning");
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_openCodeForm_Click(object sender, EventArgs e)
        {
            // Open the code form
            ChatServerCode codeForm = new ChatServerCode();
            codeForm.Show();
        }
    }
}
