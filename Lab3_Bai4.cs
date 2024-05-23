using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessAI
{
    public partial class Lab3_Bai4 : Form
    {
        public Lab3_Bai4()
        {
            InitializeComponent();
        }

        private void btn_startServer_Click(object sender, EventArgs e)
        {
            // Open server form
            ChatBox_Server_Form serverForm = new ChatBox_Server_Form();
            serverForm.Show();
        }

        private void btn_startClient_Click(object sender, EventArgs e)
        {
            // Open client form
            ChessAIClient clientForm = new ChessAIClient();
            clientForm.Show();
        }
    }
}
