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
		private string tableCode;
		private string userName;
		private string opponentUserName;
		ChatForm.Chatbox chat_panel;
		// Also communication object
		private ClientCommunication comm;
        string serverIP = ChessAI.ChatServerAndClient.Constants.serverIP;
        int serverPort = ChessAI.ChatServerAndClient.Constants.serverPort;

        ChessAIClient chessClient;
        public PieceColor Side { get; private set; }


        public ChatMainForm(string tableCode = "123456", string userName = "testUser" , ChessAIClient chClient = null, String side = "")
		{
            if (ChatMainForm.isMainThread)
            {
                this.tableCode = tableCode;
                // Split userName by - and get the first part as userName, second part as opponentUserName
                Console.WriteLine("userName: " + userName);
                string[] userNames = userName.Split('-');
                this.userName = userNames[0];
                this.opponentUserName = userNames[1]; 

                chessClient = chClient;
                Side = side.ToLower().Contains("white") ? PieceColor.White : PieceColor.Black;
               
                InitializeComponent();
                this.DoubleBuffered = true;

            }
            else
            {
                InitializeComponent();
              
                this.DoubleBuffered = true;
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
			ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message(tableCode, "chat", userName, opponentUserName, chatmessage, DateTime.Now);
            if (msg == null || comm == null) return;
            comm.SendMessage(msg.ToJson());
        }
        public void moveSendHandler(string move)
        {
            // Send message: {"TableCode": newTableCode, "type": "chess", "from": userName, "to": opponentUserName, "message": move, "date": DateTime.Now}
            ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message(tableCode, "chess", userName, opponentUserName, move, DateTime.Now);
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
            ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message(tableCode, "chess", userName, opponentUserName, move, DateTime.Now);
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
					if (msg.TableCode == tableCode &&( msg.from == opponentUserName || msg.from == "server" )&& msg.to == userName)
					{
                        if (msg.type == "chat")
                        {
                            // Add message to chat panel
                            ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                            chatModel.Author = msg.from;
                            chatModel.Body = msg.message;
                            chatModel.Inbound = true;
                            chatModel.Time = msg.date;
                            chat_panel.AddMessage(chatModel);
                        }
                        else if (msg.type == "chess")
                        {
                            // Add message to chat panel
                            //ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                            //chatModel.Author = msg.from;
                            //chatModel.Body = msg.message;
                            //chatModel.Inbound = true;
                            //chatModel.Time = msg.date;
                            //chat_panel.AddMessage(chatModel);
                            if (chessClient != null)
                            {
                                if (msg.message.Contains(ChatCommand.Move.ToString() ))
                                {
                                    chessClient.MoveAsMessage(msg.message.Replace(ChatCommand.Move.ToString(),""));
                                }
                                if (msg.message.Contains(ChatCommand.EndGame.ToString()))
                                {
                                    chessClient.EndGameOnline(msg.message.Replace(ChatCommand.EndGame.ToString(), ""));
                                }
                                if (msg.message.Contains(ChatCommand.Rematch.ToString()))
                                {
                                    chessClient.RestartGameOnline(msg.message.Replace(ChatCommand.Rematch.ToString(), ""));
                                }
                                if (msg.message.Contains(ChatCommand.TimeSync.ToString()))
                                {
                                    chessClient.syncTimer(msg.message.Replace(ChatCommand.TimeSync.ToString(), ""));
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
                cbi.User = userName; // Set user name
                cbi.NamePlaceholder = "Chatbox"; // Set chatbox name
                cbi.PhonePlaceholder = $"For table: {tableCode}"; // Set table code

                chat_panel = new ChatForm.Chatbox(cbi, sendHandler); // Create chat panel with chatbox info and send handler
                chat_panel.Name = "chat_panel";
                chat_panel.Dock = DockStyle.Fill;
                this.Controls.Add(chat_panel);

                // Add a welcome message
                chat_panel.AddMessage(new ChatForm.TextChatModel() { Author = "System", Body = $"Welcome , {userName} joined chat [ID:{tableCode}]. Let's begin a fair game!", Inbound = true, Time = DateTime.Now });

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
 
            ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message(tableCode, "chat", userName, opponentUserName, "disconnect", DateTime.Now);
            comm.SendMessage(msg.ToJson());

            ChessAI.ChatServerAndClient.Message msg2 = new ChessAI.ChatServerAndClient.Message("000000", "chat", userName, "server", "disconnect", DateTime.Now);
            comm.SendMessage(msg2.ToJson());

            comm.ClientClose();

        }
    }
}
