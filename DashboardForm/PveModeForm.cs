using ChessAI;
namespace winform_chat.DashboardForm
{

    public partial class PveModeForm : Form
    {
        public event EventHandler ChildPvEButton_Click;
        public int modeDepth;
        public PveModeForm()
        {
            InitializeComponent();

        }

        private void BabyButton_Click(object sender, EventArgs e)
        {
            modeDepth = 1;
            var newboard = new ChessAIClient(modeDepth, isOffl : true);
            newboard.Show();
        }

        private void EasyButton_Click(object sender, EventArgs e)
        {
            modeDepth = 2;
            var newboard = new ChessAIClient(modeDepth, isOffl: true);
            newboard.Show();
        }

        private void IntermidiateButton_Click(object sender, EventArgs e)
        {
            modeDepth = 4;
            var newboard = new ChessAIClient(modeDepth, isOffl: true);
            newboard.Show();
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            modeDepth = 6;
            var newboard = new ChessAIClient(modeDepth, isOffl: true);
            newboard.Show();
        }

        private void EvilButton_Click(object sender, EventArgs e)
        {
            modeDepth = 8;
            var newboard = new ChessAIClient(modeDepth, isOffl: true);
            newboard.Show();
        }

    }
}
