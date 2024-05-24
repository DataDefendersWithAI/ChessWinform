namespace winform_chat
{
    public partial class MainScreen : Form
    {
        bool sideBarExpanded = false;
        private Form childForm;
        public string username;
        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            var temp = new DashboardForm.HomeForm();
            LoadForm(temp);
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
            MainPanel.Controls.Add(Child);
            MainPanel.Tag = Child;
            Child.BringToFront();
            Child.Show();

        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            var temp = new DashboardForm.HomeForm();
            LoadForm(temp);
            temp.ChildPvEButton_Click += new EventHandler(PvEButton_Click);

        }

        private void PvEButton_Click(object sender, EventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PvPButton_Click(object sender, EventArgs e)
        {

        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            var temp = new DashboardForm.ProfileForm();
            LoadForm(temp);
        }

        
    }
}
