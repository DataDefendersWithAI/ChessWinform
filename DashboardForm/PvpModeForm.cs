using ChessAI.ChatServerAndClient;
using System.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ChessAI;
using System.Diagnostics;
using ChessAI_Bck;
using winforms_chat;

namespace winform_chat.DashboardForm;




public partial class PvpModeForm : Form
{

    // Variables
    private Communication comm;
    // Constants
    string serverIP = ChessAI.ChatServerAndClient.Constants.serverIP;
    int serverPort = ChessAI.ChatServerAndClient.Constants.serverPort;

    private System.Windows.Forms.Timer autoPickTimer;
    private List<PlayerRoom> playerRooms;
    private Thread t;

    MainScreen ParentForm;
    ChatServerLog serverLog;
    ChessAIClient chessAIClientFormOnline;
    ChatClientJoin clientJoin;
    ChatMainForm currentChatMainForm; 

    User playerUser;
    User opponentUser;
    ///<summary>
    /// GAME SETTINGS
    /// </summary>
    private string selectedTimeCtrl = "10|0"; // Default game mode
    private string OurName;
    private bool isAutoMatching = false;
    private bool isConnectedToServer = false;
    private bool isServer;

    // Predefined array of time control strings
    public static Dictionary<string, string> TimeControls = new Dictionary<string, string>()
    {

        { "1|0", "Blitz"},   // 1 minute, no increment
        { "3|0", "Blitz"},    // 3 minutes, no increment
        { "5|0", "Blitz"},    // 5 minutes, no increment
        { "10|0", "Rapid"},   // 10 minute, no increment
        { "10|5", "Rapid"},   // 10 minutes, 5 seconds increment
        { "15|0", "Rapid"},   // 15 minutes, no increment
        { "30|0", "Rapid"},   // 30 minutes, no increment   
        { "15|10", "Rapid"},  // 15 minutes, 10 seconds increment
        { "30|20", "Rapid"},  // 30 minutes, 20 seconds increment
        { "60|0", "Classical"},// 60 minutes, no increment
        { "60|30", "Classical"},// 60 minutes, 30 seconds increment
        { "90|30", "Classical"},// 90 minutes, 30 seconds increment
        { "120|60", "Classical"},// 120 minutes, 60 seconds increment
    };
    public class PlayerRoom
    {
        public string NameOfPlayer { get; set; }
        public string GameMode { get; set; }
        public string RoomCode { get; set; }
        public string Status_ { get; set; }

        public string ELO { get; set; }
        public PlayerRoom(string roomCode, string nameOfPlayer, string gameMode, string status, string elo)
        {
            RoomCode = roomCode;
            NameOfPlayer = nameOfPlayer;
            GameMode = gameMode;
            Status_ = status;
            ELO = elo;
        }

        public override string ToString()
        {
            return $"{NameOfPlayer} [{ELO}] - {GameMode}";
        }
    }

    public PvpModeForm(MainScreen ParentF, User pUser = null)
    {
        InitializeComponent();
        // Initialize timer
        autoPickTimer = new System.Windows.Forms.Timer();
        autoPickTimer.Interval = 1000; // Set interval to 1 second (1000 ms)
        autoPickTimer.Tick += new EventHandler(Auto_Matching);

        log1.Visible = false;
        label3.Visible = false;

        InitializePlayerRooms();
        DoubleBuffered = true;
        if (pUser != null)
        {
            playerUser = pUser;
        }
        else
        {
            playerUser = new User(username: "NotFound" + new Random().Next(999, 9999), elo: 404);
        }

        OurName = playerUser.Username;

        srvIP.Text = serverIP;
        cntSvr.BackColor = Color.LightGray;
        strSvr.BackColor = Color.LightGray;
        label5.Text = OurName;

        FillListBoxPlayerRooms();
        // Add items to the ComboBox
        foreach (var timeControl in TimeControls)
        {
            comboBox1.Items.Add($"{timeControl.Key} - {timeControl.Value}");
        }
        comboBox1.SelectedIndex = 3;

        listBoxPlayerRooms.Click += listBoxPlayerRooms_Click;

        ParentForm = ParentF;

    }

    private void listBoxPlayerRooms_Click(object sender, EventArgs e)
    {
        if (isServer) return;
        if (listBoxPlayerRooms.SelectedItem != null)
        {
            PlayerRoom selectedPlayerRoom = (PlayerRoom)listBoxPlayerRooms.SelectedItem;
            Debug.WriteLine("[CL] Selected player room: " + selectedPlayerRoom);
            if (selectedPlayerRoom != null)
            {
                if (ParentForm != null)
                {
                    openJoiningForm();

                    if (chessAIClientFormOnline != null) // clear the old form
                    {
                        chessAIClientFormOnline.Close();
                        chessAIClientFormOnline.Dispose();
                    }
                    chessAIClientFormOnline = new ChessAIClient(setUpGame: false);
                    //chessAIClientFormOnline.Show();
                    if(clientJoin == null)
                    {
                        Debug.WriteLine("ClientJoin is null");
                        return;
                    }
                    opponentUser = new User(username: selectedPlayerRoom.NameOfPlayer, elo: 404);
                    BeginPVPGame();
                }
            }
        }
    }

    private void InitializePlayerRooms()
    {
        this.playerRooms = new List<PlayerRoom>
        {
           
        };
    }

    private void ParseStringToPlayerRooms(string playerRoomsString)
    {
        // Clear the current list of player rooms
        playerRooms.Clear();

        // Split the input string into individual player room entries
        string[] playerRoomStrings = playerRoomsString.Split('~'); // Split by "~" for each row of data

        // Iterate through each player room string
        foreach (var playerRoomString in playerRoomStrings)
        {
            // Split the player room string into its components (e.g., player name, game mode, status, etc.)
            string[] playerRoom = playerRoomString.Split('#'); // Split by "#" for each component

            // Ensure there are enough components in the player room string
            if (playerRoom.Length >= 3)
            {
                // Add a new PlayerRoom object to the list
                string tableCode = playerRoom[0];
                string nameOfPlayer = playerRoom[1];
                string timeCtrl = playerRoom[2];
                string ELO = playerRoom[3];
                string status = playerRoom[4];
                string type = playerRoom[5];

                playerRooms.Add(new PlayerRoom(tableCode, nameOfPlayer, timeCtrl, status, ELO ));
                Debug.WriteLine("[CL] PlayerRoom: " + tableCode + " " + nameOfPlayer + " " + timeCtrl + " " + status);
            }
            else
            {
                Debug.WriteLine("[CL] Invalid player room string: " + playerRoomString);
            }
        }

        // Update the ListBox with the new list of player rooms
        FillListBoxPlayerRooms();
    }

    private void FillListBoxPlayerRooms()
    {
        if (InvokeRequired)
        {
            // Ensure we are updating the ListBox on the UI thread
            Invoke(new Action(FillListBoxPlayerRooms));
            return;
        }

        listBoxPlayerRooms.Items.Clear();
        foreach (var playerRoom in playerRooms)
        {
            listBoxPlayerRooms.Items.Add(playerRoom);
        }
    }


    private void ClientForm_Load(object sender, EventArgs e)
    {
        Debug.WriteLine("[CL] ClientForm Loaded");
    }

    private void connectToServer()
    {
        try
        {
            comm = new Communication(serverIP, serverPort, LogMessage);
            comm.ClientLoad();

            if (comm != null)
            {
                ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", OurName, "server", "Hello server from " + OurName, DateTime.Now);
                isConnectedToServer = comm.SendMessage(message.ToJson());
            }
            if (!isConnectedToServer)
            {
                Debug.WriteLine("[CL] Server is not available");
            }
            else
            {
                Debug.WriteLine("[CL] ok");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("[CL] Err in attempt to connect");
            Debug.WriteLine(ex.Message);
        }
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

            // If message is not valid JSON, return
            if (!message.Contains("TableCode") || !message.Contains("type") || !message.Contains("from") || !message.Contains("to") || !message.Contains("message") || !message.Contains("date"))
            {
                return;
            }

            // Extract message from JSON
            ChessAI.ChatServerAndClient.Message msg = ChessAI.ChatServerAndClient.Message.FromJson(message);
            if (msg != null)
            {
                // Check if message is correct format: Join the chat: {"TableCode": "000000", "type": "update", "from": "server", "to": "all", "message": "", "date": DateTime.Now}
                if (msg.type == "update" && msg.TableCode == "000000")
                {
                    // If message contains "USER_LIST", update listview_userQueue
                    if (msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.GetUserList)))
                    {
                        msg.message = msg.message.Replace(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.GetUserList), "");
                        ParseStringToPlayerRooms(msg.message);
                    }
                }
                else if (msg.type == "join" && msg.TableCode == "000000" && msg.from == "server")
                {
                    if (msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ServerDisconnect)))
                    {
                        // Server code close connection: {"TableCode": "000000", "type": "join", "from": "server", "to": "server", "message": "close", "date": DateTime.Now}
                        Debug.WriteLine("[CL]: Server disconnected!");
                        isConnectedToServer = false;
                        Thread.Sleep(1000);
                        cntSvr_Click(null, null);
                    }
                    else if (msg.to.Contains(OurName) && !msg.message.Contains(ChatCommandExt.ChatCommand.ServerDisconnect.ToString()))
                    {
                        Debug.WriteLine("[CL] Game begin with " + msg.to);
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
                        Debug.WriteLine("[CL] Begin pvp: " + ourName + " vs " + opponentUserName + " time limit " + timectrl);
                        Debug.WriteLine("[CL] " + ourName + " Side: " + Side + "- " + opponentUserName + " Side: " + OpponentSide);
                        //MessageBox.Show("Room code: " + msg.message);
                        // Open ChatMainForm with table code and username
                        ChatMainForm chatMainForm = new ChatMainForm(newTableCode, msg.to, chessAIClientFormOnline, Side, timectrl);
                        chatMainForm.Show();

                        currentChatMainForm = chatMainForm;
                        ClientJoin_Joined();
                    }
                }
                else
                {
                    Debug.WriteLine("[CL] Message not proccessed: "+ msg.from +" - "+ msg.to+" - "+ msg.message);
                }
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message, "Warning");
            Debug.WriteLine(ex.Message);
        }

    }

    private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        if (comm == null) return;
        // Send last message to server
        // Server code close connection: {"TableCode": "000000", "type": "join", "from": "server", "to": "server", "message": "close", "date": DateTime.Now}
        ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message("000000", "join", OurName, "server", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ClientDisconnect), DateTime.Now);
        isConnectedToServer = comm.SendMessage(msg.ToJson());
        comm.ClientClose();
    }

    private void Auto_Matching(object sender, EventArgs e)
    {
        if (comm == null) return;
        ChessAI.ChatServerAndClient.Message msg1 = new ChessAI.ChatServerAndClient.Message("000000", "join", OurName, "server", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.AutoMatching) + selectedTimeCtrl, DateTime.Now);
        isConnectedToServer = comm.SendMessage(msg1.ToJson());
    }


    // Auto pick 2 random users from listview
    private void btn_autoJoin_Click(object sender, EventArgs e)
    {
        new SoundFXHandler(null, "", "click");
        // It like Auto_Matching but it will auto pick 2 users from listview
        if (comboBox1.SelectedIndex == -1)
        {
            label3.Text = "Please select a game mode!";
            label3.Visible = true;
            return;
        }
        if (isAutoMatching)
        {
            // Stop auto pick
            autoPickTimer.Stop();
            isAutoMatching = false;
            btn_autoJoin.Text = "🔄 Auto matching";

        }
        else
        {
            // Start auto pick
            autoPickTimer.Start();
            isAutoMatching = true;
            btn_autoJoin.Text = "Cancel matching";
            if (ParentForm != null)
            {
                openJoiningForm();
            }
        }

    }

    private void waitingForJoiningGame()
    {
        if (comboBox1.SelectedIndex == -1)
        {
            label3.Text = "Please select a game mode!";
            label3.Visible = true;
            return;
        }

        if (ParentForm != null)
        {
            openJoiningForm();

            if (chessAIClientFormOnline != null) // clear the old form
            {
                chessAIClientFormOnline.Close();
                chessAIClientFormOnline.Dispose();
            }

            chessAIClientFormOnline = new ChessAIClient(setUpGame: false);
            //chessAIClientFormOnline.Show();
           if (clientJoin == null)
            {
                Debug.WriteLine("ClientJoin is null");
                return;
            }
            JoinWaitingQueueRoom();
        }
    }

    public void JoinWaitingQueueRoom(bool isCreateRoom = true)
    {
        if (chessAIClientFormOnline == null)
        {
            Debug.WriteLine("Chess client is null");
            return;
        }
        Debug.WriteLine("JoiningRoom called by : " + OurName);

        // Check if user name is "server"
        if (OurName == "server")
        {
            Debug.WriteLine("Invalid user name.");
            return;
        }

        // Check if name contains special characters
        if (OurName.Any(c => !char.IsLetterOrDigit(c)))
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
        string ms1 = isCreateRoom ? ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ServerCreateRoom) + selectedTimeCtrl +"@"+playerUser.ELO: "" + "@" + playerUser.ELO;
        ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", OurName, "server", ms1, DateTime.Now);
        isConnectedToServer = comm.SendMessage(message.ToJson());
    }
    public void BeginPVPGame()
    {
        if(opponentUser == null)
        {
            Debug.WriteLine("Opponent user is null");
            return;
        }

        Debug.WriteLine("Begin pvp : " + OurName + " vs " + opponentUser.Username);

        // Check if user name is "server"
        if (OurName == "server" || opponentUser.Username == "server")
        {
            Debug.WriteLine("Invalid user name.");
            return;
        }

        // Check if name contains special characters
        if (OurName.Any(c => !char.IsLetterOrDigit(c)) || opponentUser.Username.Any(c => !char.IsLetterOrDigit(c)))
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
        string ms1 = ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ServerBeginGame) + selectedTimeCtrl + "@" + OurName + "-" + opponentUser.Username;
        ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", OurName, "server", ms1, DateTime.Now);
        isConnectedToServer = comm.SendMessage(message.ToJson());
    }

    private void btn_createRoom_Click(object sender, EventArgs e)
    {
        waitingForJoiningGame();
    }

    private void ClientJoin_Joined()
    {
        if (chessAIClientFormOnline != null && clientJoin != null)
        {
            Debug.WriteLine("Client joined!");

            if (currentChatMainForm == null) return;

            var side = currentChatMainForm.Side;
            var timectrl = currentChatMainForm.timeCtrl;
            chessAIClientFormOnline.Show();

            opponentUser = opponentUser == null ? new User(username: currentChatMainForm.opponentUserName, elo: currentChatMainForm.opponentElo): opponentUser;

            chessAIClientFormOnline.SetupGame(pUser: playerUser, oUser: opponentUser, timeCtrl: timectrl, side: side, chatMainForm: currentChatMainForm);
            ParentForm.Hide();
           // chessAIClientFormOnline.FormClosing += ChessAIClientFormOnline_FormClosing;
            currentChatMainForm.FormClosing += currentChatMainForm_FormClosing;

            clientJoin.Close();
            clientJoin.Dispose();
        }
    }

    private void ChessAIClientFormOnline_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (ParentForm != null)
        {
            ParentForm.Show();
            if (currentChatMainForm != null)
            {
                currentChatMainForm.Close();
                currentChatMainForm.Dispose();
            }
        }
    }
    private void currentChatMainForm_FormClosing(object sender , FormClosingEventArgs e)
    {
        if (ParentForm != null)
        {
            ParentForm.Show();
            if (chessAIClientFormOnline != null)
            {
                chessAIClientFormOnline.Close();
                chessAIClientFormOnline.Dispose();
            }
        }
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        label3.Visible = false;
        selectedTimeCtrl = TimeControls.Keys.ToArray()[comboBox1.SelectedIndex];
    }

    private void VerifyAndSetIP()
    {
        var ip = srvIP.Text;

        // Check if ip is empty
        if (string.IsNullOrWhiteSpace(ip))
        {
            srvIP.BackColor = Color.Salmon;
            return;
        }

        // Split IP into parts and check length
        var parts = ip.Split('.');
        if (parts.Length != 4)
        {
            srvIP.BackColor = Color.Salmon;
            return;
        }

        // Validate each part of the IP address
        foreach (var part in parts)
        {
            if (!int.TryParse(part, out int num) || num < 0 || num > 255)
            {
                srvIP.BackColor = Color.Salmon;
                return;
            }
        }

        // If IP is valid, update Constants and reset background color
        serverIP = ip;
        srvIP.BackColor = Color.Azure;
    }

    private async void cntSvr_Click(object sender, EventArgs e)
    {
        cntSvr.Enabled = false;
        log1.Visible = false;
        isServer = false;
        uiClientRefresh();
        VerifyAndSetIP();

        if (comm != null)
        {
            comm.ClientClose(); // close old connection
            comm = null;
        }

        cntSvr.Text = "Connecting...";
        cntSvr.BackColor = Color.PaleGoldenrod;

        var cts = new CancellationTokenSource();
        var token = cts.Token;

        try
        {
            var connectionTask = Task.Run(() =>
            {
                t = new Thread(connectToServer);
                t.IsBackground = true;
                t.Start();

                // Poll for connection status
                while (!isConnectedToServer && !token.IsCancellationRequested)
                {
                    Thread.Sleep(500);
                }

            }, token);

            if (await Task.WhenAny(connectionTask, Task.Delay(5000, token)) == connectionTask)
            {
                if (isConnectedToServer)
                {
                    Debug.WriteLine("Server IP: " + serverIP);
                    cntSvr.Text = "Connected";
                    cntSvr.BackColor = Color.PaleGreen;

                    var msg1 = new ChessAI.ChatServerAndClient.Message("000000", "update", OurName, "server", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.GetUserList),DateTime.Now );
                    isConnectedToServer = comm.SendMessage(msg1.ToJson());
                    cntSvr.Enabled = true;
                }
                else
                {
                    cntSvr.Text = "Connect server";
                    cntSvr.BackColor = Color.LightGray;
                    log1.Text = "Cannot connect to server!";
                    log1.Visible = true;
                    cntSvr.Enabled = true;
                }
            }
            else
            {
                cts.Cancel(); // Cancel the connection attempt if timeout occurs
                cntSvr.Text = "Connect server";
                cntSvr.BackColor = Color.LightGray;
                log1.Text = "Connection timeout!";
                log1.Visible = true;
                cntSvr.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            log1.Text = "Cannot connect to server!";
            log1.Visible = true;
            Debug.WriteLine("Error: " + ex.Message);
        }

        if (clientJoin != null) // clear client join form before (re)connecting
        {
            clientJoin.Close();
            clientJoin.Dispose();
            clientJoin = null;
        }

    }



    private void srvIP_TextChanged(object sender, EventArgs e)
    {
        srvIP.BackColor = Color.Azure;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        //refresh
        if (comm != null)
        {
            ChessAI.ChatServerAndClient.Message msg1 = new ChessAI.ChatServerAndClient.Message("000000", "update", OurName, "server", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.GetUserList), DateTime.Now);
            isConnectedToServer = comm.SendMessage(msg1.ToJson());
        }
    }

    private void strSvr_Click(object sender, EventArgs e)
    {
        isServer = true;
        uiClientRefresh();
        VerifyAndSetIP();

        if (serverLog != null)
        {
            // clean the old one
            serverLog.Close();
            serverLog.Dispose();
            serverLog = null;
            strSvr.Text = "Start server";
            strSvr.BackColor = Color.LightGray;
        }
        else
        {
            // create new server log
            serverLog = new ChatServerLog(false); // true = Hide the Code form after load
            serverLog.Show();
            serverLog.Hide();
            strSvr.Text = "Stop server";
            strSvr.BackColor = Color.LightCoral;
        }
    }

    private void uiClientRefresh()
    {
        if (isServer)
        {
            cntSvr.Visible = false;
            btn_createRoom.Visible = false;
            btn_autoJoin.Visible = false;
            comboBox1.Visible = false;
            label1.Text = "Room list";

            label3.Text = "You are now a server!";
            label3.Visible = true;
        }
        else
        {
            strSvr.Visible = false;
            label3.Text = "You are now a client!";
            label3.Visible = true;

            btn_createRoom.Visible = true;
            btn_autoJoin.Visible = true;
            comboBox1.Visible = true;
            label1.Text = "Select room";
        }
    }

    private void openJoiningForm()
    {
        if (clientJoin != null) // Dispose the old form
        {
            clientJoin.Close();
            clientJoin.Dispose();
            clientJoin = null;
        }

        clientJoin = new ChatClientJoin(isConnectedToServer);
        ParentForm.LoadForm(clientJoin, isLogged: false);
        clientJoin.FormClosing += ClientJoin_FormClosing;
    }
    private void ClientJoin_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Send last message to server
        // TableCode: 000000
        // type: join
        // from: ourName
        // to: server
        // message: disconnected
        // date: DateTime.Now
        if (ParentForm != null)
        {
            var temp = new winform_chat.DashboardForm.PvpModeForm(ParentForm);
            ParentForm.LoadForm(temp);
        }

        if (comm == null) return;
        // When user closes the form, send message to server
        ChessAI.ChatServerAndClient.Message message = new ChessAI.ChatServerAndClient.Message("000000", "join", OurName, "server", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ClientDisconnect), DateTime.Now);
        isConnectedToServer = comm.SendMessage(message.ToJson());
        comm.ClientClose();
    }

   

}


