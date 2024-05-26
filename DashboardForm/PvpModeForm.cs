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
        autoPickTimer.Interval = 500; // Set interval to 1 second (1000 ms)
        autoPickTimer.Tick += btn_joinRandom_Click;
        InitializePlayerRooms();
        FillListBoxPlayerRooms();
        // Add items to the ComboBox
        foreach (var timeControl in TimeControls)
        {
            comboBox1.Items.Add($"{timeControl.Key} - {timeControl.Value}");
        }
        comboBox1.SelectedIndex = 3;

        // Add column name "Code" and "Player"
        listview_userQueue.View = View.Details;
        listview_userQueue.Columns.Add("Code", 50);
        listview_userQueue.Columns.Add("Player", 100);
        
        ParentForm = ParentF;
        
    }

    private void InitializePlayerRooms()
    {
        this.playerRooms = new List<PlayerRoom>
        {
           new PlayerRoom("Kiên", "10|0"),
           new PlayerRoom("Phong", "15|0"),
           new PlayerRoom("Thành", "15|15")
        };
    }

    private void ParseStringToPlayerRooms(string playerRoomsString)
    {
        playerRooms.Clear();
        string[] playerRoomStrings = playerRoomsString.Split('~'); // Split by "~"
        foreach (var playerRoomString in playerRoomStrings)
        {
            string[] playerRoom = playerRoomString.Split('#'); // Split by "#"/ player name, game mode
            playerRooms.Add(new PlayerRoom(playerRoom[0], playerRoom[1]));
        }
        FillListBoxPlayerRooms();
    }

    private void FillListBoxPlayerRooms()
    {
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

        public PlayerRoom(string nameOfPlayer, string gameMode)
        {
            NameOfPlayer = nameOfPlayer;
            GameMode = gameMode;
        }

        public override string ToString()
        {
            return $"Player: {NameOfPlayer}, Game Mode: {GameMode}";
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
                    // If message contains "USER_LIST", update listview_userQueue
                    if (msg.message.Contains("USER_LIST#*"))
                    {
                        msg.message = msg.message.Replace("USER_LIST#*", "");
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


            ChessAI.ChatServerAndClient.Message msg1 = new ChessAI.ChatServerAndClient.Message("000000", "join", "server", player1 + "-" + player2, newTableCode + "$" + userSide + "-" + oppSide, DateTime.Now);
            comm.SendMessage(msg1.ToJson());

        }
    }


    // Auto pick 2 random users from listview
    private void btn_autoJoin_Click(object sender, EventArgs e)
    {
        // It like btn_joinRandom_Click but it will auto pick 2 users from listview
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
                ParentForm.LoadForm(new PvpWaitingForm(ParentForm));
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
        if(ParentForm != null)
        {
            ParentForm.LoadForm(new PvpWaitingForm(ParentForm));
        }
        
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        label3.Visible = false;
    }
}


