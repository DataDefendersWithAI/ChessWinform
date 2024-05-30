using System;
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
using ChessAI_Bck;
using winform_chat;

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
        MainScreen ParentForm;
        private string OurName;
        public ChatClientJoin(MainScreen pForm = null)
        {
            InitializeComponent();
            isJoined = false;
            ParentForm = pForm;
        }
        private void ClientForm_Load(object sender, EventArgs e)
        {
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

                    Debug.WriteLine("[CL] Received: " + msg.ToJson());
                    // Check if code is 000000, type is join, from "server", msg.to contains ourName
                    // If yes, then take message as room code, MessageBox it
                    // Then close this form and open ChatMainForm.cs
                    if (msg.TableCode == "000000" && msg.type == "join" && msg.from == "server" && msg.to.Contains(OurName) && !msg.message.Contains(ChatCommandExt.ChatCommand.ServerDisconnect.ToString()))
                    {
                        // Split msg.to by - and swap if needed to make sure that first part is user name and second part is opponent user name
                        string[] userNames = msg.to.Split('-');
                        string ourName = userNames[0];
                        string opponentUserName = userNames[1];
                        // Split message for table code and side
                        string[] mess = msg.message.Split('$');
                        string newTableCode = mess[0];
                        string[] userSides = mess[1].Split('-');
                        string Side = userSides[0];
                        string OpponentSide = userSides[1];
                        string timectrl = mess[2];
                        // If user name is not equal to ourName, swap user name and opponent user name
                        if (ourName != OurName)
                        {
                            ourName = userNames[1];
                            opponentUserName = userNames[0];
                            // Swap side as well
                            string temp = Side;
                            Side = OpponentSide;
                            OpponentSide = temp;
                        }
                        // Merge userName and opponentUserName with "-" and pass it to ChatMainForm
                        msg.to = ourName + "-" + opponentUserName;
                        Debug.WriteLine("[CL] Begin pvp: "+ ourName +" vs "+ opponentUserName +" time limit "+ timectrl);
                        Debug.WriteLine("[CL] "+ourName+" Side: " + Side +"- " +opponentUserName +" Side: " + OpponentSide);
                        //MessageBox.Show("Room code: " + msg.message);
                        // Open ChatMainForm with table code and username
                        Console.WriteLine(msg.to , msg.message);
                        isFormExit = true;
                        ChatMainForm chatMainForm = new ChatMainForm(newTableCode, msg.to , chessClient, Side, timectrl);
                        chatMainForm.Show();
                        currentChatMainForm = chatMainForm;
                        isJoined = true;
                        OnJoined(EventArgs.Empty);
                        this.Close();
                        this.Dispose();
                    }else
                    {
                        Debug.WriteLine("[CL] Invalid message: " + msg.message);
                    }
                }

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message, "Warning");
               Console.WriteLine(ex.Message);
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
            // from: ourName
            // to: server
            // message: disconnected
            // date: DateTime.Now
            if (isFormExit)
            {
                return;
            }
            // When user closes the form, send message to server
            ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", OurName, "server", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ClientDisconnect), DateTime.Now);
            comm.SendMessage(message.ToJson());
            comm.ClientClose();
        }
      

        public void JoinWaitingQueueRoom(string ourName, ChessAIClient chClient , bool isCreateRoom = false, string timeCtrl="10|0")
        {
            OurName = ourName;
            chessClient = chClient;
            Debug.WriteLine("JoiningRoom called with user name: " + ourName);
            
            // Check if user name is "server"
            if (ourName == "server")
            {
                Debug.WriteLine("Invalid user name.");
                return;            }

            // Check if name contains special characters
            if (ourName.Any(c => !char.IsLetterOrDigit(c)))
            {
                Debug.WriteLine("User name must not have special character");
                return;
            }

            if (comm == null) return;

            // Send message to server using JSON
            // TableCode: 000000
            // type: join
            // from: ourName.Text
            // to: 
            // message: 
            // date: DateTime.Now

            // this will be classified as normal user if messafe is empty
            string ms1 = isCreateRoom? ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ServerCreateRoom) +timeCtrl:"";
            ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", ourName, "server", ms1, DateTime.Now);
            comm.SendMessage(message.ToJson());
        }

        public void BeginPVPGame(string ourName, string opponentName, ChessAIClient chClient, string timeCtrl = "10|0")
        {
            OurName = ourName;
            chessClient = chClient;
            Debug.WriteLine("Begin pvp : " + ourName +" vs "+ opponentName);

            // Check if user name is "server"
            if (ourName == "server" || opponentName =="server")
            {
                Debug.WriteLine("Invalid user name.");
                return;
            }

            // Check if name contains special characters
            if (ourName.Any(c => !char.IsLetterOrDigit(c)) || opponentName.Any(c => !char.IsLetterOrDigit(c)))
            {
                Debug.WriteLine("User name must not have special character");
                return;
            }

            if (comm == null) return;

            // Send message to server using JSON
            // TableCode: 000000
            // type: join
            // from: ourName.Text
            // to: 
            // message: 
            // date: DateTime.Now

            // this will be classified as normal user if messafe is empty
            string ms1 =  ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ServerBeginGame) + timeCtrl +"@"+ ourName + "-" + opponentName;
            ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", ourName, "server", ms1, DateTime.Now);
            comm.SendMessage(message.ToJson());
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(null, "", "click");
            // Also send message to server
            // TableCode: 000000
            // type: join
            // from: ourName
            // to: server
            // message: cancel
            // date: DateTime.Now
            ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", OurName, "server",ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ClientLeaveRoom), DateTime.Now);
            comm.SendMessage(message.ToJson());
            this.Close();
            this.Dispose();
            if (ParentForm != null)
            {
                ParentForm.LoadForm(new winform_chat.DashboardForm.PvpModeForm(ParentForm));
            } 
        }
    }
}
