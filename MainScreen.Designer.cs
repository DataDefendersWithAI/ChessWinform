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
            SideBar.Dock = DockStyle.Left;
            SideBar.Location = new Point(0, 0);
            SideBar.MaximumSize = new Size(235, 688);
            SideBar.MinimumSize = new Size(60, 688);
            SideBar.Name = "SideBar";
            SideBar.Size = new Size(235, 688);
            SideBar.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(230, 75);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(MenuButton);
            panel5.Location = new Point(3, 84);
            panel5.Name = "panel5";
            panel5.Size = new Size(211, 62);
            panel5.TabIndex = 6;
            // 
            // MenuButton
            // 
            MenuButton.FlatStyle = FlatStyle.Flat;
            MenuButton.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MenuButton.Image = (Image)resources.GetObject("MenuButton.Image");
            MenuButton.ImageAlign = ContentAlignment.MiddleLeft;
            MenuButton.Location = new Point(-18, -16);
            MenuButton.Name = "MenuButton";
            MenuButton.Padding = new Padding(30, 0, 0, 0);
            MenuButton.Size = new Size(245, 97);
            MenuButton.TabIndex = 0;
            MenuButton.Text = "Menu";
            MenuButton.UseVisualStyleBackColor = true;
            MenuButton.Click += MenuButton_Click;
            // 
            // HomePanel
            // 
            HomePanel.Controls.Add(HomeButton);
            HomePanel.Location = new Point(3, 152);
            HomePanel.Name = "HomePanel";
            HomePanel.Size = new Size(211, 62);
            HomePanel.TabIndex = 4;
            // 
            // HomeButton
            // 
            HomeButton.FlatStyle = FlatStyle.Flat;
            HomeButton.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HomeButton.Image = (Image)resources.GetObject("HomeButton.Image");
            HomeButton.ImageAlign = ContentAlignment.MiddleLeft;
            HomeButton.Location = new Point(-18, -16);
            HomeButton.Name = "HomeButton";
            HomeButton.Padding = new Padding(30, 0, 0, 0);
            HomeButton.Size = new Size(254, 97);
            HomeButton.TabIndex = 0;
            HomeButton.Text = "Home";
            HomeButton.UseVisualStyleBackColor = true;
            HomeButton.Click += HomeButton_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(ProfileButton);
            panel6.Location = new Point(3, 220);
            panel6.Name = "panel6";
            panel6.Size = new Size(211, 62);
            panel6.TabIndex = 6;
            // 
            // ProfileButton
            // 
            ProfileButton.FlatStyle = FlatStyle.Flat;
            ProfileButton.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProfileButton.Image = (Image)resources.GetObject("ProfileButton.Image");
            ProfileButton.ImageAlign = ContentAlignment.MiddleLeft;
            ProfileButton.Location = new Point(-18, -16);
            ProfileButton.Name = "ProfileButton";
            ProfileButton.Padding = new Padding(30, 0, 0, 0);
            ProfileButton.Size = new Size(264, 97);
            ProfileButton.TabIndex = 0;
            ProfileButton.Text = "Profile";
            ProfileButton.UseVisualStyleBackColor = true;
            ProfileButton.Click += ProfileButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(PvEButton);
            panel1.Location = new Point(3, 288);
            panel1.Name = "panel1";
            panel1.Size = new Size(211, 62);
            panel1.TabIndex = 2;
            // 
            // PvEButton
            // 
            PvEButton.FlatStyle = FlatStyle.Flat;
            PvEButton.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PvEButton.ImageAlign = ContentAlignment.MiddleLeft;
            PvEButton.Location = new Point(-41, -16);
            PvEButton.Name = "PvEButton";
            PvEButton.Size = new Size(277, 97);
            PvEButton.TabIndex = 0;
            PvEButton.Text = "🤖 PvE 🤖 ";
            PvEButton.UseVisualStyleBackColor = true;
            PvEButton.Click += PvEButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(PvPButton);
            panel2.Location = new Point(3, 356);
            panel2.Name = "panel2";
            panel2.Size = new Size(211, 62);
            panel2.TabIndex = 3;
            // 
            // PvPButton
            // 
            PvPButton.FlatStyle = FlatStyle.Flat;
            PvPButton.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PvPButton.ImageAlign = ContentAlignment.MiddleLeft;
            PvPButton.Location = new Point(-50, -16);
            PvPButton.Name = "PvPButton";
            PvPButton.Size = new Size(286, 97);
            PvPButton.TabIndex = 0;
            PvPButton.Text = "⚔ PvP ⚔️";
            PvPButton.UseVisualStyleBackColor = true;
            PvPButton.Click += PvPButton_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(LogoutButton);
            panel7.Location = new Point(3, 424);
            panel7.Name = "panel7";
            panel7.Size = new Size(211, 62);
            panel7.TabIndex = 7;
            // 
            // LogoutButton
            // 
            LogoutButton.FlatStyle = FlatStyle.Flat;
            LogoutButton.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LogoutButton.Image = (Image)resources.GetObject("LogoutButton.Image");
            LogoutButton.ImageAlign = ContentAlignment.MiddleLeft;
            LogoutButton.Location = new Point(-18, -16);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Padding = new Padding(30, 0, 0, 0);
            LogoutButton.Size = new Size(254, 97);
            LogoutButton.TabIndex = 0;
            LogoutButton.Text = "Logout";
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
            MainPanel.Location = new Point(235, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(877, 688);
            MainPanel.TabIndex = 2;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 688);
            Controls.Add(MainPanel);
            Controls.Add(SideBar);
            Name = "MainScreen";
            Text = "MainScreen";
            Load += MainScreen_Load;
            SideBar.ResumeLayout(false);
            SideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            HomePanel.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
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
        private Button LogoutButton;
        private PictureBox pictureBox2;
        private Panel MainPanel;
    }
}