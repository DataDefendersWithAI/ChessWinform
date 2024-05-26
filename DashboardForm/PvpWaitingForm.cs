using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ChessAI;
using ChessAI.ChatServerAndClient;

namespace winform_chat.DashboardForm
{
    public partial class PvpWaitingForm : Form
    {
        // Variables
        private Communication comm;
        // Constants
        string serverIP = ChessAI.ChatServerAndClient.Constants.serverIP;
        int serverPort = ChessAI.ChatServerAndClient.Constants.serverPort;
        bool isFormExit = false;

        public bool isGameStarted { get; private set; }
        public event EventHandler Joined;

        ChessAIClient chessClient;


        public PvpWaitingForm()
        {
            InitializeComponent();
            isGameStarted = false;

        }
        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void LogMessage(string message)
        {
            
        }

        protected virtual void OnJoined(EventArgs e)
        {
            Joined?.Invoke(this, e);
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public void JoiningRoom(string userName, ChessAIClient chClient)
        {

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
