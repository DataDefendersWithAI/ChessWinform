using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

// Import the Message class from MessageClass.cs
using ChessAI.ChatServerAndClient;

namespace winforms_chat
{
    public partial class ChatClientJoin : Form
    {
        // Variables
        private Communication comm;
        // Constants
        string serverIP = "127.0.0.1";
        int serverPort = 9999;
        public ChatClientJoin()
        {
            InitializeComponent();
        }
        private void ClientForm_Load(object sender, EventArgs e)
        {
            // Show pnl_join and hide pnl_wait
            pnl_join.Visible = true;
            pnl_wait.Visible = false;
            comm = new Communication(serverIP, serverPort, LogMessage);
            comm.ClientLoad();
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
                Console.WriteLine("Received: " + message);
                // If message is not valid JSON, return
                if (!message.Contains("TableCode") || !message.Contains("type") || !message.Contains("from") || !message.Contains("to") || !message.Contains("message") || !message.Contains("date"))
                {
                    return;
                }

                // Extract message from JSON
                ChessAI.ChatServerAndClient.Message msg = ChessAI.ChatServerAndClient.Message.FromJson(message);
                if (msg != null)
                {
                    // Check if code is 000000, type is join, from "server", to txt_userName.Text
                    // If yes, then take message as room code, MessageBox it
                    // Then close this form and open ChatMainForm.cs
                    if (msg.TableCode == "000000" && msg.type == "join" && msg.from == "server" && msg.to == txt_userName.Text)
                    {
                        MessageBox.Show("Room code: " + msg.message);
                        this.Hide();
                        ChatMainForm chatMainForm = new ChatMainForm();
                        chatMainForm.ShowDialog();
                        this.Close();
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
            // TableCode: 000000
            // type: join
            // from: txt_userName.Text
            // to: server
            // message: disconnected
            // date: DateTime.Now
            ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", txt_userName.Text, "server", "disconnected", DateTime.Now);
            comm.SendMessage(message.ToJson());
            comm.ClientClose();
        }

        private void btn_join_Click(object sender, EventArgs e)
        {
            // Check if user name is empty
            if (txt_userName.Text == "")
            {
                MessageBox.Show("Please enter your name.");
                return;
            }
            // Check if user name is "server"
            if (txt_userName.Text == "server")
            {
                MessageBox.Show("Invalid user name.");
                return;
            }

            // Shows pnl_wait and hides pnl_join
            pnl_wait.Visible = true;
            pnl_join.Visible = false;

            // Send message to server using JSON
            // TableCode: 000000
            // type: join
            // from: txt_userName.Text
            // to: 
            // message: 
            // date: DateTime.Now

            ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", txt_userName.Text, "server", "", DateTime.Now);
            comm.SendMessage(message.ToJson());
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // Show pnl_join and hide pnl_wait
            pnl_join.Visible = true;
            pnl_wait.Visible = false;
            // Also send message to server
            // TableCode: 000000
            // type: join
            // from: txt_userName.Text
            // to: server
            // message: cancel
            // date: DateTime.Now
            ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", txt_userName.Text, "server", "cancel", DateTime.Now);
            comm.SendMessage(message.ToJson());
        }
    }
}
