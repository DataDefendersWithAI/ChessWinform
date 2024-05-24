using ChessAI.ChatServerAndClient;
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

namespace LoginForm
{
    public partial class PvpForm : Form
    {

        // Variables
        private Communication comm;
        string serverIP = ChessAI.ChatServerAndClient.Constants.serverIP;
        int serverPort = ChessAI.ChatServerAndClient.Constants.serverPort;
        private System.Windows.Forms.Timer autoPickTimer;
        private bool isAutoPicking = false;
        public PvpForm()
        {
            InitializeComponent();
            // Initialize timer
            autoPickTimer = new System.Windows.Forms.Timer();
            autoPickTimer.Interval = 500; // Set interval to 1 second (1000 ms)
            autoPickTimer.Tick += btn_joinRandom_Click;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            comm = new Communication(serverIP, serverPort, LogMessage);
            comm.ClientLoad();
            // Add column name "Code" and "Player"
            listview_userQueue.View = View.Details;
            listview_userQueue.Columns.Add("Code", 50);
            listview_userQueue.Columns.Add("Player", 100);
        }

        private void LogMessage(string message)
        {
            // No log message

            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(LogMessage), message);
                    return;
                }
                // ------------ All received logic here -------------
                Console.WriteLine("Server code received: " + message);
                // If message is not valid JSON, return
                if (!message.Contains("TableCode") || !message.Contains("type") || !message.Contains("from") || !message.Contains("to") || !message.Contains("message") || !message.Contains("date"))
                {
                    return;
                }

                // Extract message from JSON
                ChessAI.ChatServerAndClient.Message msg = ChessAI.ChatServerAndClient.Message.FromJson(message);
                if (msg != null)
                {
                    // Check if message is correct format: Join the chat: {"TableCode": "000000", "type": "join", "from": userName, "to": "server", "message": "", "date": DateTime.Now}
                    if (msg.type == "join" && msg.TableCode == "000000")
                    {
                        // If message is empty, it means user want to join the chat queue
                        // If message is "cancel", it means user want to cancel the chat queue
                        if (msg.message == "")
                        {
                            // Add user to listview
                            ListViewItem item = new ListViewItem(msg.TableCode);
                            item.SubItems.Add(msg.from);
                            listview_userQueue.Items.Add(item);
                        }
                        else if (msg.message == "cancel" || msg.message == "disconnect")
                        {
                            // Remove user from listview
                            foreach (ListViewItem item in listview_userQueue.Items)
                            {
                                if (item.SubItems[1].Text == msg.from)
                                {
                                    listview_userQueue.Items.Remove(item);
                                    break;
                                }
                            }
                        }
                        else return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }

        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Send last message to server
            // Server code close connection: {"TableCode": "000000", "type": "join", "from": "server", "to": "server", "message": "close", "date": DateTime.Now}
            ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message("000000", "join", "server", "server", "close", DateTime.Now);
            comm.SendMessage(msg.ToJson());
            comm.ClientClose();
        }

        private void btn_joinRandom_Click(object sender, EventArgs e)
        {
            // Pick 2 random users from listview
            if (listview_userQueue.Items.Count >= 2)
            {
                Random random = new Random();
                int index1 = random.Next(0, listview_userQueue.Items.Count);
                int index2 = random.Next(0, listview_userQueue.Items.Count);
                while (index1 == index2)
                {
                    index2 = random.Next(0, listview_userQueue.Items.Count);
                }
                string player1 = listview_userQueue.Items[index1].SubItems[1].Text;
                string player2 = listview_userQueue.Items[index2].SubItems[1].Text;

               
                // Remove 2 users from listview
                listview_userQueue.Items.RemoveAt(index1);
                if (index2 > index1)
                {
                    index2--;
                }
                listview_userQueue.Items.RemoveAt(index2);


                // Send message to 2 users
                // Server send code to clients: {"TableCode": "000000", "type": "join", "from": "server", "to": userName + "-" + opponentUserName, "message": newTableCode +"$"+ userSide + "-" + oppSide, "date": DateTime.Now}
                // with newTableCode is a random string from 000001 to 999998
                string newTableCode = random.Next(1, 999999).ToString("D6");
                // pick player side 
                string userSide = Random.Shared.Next(2) == 0 ? "white" : "black";
                string oppSide = userSide == "white" ? "black" : "white";


                ChessAI.ChatServerAndClient.Message msg1 = new ChessAI.ChatServerAndClient.Message("000000", "join", "server", player1 + "-" + player2, newTableCode +"$"+ userSide + "-" + oppSide, DateTime.Now);
                comm.SendMessage(msg1.ToJson());

            }
        }

        // Auto pick 2 random users from listview
        private void btn_autoJoin_Click(object sender, EventArgs e)
        {
            // It like btn_joinRandom_Click but it will auto pick 2 users from listview
            if (isAutoPicking)
            {
                // Stop auto pick
                autoPickTimer.Stop();
                isAutoPicking = false;
                btn_autoJoin.Text = "Start Auto-Pick";

            }
            else
            {
                // Start auto pick
                autoPickTimer.Start();
                isAutoPicking = true;
                btn_autoJoin.Text = "Stop Auto-Pick";

            }
        }
    }
}


