using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winforms_chat
{
    public partial class ChatServerCode : Form
    {

        // Variables
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        public ChatServerCode()
        {
            InitializeComponent();
        }
    }
}


