using ChessAI.ChatServerAndClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = ChessAI.ChatServerAndClient.Message;
using System.Threading;
using ChessAI;
using Chess;
using System.Diagnostics;

namespace winforms_chat
{
	public partial class ChatMainForm : Form
	{
        // Variables
        [ThreadStatic]
        public static readonly bool isMainThread = true;
		public string tableCode { get; private set; }
        public string opponentUserName{ get; private set; }

        private string ourName { get; set; }
        public int opponentElo{ get; private set; }
        ChatForm.Chatbox chat_panel;
		// Also communication object
		private ClientCommunication comm;
        string serverIP = ChessAI.ChatServerAndClient.Constants.serverIP;
        int serverPort = ChessAI.ChatServerAndClient.Constants.serverPort;

        ChessAIClient chessClient;
        
        public PieceColor Side { get; private set; }
        public string timeCtrl { get; private set; }

        public ChatMainForm(string tableCode = "123456", string userName = "testUser" , ChessAIClient chClient = null, String side = "", string timectrl ="", int OpponentELO = 1)
		{
            if (ChatMainForm.isMainThread)
            {
                tableCode = tableCode;
                // Split userName by - and get the first part as userName, second part as opponentUserName
                Console.WriteLine("[CMF] userName: " + userName);
                string[] userNames = userName.Split('-');
                ourName = userNames[0];
                opponentUserName = userNames[1];
                opponentElo = OpponentELO;

                chessClient = chClient;
                Side = side.ToLower().Contains("white") ? PieceColor.White : PieceColor.Black;
                timeCtrl = string.IsNullOrEmpty(timectrl)?"10|0":timectrl;
                InitializeComponent();
                DoubleBuffered = true;

            }
            else
            {
                InitializeComponent();
              
                DoubleBuffered = true;
            }
   //         this.tableCode = tableCode;
   //         // Split userName by - and get the first part as userName, second part as opponentUserName
   //         Console.WriteLine("userName: " + userName);
   //         string[] userNames = userName.Split('-');
   //         this.userName = userNames[0];
   //         this.opponentUserName = userNames[1];
			//InitializeComponent();
		}

		private void sendHandler(string chatmessage)
		{
            if (chatmessage == "") return;
            // Send message: {"TableCode": newTableCode, "type": "chat", "from": userName, "to": opponentUserName, "message": message, "date": DateTime.Now}
			ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message(tableCode, "chat", ourName, opponentUserName, chatmessage, DateTime.Now);
            if (msg == null || comm == null) return;
            comm.SendMessage(msg.ToJson());
        }
        public void moveSendHandler(string move)
        {
            // Send message: {"TableCode": newTableCode, "type": "chess", "from": userName, "to": opponentUserName, "message": move, "date": DateTime.Now}
            ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message(tableCode, "chess", ourName, opponentUserName, move, DateTime.Now);
            if (msg == null || comm == null) return;
            comm.SendMessage(msg.ToJson());
            if (chessClient != null)
            {
                chessClient.timeSyncSend();
            }
        }
        public void timeSyncSendHandler(string move) // write in a diff func to prevent recuresive call
        {
            // Send message: {"TableCode": newTableCode, "type": "chess", "from": userName, "to": opponentUserName, "message": move, "date": DateTime.Now}
            ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message(tableCode, "chess", ourName, opponentUserName, move, DateTime.Now);
            if (msg == null || comm == null) return;
            comm.SendMessage(msg.ToJson());
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
                    // Check if code is this tableCode, type is chat, from opponentUserName or server, to userName
                    // If yes, then add message to chat panel
					if (msg.TableCode == tableCode &&( msg.from == opponentUserName || msg.from == "server" )&& msg.to == ourName)
					{
                        if (msg.type == "chat")
                        {
                            var msg1 = msg.message;
                            if ( msg1.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ClientDisconnect)))
                            {
                                msg1 = opponentUserName + " has left the game!";
                            };
                            // Add message to chat panel
                            ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                            chatModel.Author = msg.from;
                            chatModel.Body = msg1;
                            chatModel.Inbound = true;
                            chatModel.Time = msg.date;
                            chat_panel.AddMessage(chatModel);
                        }
                        else if (msg.type == "chess")
                        {
                            // Add message to chat panel

                            if (chessClient != null)
                            {
                                if (msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.Move) ))
                                {
                                    chessClient.MoveAsMessage(msg.message.Replace(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.Move),""));
                                }
                                else if (msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.EndGame)))
                                {
                                    if (msg.message.Contains("Resign"))
                                    {
                                        ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                                        chatModel.Author = msg.from;
                                        chatModel.Body = "[S] " + opponentUserName + " resigned!";
                                        chatModel.Inbound = true;
                                        chatModel.Time = msg.date;
                                        chat_panel.AddMessage(chatModel);
                                    }
                                    else if (msg.message.Contains("DrawAsk"))
                                    {
                                        ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                                        chatModel.Author = msg.from;
                                        chatModel.Body = "[S] " + opponentUserName + " requested a draw!";
                                        chatModel.Inbound = true;
                                        chatModel.Time = msg.date;
                                        chat_panel.AddMessage(chatModel);
                                    }
                                    else if (msg.message.Contains("DrawAccept"))
                                    {
                                        ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                                        chatModel.Author = msg.from;
                                        chatModel.Body = "[S] " + opponentUserName + " accepted a draw!";
                                        chatModel.Inbound = true;
                                        chatModel.Time = msg.date;
                                        chat_panel.AddMessage(chatModel);
                                    }
                                    else if (msg.message.Contains("DrawDecline"))
                                    {
                                        ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                                        chatModel.Author = msg.from;
                                        chatModel.Body = "[S] " + opponentUserName + " declined a draw!";
                                        chatModel.Inbound = true;
                                        chatModel.Time = msg.date;
                                        chat_panel.AddMessage(chatModel);
                                    }
                                    else if (msg.message.Contains("Timeout"))
                                    {
                                        ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                                        chatModel.Author = msg.from;
                                        chatModel.Body = "[S] " + opponentUserName + "'s time up!";
                                        chatModel.Inbound = true;
                                        chatModel.Time = msg.date;
                                        chat_panel.AddMessage(chatModel);
                                    }

                                    chessClient.EndGameOnline(msg.message.Replace(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.EndGame), ""));
                                }
                                else if (msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.Rematch)))
                                {
                                    if (msg.message.Contains("RestartAsk"))
                                    {
                                        ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                                        chatModel.Author = msg.from;
                                        chatModel.Body = "[S] " + opponentUserName + " requested a rematch!";
                                        chatModel.Inbound = true;
                                        chatModel.Time = msg.date;
                                        chat_panel.AddMessage(chatModel);
                                    }
                                    else if (msg.message.Contains("RestartAccept"))
                                    {
                                        ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                                        chatModel.Author = msg.from;
                                        chatModel.Body = "[S] "+ opponentUserName + " accepted your rematch request!";
                                        chatModel.Inbound = true;
                                        chatModel.Time = msg.date;
                                        chat_panel.AddMessage(chatModel);
                                    }
                                    else if (message == "RestartDecline")
                                    {
                                        ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                                        chatModel.Author = msg.from;
                                        chatModel.Body = "[S] " + opponentUserName + " declined your rematch request!";
                                        chatModel.Inbound = true;
                                        chatModel.Time = msg.date;
                                        chat_panel.AddMessage(chatModel);
                                    }

                                    chessClient.RestartGameOnline(msg.message.Replace(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.Rematch), ""));
                                }
                                else if (msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.TimeSync)))
                                {
                                    chessClient.syncTimer(msg.message.Replace(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.TimeSync), ""));
                                }
                            }
                        }   
                    }
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Warning");
                Console.WriteLine(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
		{
			// Add chat panel
            if (ChatMainForm.isMainThread)
            {
                // Create chatbox info (user name, chatbox name, table code
                ChatForm.ChatboxInfo cbi = new ChatForm.ChatboxInfo();
                cbi.User = ourName; // Set user name
                cbi.NamePlaceholder = "Chatbox"; // Set chatbox name
                cbi.PhonePlaceholder = $"For table: {tableCode}"; // Set table code

                chat_panel = new ChatForm.Chatbox(cbi, sendHandler); // Create chat panel with chatbox info and send handler
                chat_panel.Name = "chat_panel";
                chat_panel.Dock = DockStyle.Fill;
                this.Controls.Add(chat_panel);

                // Add a welcome message
                chat_panel.AddMessage(new ChatForm.TextChatModel() { Author = "System", Body = $"Welcome , {ourName} joined chat [ID:{tableCode}]. Let's begin a fair game!", Inbound = true, Time = DateTime.Now });

                // Start communication
                comm = new ClientCommunication(serverIP, serverPort, LogMessage);
                comm.ClientLoad();
            }
            else
            {
                this.Close();
            }
			//ChatForm.ChatboxInfo cbi = new ChatForm.ChatboxInfo();
			//cbi.User = userName; // Set user name
			//cbi.NamePlaceholder = "Chatbox"; // Set chatbox name
			//cbi.PhonePlaceholder = $"For table: {tableCode}"; // Set table code

			//chat_panel = new ChatForm.Chatbox(cbi, sendHandler); // Create chat panel with chatbox info and send handler
			//chat_panel.Name = "chat_panel";
			//chat_panel.Dock = DockStyle.Fill;
			//this.Controls.Add(chat_panel);

   //         // Add a welcome message
   //         chat_panel.AddMessage(new ChatForm.TextChatModel() { Author = "System", Body = $"Welcome back, {userName}! Joined chat in table {tableCode}!", Inbound = true, Time = DateTime.Now });

			//// Start communication
			//comm = new ClientCommunication(serverIP, serverPort, LogMessage);
			//comm.ClientLoad();

		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
            // Send last message: {"TableCode": newTableCode, "type": "chat", "from": userName, "to": opponentUserName, "message": "disconnect", "date": DateTime.Now} and and also send to server: {"TableCode": "000000", "type": "chat", "from": userName, "to": "server", "message": "disconnect", "date": DateTime.Now}
            if (comm == null) return;
            Debug.WriteLine("ChatMainFrom_FormClosing");
 
            ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message(tableCode, "chat", ourName, opponentUserName, ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ClientDisconnect) , DateTime.Now);
            comm.SendMessage(msg.ToJson());

            ChessAI.ChatServerAndClient.Message msg2 = new ChessAI.ChatServerAndClient.Message("000000", "chat", ourName, "server", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ClientDisconnect), DateTime.Now);
            comm.SendMessage(msg2.ToJson());

            comm.ClientClose();

        }
    }
}
