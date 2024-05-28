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
using ChessAI_Bck;

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
        MainScreen ParentForm;

        public PvpWaitingForm(MainScreen ParentF)
        {
            InitializeComponent();
            isGameStarted = false;
            ParentForm = ParentF;

        }
        private void ClientForm_Load(object sender, EventArgs e)
        {
            // make this for alwaays center its content


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
            new SoundFXHandler(null, "", "click");
            var temp = new DashboardForm.PvpModeForm(ParentForm);
            ParentForm.LoadForm(temp);
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
