using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            var newboard = new SpawnServerAndClient(modeDepth);
            newboard.Show();
        }

        private void EasyButton_Click(object sender, EventArgs e)
        {
            modeDepth = 2;
            var newboard = new SpawnServerAndClient(modeDepth);
            newboard.Show();
        }

        private void IntermidiateButton_Click(object sender, EventArgs e)
        {
            modeDepth = 4;
            var newboard = new SpawnServerAndClient(modeDepth);
            newboard.Show();
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            modeDepth = 6;
            var newboard = new SpawnServerAndClient(modeDepth);
            newboard.Show();
        }

        private void EvilButton_Click(object sender, EventArgs e)
        {
            modeDepth = 8;
            var newboard = new SpawnServerAndClient(modeDepth);
            newboard.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //private void PvEButton_Click(object sender, EventArgs e)
        //{
        //    ChildPvEButton_Click?.Invoke(this, e);
        //}

        //private void PvPButton_Click(object sender, EventArgs e)
        //{

        //}

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}
    }
}
