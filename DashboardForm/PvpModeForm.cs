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
    private bool isAutoPicking = false;
    private List<PlayerRoom> playerRooms;

    MainScreen ParentForm;
    ChatServerLog serverLog;
    ChessAIClient clientFormOnline;
    ChatClientJoin clientJoin;
    ///<summary>
    /// GAME SETTINGS
    /// </summary>
    private string selectedTimeCtrl = "10|0"; // Default game mode
    private string ourName;

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

    public PvpModeForm(MainScreen ParentF)
    {
        InitializeComponent();
        // Initialize timer
        autoPickTimer = new System.Windows.Forms.Timer();
        autoPickTimer.Interval = 1000; // Set interval to 1 second (1000 ms)
        autoPickTimer.Tick += new EventHandler(Auto_Matching);

        InitializePlayerRooms();

        //Random user name
        Random rnd = new Random();
        ourName = "NullFD" + rnd.Next(1, 1000).ToString();
        srvIP.Text = serverIP;

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
        if (listBoxPlayerRooms.SelectedItem != null)
        {
            PlayerRoom selectedPlayerRoom = (PlayerRoom)listBoxPlayerRooms.SelectedItem;
            Debug.WriteLine("Selected player room: " + selectedPlayerRoom);
            if (selectedPlayerRoom != null)
            {
                if (ParentForm != null)
                {
                    clientJoin = new ChatClientJoin(ParentForm);
                    ParentForm.LoadForm(clientJoin);
                    if (clientFormOnline != null) // clear the old form
                    {
                        clientFormOnline.Close();
                        clientFormOnline.Dispose();
                    }
                    clientFormOnline = new ChessAIClient();
                    //clientFormOnline.Show();
                    clientJoin.JoiningRoom(ourName, clientFormOnline, false, selectedPlayerRoom.GameMode);
                    clientJoin.Joined += ClientJoin_Joined;
                }
            }
        }
    }

    private void InitializePlayerRooms()
    {
        this.playerRooms = new List<PlayerRoom>
        {
           new PlayerRoom("00","Kiên", "10|0","Full"),
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
                string status = playerRoom[3];
                string type = playerRoom[4];
                playerRooms.Add(new PlayerRoom(tableCode,nameOfPlayer,timeCtrl,status));
                Debug.WriteLine("PlayerRoom: " + tableCode +" "+nameOfPlayer+" "+timeCtrl+" "+status);
            }
            else
            {
                Debug.WriteLine("Invalid player room string: " + playerRoomString);
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

    public class PlayerRoom
    {
        public string NameOfPlayer { get; set; }
        public string GameMode { get; set; }
        public string RoomCode { get; set; }
        public string Status_ { get; set; }
        public PlayerRoom(string roomCode, string nameOfPlayer, string gameMode, string status)
        {
            RoomCode = roomCode;
            NameOfPlayer = nameOfPlayer;
            GameMode = gameMode;
            Status_ = status;
            
        }

        public override string ToString()
        {
            return $"{ RoomCode } {NameOfPlayer} {GameMode}" ;
        }
    }


    private void ClientForm_Load(object sender, EventArgs e)
    {
        Thread t = new Thread(connectToServer);
        t.Start();
    }

    private void connectToServer()
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
                    Debug.WriteLine("Received: " + msg.message);
                    // If message contains "USER_LIST", update listview_userQueue
                    if (msg.message.Contains(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.GetUserList)))
                    {
                        msg.message = msg.message.Replace(ChatCommandExt.ToString(ChatCommandExt.ChatCommand.GetUserList), "");
                        Debug.WriteLine("Received: " + msg.message);
                        ParseStringToPlayerRooms(msg.message);
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

    private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        // Send last message to server
        // Server code close connection: {"TableCode": "000000", "type": "join", "from": "server", "to": "server", "message": "close", "date": DateTime.Now}
        ChessAI.ChatServerAndClient.Message msg = new ChessAI.ChatServerAndClient.Message("000000", "join",ourName, "server", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.ClientDisconnect), DateTime.Now);
        comm.SendMessage(msg.ToJson());
        comm.ClientClose();
    }

    private void Auto_Matching(object sender, EventArgs e)
    {
        ChessAI.ChatServerAndClient.Message msg1 = new ChessAI.ChatServerAndClient.Message("000000", "join", ourName,"server", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.AutoMatching) + selectedTimeCtrl, DateTime.Now);
        comm.SendMessage(msg1.ToJson());
    }


    // Auto pick 2 random users from listview
    private void btn_autoJoin_Click(object sender, EventArgs e)
    {
        new SoundFXHandler(null, "", "click");
        // It like Auto_Matching but it will auto pick 2 users from listview
        if (comboBox1.SelectedIndex == -1)
        {
            label3.Visible = true;
            return;
        }
        if (isAutoPicking)
        {
            // Stop auto pick
            autoPickTimer.Stop();
            isAutoPicking = false;
            btn_autoJoin.Text = "🔄 Auto matching";

        }
        else
        {
            // Start auto pick
            autoPickTimer.Start();
            isAutoPicking = true;
            btn_autoJoin.Text = "Cancel matching";
            if (ParentForm != null)
            {
                ParentForm.LoadForm(new ChatClientJoin(ParentForm));
            }
        }

    }

    private void btn_createRoom_Click(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == -1)
        {
            label3.Visible = true;
            return;
        }
        if (ParentForm != null)
        {
            clientJoin = new ChatClientJoin(ParentForm);
            ParentForm.LoadForm(clientJoin);
            
            if(clientFormOnline != null) // clear the old form
            {
                clientFormOnline.Close();
                clientFormOnline.Dispose();
            }
            clientFormOnline = new ChessAIClient();
            //clientFormOnline.Show();
            clientJoin.JoiningRoom(ourName, clientFormOnline, true, selectedTimeCtrl);
            clientJoin.Joined += ClientJoin_Joined;
        }

    }

    private void ClientJoin_Joined(object? sender, EventArgs e)
    {
        if(clientFormOnline != null && clientJoin != null)
        {
            Debug.WriteLine("Client joined!");
            var side = clientJoin.currentChatMainForm.Side;
            var timectrl = clientJoin.currentChatMainForm.timeCtrl;
            clientFormOnline.Show();
            clientFormOnline.SetupGame(NamePlayer: ourName, UserELO: 0, timeCtrl: timectrl, DebugMode: false, setSide: side);
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        label3.Visible = false;
        selectedTimeCtrl = TimeControls.Keys.ToArray()[comboBox1.SelectedIndex];
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void startSvr_Click(object sender, EventArgs e)
    {
        if (serverLog == null)
        {
            serverLog = new ChatServerLog(true); // true = Hide the Code form after load
            serverLog.Show();
            serverLog.Hide();
            startSvr.Text = "Stop Server";
        }
        else
        {
            serverLog.Close();
            startSvr.Text = "Start Server";
            serverLog.Dispose();
            serverLog = null;
        }
        
    }

    private void cntSvr_Click(object sender, EventArgs e)
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
        Constants.SetServerIP(ip);
        srvIP.BackColor = Color.Azure;
        Debug.WriteLine("Server IP: " + Constants.serverIP);
        if (comm != null)
        {
            comm.ClientClose(); // close old connection
        }

        Thread t = new Thread(connectToServer); // reconnect to server
        t.Start();
        if (comm != null)
        {
            cntSvr.Text = "Connected";
            ChessAI.ChatServerAndClient.Message msg1 = new ChessAI.ChatServerAndClient.Message("000000", "join", ourName, "server", ChatCommandExt.ToString(ChatCommandExt.ChatCommand.GetUserList), DateTime.Now);
            comm.SendMessage(msg1.ToJson());
        }
        else
        {
            cntSvr.Text = "Connect";
        }
    }


    private void srvIP_TextChanged(object sender, EventArgs e)
    {
        srvIP.BackColor = Color.Azure;
    }
}


