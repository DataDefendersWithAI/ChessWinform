using ChessAI_Bck;
namespace winform_chat
{
    public partial class MainScreen : Form
    {
        bool sideBarExpanded = false;
        private Form childForm;
        public string username { get; set;}
        public int ELO { get; set; }
        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            var temp = new DashboardForm.HomeForm();
            temp.current_username = username;
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
            new SoundFXHandler(null,"","click");
            SideBarTimer.Start();
        }

        public void LoadForm(Form Child)
        {
            if (childForm != null)
            {
                childForm.Close();
            }
            childForm = Child;
            Child.TopLevel = false;
            Child.FormBorderStyle = FormBorderStyle.None;
            Child.Dock = DockStyle.Fill;
           // make the child form center
            Child.Location = new Point((MainPanel.Width - Child.Width) / 2, (MainPanel.Height - Child.Height) / 2);
            MainPanel.Controls.Add(Child);
            MainPanel.Tag = Child;
            Child.BringToFront();
            Child.Show();
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(null, "", "click");
            var temp = new DashboardForm.HomeForm();
            temp.current_username = username;
            LoadForm(temp);
            temp.ChildPvEButton_Click += new EventHandler(PvEButton_Click);
            temp.ChildPvPButton_Click += new EventHandler(PvPButton_Click);

        }

        private void PvEButton_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(null, "", "click");
            var temp = new DashboardForm.PveModeForm();
            temp.current_username = username;
            temp.ELO = ELO;
            LoadForm(temp);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(null, "", "click");
            this.Close();
        }

        private void PvPButton_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(null, "", "click");
            var temp = new DashboardForm.PvpModeForm(this);
            LoadForm(temp);
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            new SoundFXHandler(null, "", "click");
            var temp = new DashboardForm.ProfileForm();
            LoadForm(temp);
        }

        
    }
}
