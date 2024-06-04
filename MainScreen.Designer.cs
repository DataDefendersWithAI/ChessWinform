namespace winform_chat
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            SideBar = new FlowLayoutPanel();
            pictureBox2 = new PictureBox();
            panel5 = new Panel();
            MenuButton = new Button();
            HomePanel = new Panel();
            HomeButton = new Button();
            panel6 = new Panel();
            ProfileButton = new Button();
            panel1 = new Panel();
            PvEButton = new Button();
            panel2 = new Panel();
            PvPButton = new Button();
            panel7 = new Panel();
            historyBtn = new Button();
            panel3 = new Panel();
            LogoutButton = new Button();
            SideBarTimer = new System.Windows.Forms.Timer(components);
            MainPanel = new Panel();
            SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            HomePanel.SuspendLayout();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // SideBar
            // 
            SideBar.BackColor = SystemColors.Info;
            SideBar.Controls.Add(pictureBox2);
            SideBar.Controls.Add(panel5);
            SideBar.Controls.Add(HomePanel);
            SideBar.Controls.Add(panel6);
            SideBar.Controls.Add(panel1);
            SideBar.Controls.Add(panel2);
            SideBar.Controls.Add(panel7);
            SideBar.Controls.Add(panel3);
            SideBar.Dock = DockStyle.Left;
            SideBar.Location = new Point(0, 0);
            SideBar.Margin = new Padding(3, 2, 3, 2);
            SideBar.MaximumSize = new Size(206, 516);
            SideBar.MinimumSize = new Size(52, 516);
            SideBar.Name = "SideBar";
            SideBar.Size = new Size(206, 516);
            SideBar.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 2);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(230, 75);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(MenuButton);
            panel5.Location = new Point(3, 81);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(185, 46);
            panel5.TabIndex = 6;
            // 
            // MenuButton
            // 
            MenuButton.FlatStyle = FlatStyle.Flat;
            MenuButton.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold);
            MenuButton.Image = (Image)resources.GetObject("MenuButton.Image");
            MenuButton.ImageAlign = ContentAlignment.MiddleLeft;
            MenuButton.Location = new Point(-16, -12);
            MenuButton.Margin = new Padding(3, 2, 3, 2);
            MenuButton.Name = "MenuButton";
            MenuButton.Padding = new Padding(26, 0, 0, 0);
            MenuButton.Size = new Size(214, 73);
            MenuButton.TabIndex = 0;
            MenuButton.Text = "Menu";
            MenuButton.UseVisualStyleBackColor = true;
            MenuButton.Click += MenuButton_Click;
            // 
            // HomePanel
            // 
            HomePanel.Controls.Add(HomeButton);
            HomePanel.Location = new Point(3, 131);
            HomePanel.Margin = new Padding(3, 2, 3, 2);
            HomePanel.Name = "HomePanel";
            HomePanel.Size = new Size(185, 46);
            HomePanel.TabIndex = 4;
            // 
            // HomeButton
            // 
            HomeButton.FlatStyle = FlatStyle.Flat;
            HomeButton.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold);
            HomeButton.Image = (Image)resources.GetObject("HomeButton.Image");
            HomeButton.ImageAlign = ContentAlignment.MiddleLeft;
            HomeButton.Location = new Point(-16, -12);
            HomeButton.Margin = new Padding(3, 2, 3, 2);
            HomeButton.Name = "HomeButton";
            HomeButton.Padding = new Padding(26, 0, 0, 0);
            HomeButton.Size = new Size(222, 73);
            HomeButton.TabIndex = 0;
            HomeButton.Text = "Home";
            HomeButton.UseVisualStyleBackColor = true;
            HomeButton.Click += HomeButton_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(ProfileButton);
            panel6.Location = new Point(3, 181);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(185, 46);
            panel6.TabIndex = 6;
            // 
            // ProfileButton
            // 
            ProfileButton.FlatStyle = FlatStyle.Flat;
            ProfileButton.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold);
            ProfileButton.Image = (Image)resources.GetObject("ProfileButton.Image");
            ProfileButton.ImageAlign = ContentAlignment.MiddleLeft;
            ProfileButton.Location = new Point(-16, -12);
            ProfileButton.Margin = new Padding(3, 2, 3, 2);
            ProfileButton.Name = "ProfileButton";
            ProfileButton.Padding = new Padding(26, 0, 0, 0);
            ProfileButton.Size = new Size(231, 73);
            ProfileButton.TabIndex = 0;
            ProfileButton.Text = "Profile";
            ProfileButton.UseVisualStyleBackColor = true;
            ProfileButton.Click += ProfileButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(PvEButton);
            panel1.Location = new Point(3, 231);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(185, 46);
            panel1.TabIndex = 2;
            // 
            // PvEButton
            // 
            PvEButton.FlatStyle = FlatStyle.Flat;
            PvEButton.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold);
            PvEButton.ImageAlign = ContentAlignment.MiddleLeft;
            PvEButton.Location = new Point(-36, -12);
            PvEButton.Margin = new Padding(3, 2, 3, 2);
            PvEButton.Name = "PvEButton";
            PvEButton.Size = new Size(242, 73);
            PvEButton.TabIndex = 0;
            PvEButton.Text = "🤖 PvE 🤖 ";
            PvEButton.UseVisualStyleBackColor = true;
            PvEButton.Click += PvEButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(PvPButton);
            panel2.Location = new Point(3, 281);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(185, 46);
            panel2.TabIndex = 3;
            // 
            // PvPButton
            // 
            PvPButton.FlatStyle = FlatStyle.Flat;
            PvPButton.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold);
            PvPButton.ImageAlign = ContentAlignment.MiddleLeft;
            PvPButton.Location = new Point(-44, -12);
            PvPButton.Margin = new Padding(3, 2, 3, 2);
            PvPButton.Name = "PvPButton";
            PvPButton.Size = new Size(250, 73);
            PvPButton.TabIndex = 0;
            PvPButton.Text = "⚔ PvP ⚔️";
            PvPButton.UseVisualStyleBackColor = true;
            PvPButton.Click += PvPButton_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(historyBtn);
            panel7.Location = new Point(3, 331);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(185, 46);
            panel7.TabIndex = 7;
            // 
            // historyBtn
            // 
            historyBtn.FlatStyle = FlatStyle.Flat;
            historyBtn.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold);
            historyBtn.ImageAlign = ContentAlignment.MiddleLeft;
            historyBtn.Location = new Point(-36, -11);
            historyBtn.Margin = new Padding(3, 2, 3, 2);
            historyBtn.Name = "historyBtn";
            historyBtn.Size = new Size(242, 73);
            historyBtn.TabIndex = 1;
            historyBtn.Text = "📜History";
            historyBtn.UseVisualStyleBackColor = true;
            historyBtn.Click += historyBtn_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(LogoutButton);
            panel3.Location = new Point(3, 381);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(185, 46);
            panel3.TabIndex = 8;
            // 
            // LogoutButton
            // 
            LogoutButton.FlatStyle = FlatStyle.Flat;
            LogoutButton.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold);
            LogoutButton.ImageAlign = ContentAlignment.MiddleLeft;
            LogoutButton.Location = new Point(-29, -13);
            LogoutButton.Margin = new Padding(3, 2, 3, 2);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(235, 73);
            LogoutButton.TabIndex = 2;
            LogoutButton.Text = "⬅️ Log out";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // SideBarTimer
            // 
            SideBarTimer.Interval = 10;
            SideBarTimer.Tick += SideBarTimer_Tick;
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(206, 0);
            MainPanel.Margin = new Padding(3, 2, 3, 2);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(767, 516);
            MainPanel.TabIndex = 2;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 516);
            Controls.Add(MainPanel);
            Controls.Add(SideBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainScreen";
            Text = "MainScreen";
            FormClosed += MainScreen_FormClosed;
            Load += MainScreen_Load;
            VisibleChanged += MainScreen_VisibleChanged;
            SideBar.ResumeLayout(false);
            SideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            HomePanel.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel SideBar;
        private Panel panel1;
        private Button PvEButton;
        private Panel HomePanel;
        private Button HomeButton;
        private Panel panel2;
        private Button PvPButton;
        private Panel panel5;
        private Button MenuButton;
        private System.Windows.Forms.Timer SideBarTimer;
        private Panel panel6;
        private Button ProfileButton;
        private Panel panel7;
        private PictureBox pictureBox2;
        private Panel MainPanel;
        private Button historyBtn;
        private Button LogoutButton;
        private Panel panel3;
    }
}