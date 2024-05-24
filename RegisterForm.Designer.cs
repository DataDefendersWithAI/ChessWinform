namespace winform_chat
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            PasswordBox = new TextBox();
            AccountBox = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            StatusText = new Label();
            panel2 = new Panel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            EmailBox = new TextBox();
            pictureBox5 = new PictureBox();
            panel4 = new Panel();
            ReTypePasswordBox = new TextBox();
            pictureBox6 = new PictureBox();
            label3 = new Label();
            SignInLink = new LinkLabel();
            label4 = new Label();
            panel5 = new Panel();
            OTPBox = new TextBox();
            pictureBox7 = new PictureBox();
            RegisterButton = new Button();
            OTPButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // PasswordBox
            // 
            PasswordBox.BackColor = Color.Azure;
            PasswordBox.BorderStyle = BorderStyle.None;
            PasswordBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordBox.ForeColor = SystemColors.InactiveCaption;
            PasswordBox.Location = new Point(131, 17);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(451, 31);
            PasswordBox.TabIndex = 7;
            PasswordBox.Text = "Enter password";
            PasswordBox.Enter += PasswordBox_Enter;
            PasswordBox.Leave += PasswordBox_Leave;
            // 
            // AccountBox
            // 
            AccountBox.BackColor = Color.Azure;
            AccountBox.BorderStyle = BorderStyle.None;
            AccountBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AccountBox.ForeColor = SystemColors.InactiveCaption;
            AccountBox.Location = new Point(131, 15);
            AccountBox.Name = "AccountBox";
            AccountBox.Size = new Size(451, 31);
            AccountBox.TabIndex = 1;
            AccountBox.Text = "Enter username";
            AccountBox.Enter += AccountBox_Enter;
            AccountBox.Leave += AccountBox_Leave;
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
            // StatusText
            // 
            StatusText.AutoSize = true;
            StatusText.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StatusText.ForeColor = Color.Red;
            StatusText.Location = new Point(411, 628);
            StatusText.Name = "StatusText";
            StatusText.Size = new Size(440, 36);
            StatusText.TabIndex = 23;
            StatusText.Text = "Current Status: Not Logged In";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Azure;
            panel2.Controls.Add(PasswordBox);
            panel2.Controls.Add(pictureBox4);
            panel2.Location = new Point(411, 336);
            panel2.Name = "panel2";
            panel2.Size = new Size(594, 62);
            panel2.TabIndex = 17;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Azure;
            panel1.Controls.Add(AccountBox);
            panel1.Controls.Add(pictureBox3);
            panel1.Location = new Point(411, 200);
            panel1.Name = "panel1";
            panel1.Size = new Size(594, 62);
            panel1.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(442, 144);
            label2.Name = "label2";
            label2.Size = new Size(524, 60);
            label2.TabIndex = 15;
            label2.Text = "Register to your account";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(423, 3);
            label1.Name = "label1";
            label1.Size = new Size(268, 60);
            label1.TabIndex = 14;
            label1.Text = "Welcome to";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(570, 66);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(230, 75);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(410, 717);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Azure;
            panel3.Controls.Add(EmailBox);
            panel3.Controls.Add(pictureBox5);
            panel3.Location = new Point(411, 268);
            panel3.Name = "panel3";
            panel3.Size = new Size(594, 62);
            panel3.TabIndex = 24;
            // 
            // EmailBox
            // 
            EmailBox.BackColor = Color.Azure;
            EmailBox.BorderStyle = BorderStyle.None;
            EmailBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EmailBox.ForeColor = SystemColors.InactiveCaption;
            EmailBox.Location = new Point(131, 15);
            EmailBox.Name = "EmailBox";
            EmailBox.Size = new Size(451, 31);
            EmailBox.TabIndex = 1;
            EmailBox.Text = "Enter email";
            EmailBox.Enter += EmailBox_Enter;
            EmailBox.Leave += EmailBox_Leave;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(0, 0);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(125, 62);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Azure;
            panel4.Controls.Add(ReTypePasswordBox);
            panel4.Controls.Add(pictureBox6);
            panel4.Location = new Point(411, 404);
            panel4.Name = "panel4";
            panel4.Size = new Size(594, 62);
            panel4.TabIndex = 25;
            // 
            // ReTypePasswordBox
            // 
            ReTypePasswordBox.BackColor = Color.Azure;
            ReTypePasswordBox.BorderStyle = BorderStyle.None;
            ReTypePasswordBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ReTypePasswordBox.ForeColor = SystemColors.InactiveCaption;
            ReTypePasswordBox.Location = new Point(131, 17);
            ReTypePasswordBox.Name = "ReTypePasswordBox";
            ReTypePasswordBox.Size = new Size(451, 31);
            ReTypePasswordBox.TabIndex = 7;
            ReTypePasswordBox.Text = "Retype password";
            ReTypePasswordBox.Enter += ReTypePasswordBox_Enter;
            ReTypePasswordBox.Leave += ReTypePasswordBox_Leave;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(0, 0);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(125, 62);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 6;
            pictureBox6.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(418, 673);
            label3.Name = "label3";
            label3.Size = new Size(308, 29);
            label3.TabIndex = 27;
            label3.Text = "Already have an account?";
            // 
            // SignInLink
            // 
            SignInLink.AutoSize = true;
            SignInLink.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SignInLink.Location = new Point(725, 673);
            SignInLink.Name = "SignInLink";
            SignInLink.Size = new Size(87, 29);
            SignInLink.TabIndex = 28;
            SignInLink.TabStop = true;
            SignInLink.Text = "SignIn";
            SignInLink.LinkClicked += SignInLink_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(687, 702);
            label4.Name = "label4";
            label4.Size = new Size(279, 29);
            label4.TabIndex = 29;
            label4.Text = "and begin your journey";
            // 
            // panel5
            // 
            panel5.BackColor = Color.Azure;
            panel5.Controls.Add(OTPBox);
            panel5.Controls.Add(pictureBox7);
            panel5.Location = new Point(411, 472);
            panel5.Name = "panel5";
            panel5.Size = new Size(422, 62);
            panel5.TabIndex = 30;
            // 
            // OTPBox
            // 
            OTPBox.BackColor = Color.Azure;
            OTPBox.BorderStyle = BorderStyle.None;
            OTPBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OTPBox.ForeColor = SystemColors.InactiveCaption;
            OTPBox.Location = new Point(131, 17);
            OTPBox.Name = "OTPBox";
            OTPBox.Size = new Size(272, 31);
            OTPBox.TabIndex = 7;
            OTPBox.Text = "Enter OTP";
            OTPBox.Enter += OTPBox_Enter;
            OTPBox.Leave += OTPBox_Leave;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(0, 0);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(125, 62);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 6;
            pictureBox7.TabStop = false;
            // 
            // RegisterButton
            // 
            RegisterButton.BackgroundImage = (Image)resources.GetObject("RegisterButton.BackgroundImage");
            RegisterButton.BackgroundImageLayout = ImageLayout.Stretch;
            RegisterButton.FlatAppearance.BorderSize = 0;
            RegisterButton.FlatStyle = FlatStyle.Flat;
            RegisterButton.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RegisterButton.Location = new Point(570, 547);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(275, 78);
            RegisterButton.TabIndex = 32;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // OTPButton
            // 
            OTPButton.BackgroundImage = (Image)resources.GetObject("OTPButton.BackgroundImage");
            OTPButton.BackgroundImageLayout = ImageLayout.Stretch;
            OTPButton.FlatAppearance.BorderSize = 0;
            OTPButton.FlatStyle = FlatStyle.Flat;
            OTPButton.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OTPButton.Location = new Point(839, 472);
            OTPButton.Name = "OTPButton";
            OTPButton.Size = new Size(154, 62);
            OTPButton.TabIndex = 33;
            OTPButton.Text = "Send OTP";
            OTPButton.UseVisualStyleBackColor = true;
            OTPButton.Click += OTPButton_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aquamarine;
            ClientSize = new Size(1000, 730);
            Controls.Add(OTPButton);
            Controls.Add(RegisterButton);
            Controls.Add(panel5);
            Controls.Add(label4);
            Controls.Add(SignInLink);
            Controls.Add(label3);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(StatusText);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "RegisterForm";
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox PasswordBox;
        private TextBox AccountBox;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label StatusText;
        private Panel panel2;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel3;
        private TextBox EmailBox;
        private PictureBox pictureBox5;
        private Panel panel4;
        private TextBox ReTypePasswordBox;
        private PictureBox pictureBox6;
        private Label label3;
        private LinkLabel SignInLink;
        private Label label4;
        private Panel panel5;
        private TextBox OTPBox;
        private PictureBox pictureBox7;
        private Button RegisterButton;
        private Button OTPButton;
    }
}