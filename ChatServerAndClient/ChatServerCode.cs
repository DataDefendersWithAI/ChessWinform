using ChessAI.ChatServerAndClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private Communication comm;
        string serverIP = ChessAI.ChatServerAndClient.Constants.serverIP;
        int serverPort = ChessAI.ChatServerAndClient.Constants.serverPort;
        private System.Windows.Forms.Timer autoPickTimer;
        private bool isAutoPicking = false;
   
        public ChatServerCode()
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
            listview_userQueue.Columns.Add("Code", 150);
            listview_userQueue.Columns.Add("Player", 200);
            listview_userQueue.Columns.Add("Time ctrl", 200);
            listview_userQueue.Columns.Add("Elo", 200);
            listview_userQueue.Columns.Add("Status", 100);
            listview_userQueue.Columns.Add("Type", 200);
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
                Debug.WriteLine("[SVR] received: " + message);
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
                    if (msg.type == "join" && msg.TableCode == "000000" && msg.to == "server" )
                    {
                        // If message is empty, it means user want to join the game online
                        // If message is not empty, it means user want to join the game room queue
                        // If message is "cancel", it means user want to cancel the game room queue
                        if (msg.message == "")
                        {
                            Debug.WriteLine("User " + msg.from + " want to join the Pvp");
                            string userName = msg.from;
                            ListViewItem item = new ListViewItem(msg.TableCode);
                            item.SubItems.Add(userName);
                            item.SubItems.Add("none");
                            item.SubItems.Add("Idle");
                            item.SubItems.Add("Player");
                            listview_userQueue.Items.Add(item);
                        }
                        else if (msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ServerBeginGame)))
                        {
                            msg.message = msg.message.Replace(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ServerBeginGame), "");
                            string[] data = msg.message.Split('@');
                            string timectrl = data[0];
                            string[] players = data[1].Split('-');
                            string player1 = players[0];
                            string player2 = players[1];
                            Debug.WriteLine("[SVR] User " + player1 + " and " + player2 + " begin the game with time control " + timectrl);
                            BeginGame(player1, player2, timectrl);

                        }
                        else if (msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ServerCreateRoom)))
                        {
                            Debug.WriteLine("[SVR] User " + msg.from + " want to join the game room queue");
                            string userName = msg.from;
                            msg.message = msg.message.Replace(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ServerCreateRoom), "");
                            string[] info = msg.message.Split('@');
                            string ELO = info[1];
                            string timeCtrl = info[0];
                            // check if timeCtrl is empty
                            if (string.IsNullOrEmpty(timeCtrl))
                            {
                                Debug.WriteLine("[SVR] User " + msg.from + " want to join the game room queue but timeCtrl is empty, auto set to 10|0");
                                timeCtrl = "10|0";
                            }
                            // Add user to listview
                            ListViewItem item = new ListViewItem(msg.TableCode);
                            item.SubItems.Add(userName);
                            item.SubItems.Add(timeCtrl);
                            item.SubItems.Add(ELO);
                            item.SubItems.Add("Waiting");
                            item.SubItems.Add("Room");
                            listview_userQueue.Items.Add(item);
                        }
                        else if (msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.AutoMatching)))
                        {
                            Debug.WriteLine("[SVR] User " + msg.from + " is auto matching");
                            string timeCtrl = msg.message.Replace(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.AutoMatching), "");

                            // Check if timeCtrl is empty
                            if (string.IsNullOrEmpty(timeCtrl))
                            {
                                Debug.WriteLine("[SVR] User " + msg.from + " is auto matching but timeCtrl is empty, auto set to 10|0");
                                timeCtrl = "10|0";
                            }

                            // Begin finding a match; if found, remove users from listview
                            if (listview_userQueue.Items.Count >= 2)
                            {
                                Random random = new Random();
                                int index1 = -1;

                                // Find user index
                                for (int i = 0; i < listview_userQueue.Items.Count; i++)
                                {
                                    if (listview_userQueue.Items[i].SubItems[1].Text == msg.from)
                                    {
                                        index1 = i;
                                        break;
                                    }
                                }

                                if (index1 == -1)
                                {
                                    Debug.WriteLine("[SVR] User " + msg.from + " not found in queue.");
                                    return;
                                }

                                int index2 = random.Next(0, listview_userQueue.Items.Count);
                                while (index1 == index2)
                                {
                                    index2 = random.Next(0, listview_userQueue.Items.Count);
                                }

                                string player1 = listview_userQueue.Items[index1].SubItems[1].Text;
                                string player2 = listview_userQueue.Items[index2].SubItems[1].Text;

                                Debug.WriteLine("Pick 2 random players: " + player1 + " and " + player2 + " at index " + index1 + " and " + index2);

                                // Remove 2 users from listview
                                listview_userQueue.Items.RemoveAt(index1);
                                if (index2 > index1)
                                {
                                    index2--;
                                }
                                listview_userQueue.Items.RemoveAt(index2);

                                BeginGame(player1, player2, timeCtrl);
                            }
                        }
                        else if (msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ClientDisconnect)) || msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ClientLeaveRoom)))
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
                        else
                        {
                            Debug.WriteLine("[SVR] User " + msg.from + ": " + msg.message + " .... is not in expected, is it a err?");
                            return;
                        }
                        // update list user for all clients
                        Debug.WriteLine("[SVR] Update list user for all clients");
                        //UpdateUserList();
                    }
                    else if (msg.type == "update" && msg.TableCode == "000000" && msg.to == "server" && msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.GetUserList)))
                    {
                        Debug.WriteLine("[SVR] Cmd Update list user for all clients");
                        UpdateUserList();
                    }
                }

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message, "Warning");
                Debug.WriteLine(ex.Message);
            }

        }

        private void UpdateUserList()
        {
            // Parse listview_userQueue to string
            string result = "";
            foreach (ListViewItem item in listview_userQueue.Items)
            {
                if (item.SubItems[5].Text == "Room")
                {
                    result += item.SubItems[0].Text +"#"+ item.SubItems[1].Text + "#" + item.SubItems[2].Text + "#" + item.SubItems[3].Text + "#" + item.SubItems[4].Text +"#"+ item.SubItems[5].Text + "~";
                }
            }
            ChessAI.ChatServerAndClient.Message msg1 = new ChessAI.ChatServerAndClient.Message("000000", "update", "server", "all", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.GetUserList) + result, DateTime.Now);
            comm.SendMessage(msg1.ToJson());
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Send last message to server
            // Server code close connection: {"TableCode": "000000", "type": "join", "from": "server", "to": "server", "message": "close", "date": DateTime.Now}
            ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message("000000", "join", "server", "all", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ServerDisconnect), DateTime.Now);
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

                Debug.WriteLine("Pick 2 random players: " + player1 + " and " + player2 + " at index " + index1 + " and " + index2);

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
                BeginGame(player1, player2, "10|0");

            }
        }

        private void BeginGame(string player1, string player2, string timectrl)
        {
            // remove the user from listview
            foreach (ListViewItem item in listview_userQueue.Items)
            {
                if (item.SubItems[1].Text == player1 || item.SubItems[1].Text == player2)
                {
                    listview_userQueue.Items.Remove(item);
                }
            }

            Random random = new Random();
            string newTableCode = random.Next(1, 999999).ToString("D6");
            // pick player side 
            string userSide = Random.Shared.Next(2) == 0 ? "white" : "black";
            string oppSide = userSide == "white" ? "black" : "white";
            

            Debug.WriteLine("[SVR] Begin game with code " + newTableCode + " between " + player1 + " and " + player2 + " with time control " + timectrl);
            ChessAI.ChatServerAndClient.Message msg1 = new ChessAI.ChatServerAndClient.Message("000000", "join", "server", player1 + "-" + player2, newTableCode + "$" + userSide + "-" + oppSide+"$"+timectrl, DateTime.Now);
         //   ChessAI.ChatServerAndClient.Message msg2 = new ChessAI.ChatServerAndClient.Message("000000", "join", "server", player2 + "-" + player1, newTableCode + "$" + oppSide + "-" + userSide  + "$" + timectrl, DateTime.Now);

            comm.SendMessage(msg1.ToJson());
            // comm.SendMessage(msg2.ToJson());
            

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
                // Also make sure btn_joinRandom_Click is enabled
                btn_joinRandom.Enabled = true;
            }
            else
            {
                // Start auto pick
                autoPickTimer.Start();
                isAutoPicking = true;
                btn_autoJoin.Text = "Stop Auto-Pick";
                // Also make sure btn_joinRandom_Click is disabled
                btn_joinRandom.Enabled = false;
            }
        }
    }
}


