using ChessAI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winforms_chat
{
    public partial class SpawnClientAndServer : Form
    {
        public SpawnClientAndServer()
        {
            InitializeComponent();
        }

        private void btn_server_Click(object sender, EventArgs e)
        {
            // Start the server form ChatServerLog.cs
            ChatServerLog serverLog = new ChatServerLog();
            serverLog.Show();
        }

        private void btn_client_Click(object sender, EventArgs e)
        {
            // Start the client form ChatClientJoin.cs
            SpawnServerAndClient client = new SpawnServerAndClient();
           // ChatClientJoin client = new ChatClientJoin();
            client.Show();
        }
    }
}
