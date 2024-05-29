using ChessAI_Bck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_chat.DashboardForm
{

    public partial class HomeForm : Form
    {
        public event EventHandler ChildPvEButton_Click;
        public event EventHandler ChildPvPButton_Click;
        public string current_username { get; set; }
        public HomeForm()
        {
            InitializeComponent();

        }

        private void PvEButton_Click(object sender, EventArgs e)
        {
            ChildPvEButton_Click?.Invoke(this, e);
            new SoundFXHandler(null, "", "click");
        }

        private void PvPButton_Click(object sender, EventArgs e)
        {
            ChildPvPButton_Click?.Invoke(this, e);
            new SoundFXHandler(null, "", "click");
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            DisplayText.AutoSize = false;
            DisplayText.Size = new Size(350,210);
            DisplayText.Text = "Welcome " + current_username + ", " + "please choose your playmode";

        }
    }
}
