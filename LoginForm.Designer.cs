namespace winform_chat
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            PasswordBox = new TextBox();
            pictureBox4 = new PictureBox();
            ForgetPasswordLink = new LinkLabel();
            SignUpLink = new LinkLabel();
            label3 = new Label();
            label4 = new Label();
            StatusText = new Label();
            LoginButton = new Button();
            pictureBox3 = new PictureBox();
            AccountBox = new TextBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(467, 688);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(662, 82);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(230, 75);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(515, 19);
            label1.Name = "label1";
            label1.Size = new Size(268, 60);
            label1.TabIndex = 2;
            label1.Text = "Welcome to";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(535, 182);
            label2.Name = "label2";
            label2.Size = new Size(470, 60);
            label2.TabIndex = 3;
            label2.Text = "Login to your account";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Azure;
            panel2.Controls.Add(PasswordBox);
            panel2.Controls.Add(pictureBox4);
            panel2.Location = new Point(465, 338);
            panel2.Name = "panel2";
            panel2.Size = new Size(629, 62);
            panel2.TabIndex = 5;
            // 
            // PasswordBox
            // 
            PasswordBox.BackColor = Color.Azure;
            PasswordBox.BorderStyle = BorderStyle.None;
            PasswordBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordBox.ForeColor = SystemColors.ActiveCaption;
            PasswordBox.Location = new Point(131, 17);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(451, 31);
            PasswordBox.TabIndex = 7;
            PasswordBox.Text = "Password";
            PasswordBox.Enter += PasswordBox_Enter;
            PasswordBox.Leave += PasswordBox_Leave;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(125, 62);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // ForgetPasswordLink
            // 
            ForgetPasswordLink.AutoSize = true;
            ForgetPasswordLink.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForgetPasswordLink.Location = new Point(879, 403);
            ForgetPasswordLink.Name = "ForgetPasswordLink";
            ForgetPasswordLink.Size = new Size(212, 29);
            ForgetPasswordLink.TabIndex = 7;
            ForgetPasswordLink.TabStop = true;
            ForgetPasswordLink.Text = "Forget Password";
            ForgetPasswordLink.LinkClicked += ForgetPasswordLink_LinkClicked;
            // 
            // SignUpLink
            // 
            SignUpLink.AutoSize = true;
            SignUpLink.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SignUpLink.Location = new Point(580, 625);
            SignUpLink.Name = "SignUpLink";
            SignUpLink.Size = new Size(99, 29);
            SignUpLink.TabIndex = 8;
            SignUpLink.TabStop = true;
            SignUpLink.Text = "SignUp";
            SignUpLink.LinkClicked += SignUpLink_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(500, 625);
            label3.Name = "label3";
            label3.Size = new Size(79, 29);
            label3.TabIndex = 9;
            label3.Text = "New?";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(674, 625);
            label4.Name = "label4";
            label4.Size = new Size(357, 29);
            label4.TabIndex = 10;
            label4.Text = "- and start playing chess now!";
            // 
            // StatusText
            // 
            StatusText.AutoSize = true;
            StatusText.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StatusText.ForeColor = Color.Red;
            StatusText.Location = new Point(472, 551);
            StatusText.Name = "StatusText";
            StatusText.Size = new Size(408, 32);
            StatusText.TabIndex = 11;
            StatusText.Text = "Current Status: Not logged in";
            // 
            // LoginButton
            // 
            LoginButton.BackgroundImage = (Image)resources.GetObject("LoginButton.BackgroundImage");
            LoginButton.BackgroundImageLayout = ImageLayout.Stretch;
            LoginButton.FlatAppearance.BorderSize = 0;
            LoginButton.FlatStyle = FlatStyle.Flat;
            LoginButton.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginButton.Location = new Point(638, 447);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(254, 78);
            LoginButton.TabIndex = 12;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(125, 62);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // AccountBox
            // 
            AccountBox.BackColor = Color.Azure;
            AccountBox.BorderStyle = BorderStyle.None;
            AccountBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AccountBox.ForeColor = SystemColors.ActiveCaption;
            AccountBox.Location = new Point(131, 15);
            AccountBox.Name = "AccountBox";
            AccountBox.Size = new Size(451, 31);
            AccountBox.TabIndex = 1;
            AccountBox.Text = "Username";
            AccountBox.Enter += AccountBox_Enter;
            AccountBox.Leave += AccountBox_Leave;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Azure;
            panel1.Controls.Add(AccountBox);
            panel1.Controls.Add(pictureBox3);
            panel1.Location = new Point(465, 247);
            panel1.Name = "panel1";
            panel1.Size = new Size(629, 62);
            panel1.TabIndex = 4;
            // 
            // winform_chat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aquamarine;
            ClientSize = new Size(1097, 685);
            Controls.Add(LoginButton);
            Controls.Add(StatusText);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(SignUpLink);
            Controls.Add(ForgetPasswordLink);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "winform_chat";
            Text = "ChessAI";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private Panel panel2;
        private PictureBox pictureBox4;
        private TextBox PasswordBox;
        private LinkLabel ForgetPasswordLink;
        private LinkLabel SignUpLink;
        private Label label3;
        private Label label4;
        private Label StatusText;
        private Button LoginButton;
        private PictureBox pictureBox3;
        private TextBox AccountBox;
        private Panel panel1;
    }
}
