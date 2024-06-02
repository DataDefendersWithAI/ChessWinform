using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI.ChatServerAndClient
{
    internal class Constants
    {
        // Specify the server IP and port
        public static string serverIP = "127.0.0.1";//"192.168.1.74";
        public static int serverPort = 9999;

        public static void SetServerIP(string newServerIP)
        {
            serverIP = newServerIP;
        }
    }
}
