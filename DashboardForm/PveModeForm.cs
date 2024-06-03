using Chess;
using ChessAI;
using ChessAI_Bck;
using System.Diagnostics;
namespace winform_chat.DashboardForm
{

    public partial class PveModeForm : Form
    {
        public event EventHandler ChildPvEButton_Click;
        public int modeDepth;
        private User playerUser;
        private PieceColor selectedSide;
        private string selectedTimeCtrl;

        public static Dictionary<string, string> TimeControls = new Dictionary<string, string>()
        {
            {"♾️", "Default" },
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


        public PveModeForm(User pUser)
        {
            InitializeComponent();
            DoubleBuffered = true;
            Load += PveModeForm_Load;
            if (pUser != null)
            {
                playerUser = pUser;
            }
            else
            {
                playerUser = new User(username: "NotFound" + new Random().Next(999, 9999), elo: 404);
            }
        }

        public void UpdateFomrUI()
        {
            Debug.WriteLine("[PVE] Pve UI updating...");
            Task.Run(() =>
            {
                playerUser = new LoadUserData().GetUserData(playerUser.Username); // update new data
            });
            Invalidate();
        }

        private void PveModeForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Add items to the ComboBox
                comboBox2.Items.Clear();
                foreach (var timeControl in TimeControls)
                {
                    comboBox2.Items.Add($"{timeControl.Key} - {timeControl.Value}");
                }
                comboBox2.SelectedIndex = 0;

                comboBox1.Items.Clear();
                comboBox1.Items.Add("Random");
                comboBox1.Items.Add("White");
                comboBox1.Items.Add("Black");
                comboBox1.SelectedItem = "Random";

                selectedTimeCtrl = "none";
                selectedSide = null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[PVE] Error: {ex.Message}");
            }
        }

        private void Button_Click(object sender, EventArgs e, int depth)
    {
        new SoundFXHandler(null, "", "click");
        modeDepth = depth;
        this.Hide();
        Debug.WriteLine($"[PVE] Starting PVE mode with depth: {modeDepth} side: {selectedSide} time control: {selectedTimeCtrl}");
            var newboard = new ChessAIClient(modeDepth, isOffl: true, pUser: playerUser, setSide: selectedSide, timeCtrl: selectedTimeCtrl);
        newboard.Show();
        this.Show();
    }

    private void BabyButton_Click(object sender, EventArgs e)
    {
        Button_Click(sender, e, 1);
    }

    private void EasyButton_Click(object sender, EventArgs e)
    {
        Button_Click(sender, e, 2);
    }

    private void IntermidiateButton_Click(object sender, EventArgs e)
    {
        Button_Click(sender, e, 4);
    }

    private void HardButton_Click(object sender, EventArgs e)
    {
        Button_Click(sender, e, 6);
    }

    private void EvilButton_Click(object sender, EventArgs e)
    {
        Button_Click(sender, e, 8);
    }

    private void label2_Click(object sender, EventArgs e)
    {
        // Add functionality if needed
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedIndex == 1)
        {
            selectedSide = PieceColor.White;
            label4.ImageKey = "White";
        }
        else if (comboBox1.SelectedIndex == 2)
        {
            selectedSide = PieceColor.Black;
            label4.ImageKey = "Black";
        }
        else
        {
            label4.ImageKey = "Random";
            selectedSide = null;
        }
    }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTimeCtrl = TimeControls.Keys.ToArray()[comboBox2.SelectedIndex];
            if (selectedTimeCtrl == "♾️")
            {
                selectedTimeCtrl = "none";
            }
        }
    }
}
