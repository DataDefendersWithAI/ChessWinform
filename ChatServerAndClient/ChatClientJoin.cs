﻿using System;
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

namespace winforms_chat
{
    public partial class ChatClientJoin : Form
    {
        // Variables
        private Communication comm;
        // Constants
        string serverIP = ChessAI.ChatServerAndClient.Constants.serverIP;
        int serverPort = ChessAI.ChatServerAndClient.Constants.serverPort;
        bool isFormExit = false;

        // Connect with ChessAIClient
        public ChatMainForm currentChatMainForm { get; private set; }
        public bool isJoined { get; private set; }
        public event EventHandler Joined;

        ChessAIClient chessClient;


        public ChatClientJoin()
        {
            InitializeComponent();
            isJoined = false;

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
                    // Check if code is 000000, type is join, from "server", msg.to contains txt_userName.Text
                    // If yes, then take message as room code, MessageBox it
                    // Then close this form and open ChatMainForm.cs
                    if (msg.TableCode == "000000" && msg.type == "join" && msg.from == "server" && msg.to.Contains(txt_userName.Text) && msg.message!="close")
                    {
                        // Split msg.to by - and swap if needed to make sure that first part is user name and second part is opponent user name
                        string[] userNames = msg.to.Split('-');
                        string userName = userNames[0];
                        string opponentUserName = userNames[1];
                        // Split message for table code and side
                        string[] mess = msg.message.Split('$');
                        string newTableCode = mess[0];
                        string[] userSides = mess[1].Split('-');
                        string Side = userSides[0];
                        string OpponentSide = userSides[1];
                        // If user name is not equal to txt_userName.Text, swap user name and opponent user name
                        if (userName != txt_userName.Text)
                        {
                            userName = userNames[1];
                            opponentUserName = userNames[0];
                            // Swap side as well
                            string temp = Side;
                            Side = OpponentSide;
                            OpponentSide = temp;
                        }
                        // Merge userName and opponentUserName with "-" and pass it to ChatMainForm
                        msg.to = userName + "-" + opponentUserName;
                      
                        //MessageBox.Show("Room code: " + msg.message);
                        // Open ChatMainForm with table code and username
                        Console.WriteLine(msg.to , msg.message);
                        isFormExit = true;
                        ChatMainForm chatMainForm = new ChatMainForm(newTableCode, msg.to , chessClient, Side);
                        chatMainForm.Show();
                        currentChatMainForm = chatMainForm;
                        isJoined = true;
                        OnJoined(EventArgs.Empty);
                        this.Close();
                        this.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }

        }

        protected virtual void OnJoined(EventArgs e)
        {
            Joined?.Invoke(this, e);
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Send last message to server
            // TableCode: 000000
            // type: join
            // from: txt_userName.Text
            // to: server
            // message: disconnected
            // date: DateTime.Now
            if (isFormExit)
            {
                return;
            }
            // When user closes the form, send message to server
            ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", txt_userName.Text, "server", "disconnect", DateTime.Now);
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

            JoiningRoom(txt_userName.Text, null);
        }

        public void JoiningRoom(string userName, ChessAIClient chClient)
        {
            chessClient = chClient;
            Debug.WriteLine("JoiningRoom called with user name: " + userName);
            txt_userName.Text = userName;
            // Check if user name is "server"
            if (userName == "server")
            {
                MessageBox.Show("Invalid user name.");
                return;
            }

            // Check if name contains special characters
            if (userName.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Invalid user name.");
                return;
            }

            if (comm == null) return;

            // Shows pnl_wait and hides pnl_join
            pnl_wait.Visible = true;
            pnl_join.Visible = false;

            // Send message to server using JSON
            // TableCode: 000000
            // type: join
            // from: userName.Text
            // to: 
            // message: 
            // date: DateTime.Now


            ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", userName, "server", "", DateTime.Now);
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
