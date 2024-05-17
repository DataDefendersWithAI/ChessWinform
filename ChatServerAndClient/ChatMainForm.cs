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

namespace winforms_chat
{
	public partial class ChatMainForm : Form
	{
		// Variables
		private string tableCode;
		private string userName;
		private string opponentUserName;
		ChatForm.Chatbox chat_panel;
		// Also communication object
		private ClientCommunication comm;
		private string serverIP = "127.0.0.1";
		private int serverPort = 9999;
		public ChatMainForm(string tableCode = "123456", string userName = "testUser")
		{
			this.tableCode = tableCode;
			// Split userName by - and get the first part as userName, second part as opponentUserName
			Console.WriteLine("userName: " + userName);
			string[] userNames = userName.Split('-');
			this.userName = userNames[0];
			this.opponentUserName = userNames[1];
			InitializeComponent();
		}

		private void sendHandler(string chatmessage)
		{
            // Send message: {"TableCode": newTableCode, "type": "chat", "from": userName, "to": opponentUserName, "message": message, "date": DateTime.Now}
			ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message(tableCode, "chat", userName, opponentUserName, chatmessage, DateTime.Now);
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
                    // Check if code is this tableCode, type is chat, from opponentUserName, to userName
                    // If yes, then add message to chat panel
					if (msg.TableCode == tableCode && msg.type == "chat" && msg.from == opponentUserName && msg.to == userName)
					{
                        // Add message to chat panel
                        ChatForm.TextChatModel chatModel = new ChatForm.TextChatModel();
                        chatModel.Author = msg.from;
                        chatModel.Body = msg.message;
                        chatModel.Inbound = true;
                        chatModel.Time = msg.date;
                        chat_panel.AddMessage(chatModel);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
		{
			// Add chat panel
			ChatForm.ChatboxInfo cbi = new ChatForm.ChatboxInfo();
			cbi.User = userName; // Set user name
			cbi.NamePlaceholder = "Chatbox"; // Set chatbox name
			cbi.PhonePlaceholder = $"For table: {tableCode}"; // Set table code

			chat_panel = new ChatForm.Chatbox(cbi, sendHandler); // Create chat panel with chatbox info and send handler
			chat_panel.Name = "chat_panel";
			chat_panel.Dock = DockStyle.Fill;
			this.Controls.Add(chat_panel);

            // Add a welcome message
            chat_panel.AddMessage(new ChatForm.TextChatModel() { Author = "System", Body = $"Welcome back, {userName}! Joined chat in table {tableCode}!", Inbound = true, Time = DateTime.Now });

			// Start communication
			comm = new ClientCommunication(serverIP, serverPort, LogMessage);
			comm.ClientLoad();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
            // Send last message: {"TableCode": newTableCode, "type": "chat", "from": userName, "to": opponentUserName, "message": "disconnect", "date": DateTime.Now} and and also send to server: {"TableCode": "000000", "type": "chat", "from": userName, "to": "server", "message": "disconnect", "date": DateTime.Now}
			ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message(tableCode, "chat", userName, opponentUserName, "disconnect", DateTime.Now);
			comm.SendMessage(msg.ToJson());
			ChessAI.ChatServerAndClient.Message msg2 = new ChessAI.ChatServerAndClient.Message("000000", "chat", userName, "server", "disconnect", DateTime.Now);
			comm.SendMessage(msg2.ToJson());
            comm.ClientClose();
        }
	}
}
