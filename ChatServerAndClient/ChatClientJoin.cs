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


// Import the Message class from MessageClass.cs
using ChessAI.ChatServerAndClient;
using ChessAI_Bck;
using winform_chat;

namespace winforms_chat
{
    public partial class ChatClientJoin : Form
    {
        private bool isConnectedToServer = false;
        public ChatClientJoin(bool ConnectedToServer = false)
        {
            InitializeComponent();
            isConnectedToServer = ConnectedToServer;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            if (!isConnectedToServer)
            {
                Debug.WriteLine("[CL] Server is not available");
                label1.Text = "Server is not available";
                label1.ForeColor = Color.Salmon;
            }
            else
            {
                Debug.WriteLine("[CL] ok");
                label1.Text = "Your game will start soon!";
                label1.ForeColor = Color.Black;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(null, "", "click");
            this.Close();
            this.Dispose();
        }
    }
}
