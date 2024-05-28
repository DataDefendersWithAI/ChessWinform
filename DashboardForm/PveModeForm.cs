using ChessAI;
namespace winform_chat.DashboardForm
{

    public partial class PveModeForm : Form
    {
        public event EventHandler ChildPvEButton_Click;
        public int modeDepth;
        public string current_username { get; set; }
        public int ELO { get; set; }
        public PveModeForm()
        {
            InitializeComponent();

        }

        private void BabyButton_Click(object sender, EventArgs e)
        {
            modeDepth = 1;
            this.Hide();
            var newboard = new ChessAIClient(modeDepth, isOffl : true, NamePlayer: current_username, UserELO: ELO);
            newboard.Show();
            this.Show();
        }

        private void EasyButton_Click(object sender, EventArgs e)
        {
            modeDepth = 2;
            this.Hide();
            var newboard = new ChessAIClient(modeDepth, isOffl: true, NamePlayer: current_username, UserELO: ELO);
            newboard.Show();
            this.Show();
        }

        private void IntermidiateButton_Click(object sender, EventArgs e)
        {
            modeDepth = 4;
            this.Hide();
            var newboard = new ChessAIClient(modeDepth, isOffl: true, NamePlayer: current_username, UserELO: ELO);
            newboard.Show();
            this.Show();
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            modeDepth = 6;
            this.Hide();
            var newboard = new ChessAIClient(modeDepth, isOffl: true, NamePlayer: current_username, UserELO: ELO);
            newboard.Show();
            this.Show();
        }

        private void EvilButton_Click(object sender, EventArgs e)
        {
            modeDepth = 8;
            this.Hide();
            var newboard = new ChessAIClient(modeDepth, isOffl: true, NamePlayer: "Player " + current_username, UserELO: ELO);
            newboard.Show();
            this.Show();
        }

    }
}
