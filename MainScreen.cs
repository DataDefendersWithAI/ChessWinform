using ChessAI_Bck;
using NAudio.Wave;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace winform_chat
{
    public partial class MainScreen : Form
    {
        bool sideBarExpanded = false;
        private Form currentChildForm;
        private Dictionary<string, Form> hiddenForms = new Dictionary<string, Form>();
        public string username { get; set; }
        public int ELO { get; set; }

        private User playerUser;

        public bool isLoggedOut { get; set;} = false;
        public MainScreen(User pUser = null)
        {
            InitializeComponent();
            DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
           | BindingFlags.Instance | BindingFlags.NonPublic, null,
           MainPanel, new object[] { true });   // Double buffer the panel prevent it from flickering

            playerUser = pUser == null? new User(username: "Player" + new Random().Next(999, 9999), elo: 404):pUser;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            var temp = new DashboardForm.HomeForm(playerUser);
            LoadForm(temp);
            temp.ChildPvEButton_Click += new EventHandler(PvEButton_Click);
            temp.ChildPvPButton_Click += new EventHandler(PvPButton_Click);
        }

        private void SideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sideBarExpanded)
            {
                SideBar.Width -= 20;
                if (SideBar.Width == SideBar.MinimumSize.Width)
                {
                    sideBarExpanded = false;
                    SideBarTimer.Stop();
                }
            }
            else
            {
                SideBar.Width += 20;
                if (SideBar.Width == SideBar.MaximumSize.Width)
                {
                    sideBarExpanded = true;
                    SideBarTimer.Stop();
                }
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            SideBarTimer.Start();
        }

        public void LoadForm(Form child , bool isLogged = true)
        {
            string formKey = child.GetType().Name;
            Debug.WriteLine($"Loading form: {formKey}");

            // Hide current form 
            if (currentChildForm != null)
            {
                currentChildForm.Hide();
            }

            // Show the requested form from the dictionary if it exists, otherwise add it to the dictionary
            if (hiddenForms.ContainsKey(formKey))
            {
                currentChildForm = hiddenForms[formKey];
                currentChildForm.Show();
            }
            else
            {
                currentChildForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
             //   child.Location = new Point((MainPanel.Width - child.Width) / 2, (MainPanel.Height - child.Height) / 2);
                MainPanel.Controls.Add(child);
                MainPanel.Tag = child;
                child.BringToFront();
                child.Show();

                if (isLogged)
                {
                    hiddenForms.Add(formKey, child);
                    Debug.WriteLine($"Added form to dictionary: {formKey} number of forms {hiddenForms.Count}");
                }
            }

            new SoundFXHandler(null, "", "click");
            MainPanel.Invalidate(); // Refresh the MainPanel
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            var temp = new DashboardForm.HomeForm(playerUser);
            LoadForm(temp);
            temp.ChildPvEButton_Click += new EventHandler(PvEButton_Click);
            temp.ChildPvPButton_Click += new EventHandler(PvPButton_Click);
        }

        private void PvEButton_Click(object sender, EventArgs e)
        {
            var temp = new DashboardForm.PveModeForm(playerUser);
            LoadForm(temp);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            isLoggedOut = true;
            this.Close();
        }

        private void PvPButton_Click(object sender, EventArgs e)
        {
            var temp = new DashboardForm.PvpModeForm(this, playerUser);
            LoadForm(temp);
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            var temp = new DashboardForm.ProfileForm(playerUser);
            LoadForm(temp);
        }

        private void historyBtn_Click(object sender, EventArgs e)
        {
            var temp = new DashboardForm.HistoryForm(playerUser);
            LoadForm(temp);
        }

    }
}
