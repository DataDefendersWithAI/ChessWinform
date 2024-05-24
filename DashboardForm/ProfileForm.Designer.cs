namespace LoginForm.DashboardForm
{
    partial class ProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
            panel4 = new Panel();
            ReTypePasswordBox = new TextBox();
            pictureBox6 = new PictureBox();
            StatusText = new Label();
            panel2 = new Panel();
            PasswordBox = new TextBox();
            pictureBox4 = new PictureBox();
            panel1 = new Panel();
            CurrAccountBox = new TextBox();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            panel6 = new Panel();
            NewAccountBox = new TextBox();
            pictureBox1 = new PictureBox();
            UpdateUserButton = new Button();
            panel3 = new Panel();
            AccountBox = new TextBox();
            pictureBox2 = new PictureBox();
            UpdatePassButton = new Button();
            label1 = new Label();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.Azure;
            panel4.Controls.Add(ReTypePasswordBox);
            panel4.Controls.Add(pictureBox6);
            panel4.Location = new Point(3, 433);
            panel4.Name = "panel4";
            panel4.Size = new Size(594, 62);
            panel4.TabIndex = 39;
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
            // StatusText
            // 
            StatusText.AutoSize = true;
            StatusText.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StatusText.ForeColor = Color.Red;
            StatusText.Location = new Point(12, 545);
            StatusText.Name = "StatusText";
            StatusText.Size = new Size(440, 36);
            StatusText.TabIndex = 37;
            StatusText.Text = "Current Status: Not Logged In";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Azure;
            panel2.Controls.Add(PasswordBox);
            panel2.Controls.Add(pictureBox4);
            panel2.Location = new Point(3, 365);
            panel2.Name = "panel2";
            panel2.Size = new Size(594, 62);
            panel2.TabIndex = 36;
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
            // panel1
            // 
            panel1.BackColor = Color.Azure;
            panel1.Controls.Add(CurrAccountBox);
            panel1.Controls.Add(pictureBox3);
            panel1.Location = new Point(3, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(594, 62);
            panel1.TabIndex = 35;
            // 
            // CurrAccountBox
            // 
            CurrAccountBox.BackColor = Color.Azure;
            CurrAccountBox.BorderStyle = BorderStyle.None;
            CurrAccountBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CurrAccountBox.ForeColor = SystemColors.InactiveCaption;
            CurrAccountBox.Location = new Point(131, 15);
            CurrAccountBox.Name = "CurrAccountBox";
            CurrAccountBox.Size = new Size(451, 31);
            CurrAccountBox.TabIndex = 1;
            CurrAccountBox.Text = "Enter current username";
            CurrAccountBox.Enter += CurrAccountBox_Enter;
            CurrAccountBox.Leave += CurrAccountBox_Leave;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(204, 9);
            label2.Name = "label2";
            label2.Size = new Size(393, 60);
            label2.TabIndex = 34;
            label2.Text = "Change username";
            // 
            // panel6
            // 
            panel6.BackColor = Color.Azure;
            panel6.Controls.Add(NewAccountBox);
            panel6.Controls.Add(pictureBox1);
            panel6.Location = new Point(3, 150);
            panel6.Name = "panel6";
            panel6.Size = new Size(594, 62);
            panel6.TabIndex = 43;
            // 
            // NewAccountBox
            // 
            NewAccountBox.BackColor = Color.Azure;
            NewAccountBox.BorderStyle = BorderStyle.None;
            NewAccountBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NewAccountBox.ForeColor = SystemColors.InactiveCaption;
            NewAccountBox.Location = new Point(131, 15);
            NewAccountBox.Name = "NewAccountBox";
            NewAccountBox.Size = new Size(451, 31);
            NewAccountBox.TabIndex = 1;
            NewAccountBox.Text = "Enter username";
            NewAccountBox.Enter += NewAccountBox_Enter;
            NewAccountBox.Leave += NewAccountBox_Leave;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // UpdateUserButton
            // 
            UpdateUserButton.BackgroundImage = (Image)resources.GetObject("UpdateUserButton.BackgroundImage");
            UpdateUserButton.BackgroundImageLayout = ImageLayout.Stretch;
            UpdateUserButton.FlatAppearance.BorderSize = 0;
            UpdateUserButton.FlatStyle = FlatStyle.Flat;
            UpdateUserButton.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdateUserButton.Location = new Point(624, 112);
            UpdateUserButton.Name = "UpdateUserButton";
            UpdateUserButton.Size = new Size(154, 62);
            UpdateUserButton.TabIndex = 44;
            UpdateUserButton.Text = "Update";
            UpdateUserButton.UseVisualStyleBackColor = true;
            UpdateUserButton.Click += UpdateUserButton_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Azure;
            panel3.Controls.Add(AccountBox);
            panel3.Controls.Add(pictureBox2);
            panel3.Location = new Point(3, 297);
            panel3.Name = "panel3";
            panel3.Size = new Size(594, 62);
            panel3.TabIndex = 45;
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
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(125, 62);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // UpdatePassButton
            // 
            UpdatePassButton.BackgroundImage = (Image)resources.GetObject("UpdatePassButton.BackgroundImage");
            UpdatePassButton.BackgroundImageLayout = ImageLayout.Stretch;
            UpdatePassButton.FlatAppearance.BorderSize = 0;
            UpdatePassButton.FlatStyle = FlatStyle.Flat;
            UpdatePassButton.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdatePassButton.Location = new Point(624, 367);
            UpdatePassButton.Name = "UpdatePassButton";
            UpdatePassButton.Size = new Size(154, 62);
            UpdatePassButton.TabIndex = 45;
            UpdatePassButton.Text = "Update";
            UpdatePassButton.UseVisualStyleBackColor = true;
            UpdatePassButton.Click += UpdatePassButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(204, 225);
            label1.Name = "label1";
            label1.Size = new Size(386, 60);
            label1.TabIndex = 46;
            label1.Text = "Change password";
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 656);
            Controls.Add(label1);
            Controls.Add(UpdatePassButton);
            Controls.Add(panel3);
            Controls.Add(UpdateUserButton);
            Controls.Add(panel6);
            Controls.Add(panel4);
            Controls.Add(StatusText);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Name = "ProfileForm";
            Text = "ProfileForm";
            Load += ProfileForm_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel4;
        private TextBox ReTypePasswordBox;
        private PictureBox pictureBox6;
        private Label StatusText;
        private Panel panel2;
        private TextBox PasswordBox;
        private PictureBox pictureBox4;
        private Panel panel1;
        private TextBox CurrAccountBox;
        private PictureBox pictureBox3;
        private Label label2;
        private Panel panel6;
        private TextBox NewAccountBox;
        private PictureBox pictureBox1;
        private Button UpdateUserButton;
        private Panel panel3;
        private TextBox AccountBox;
        private PictureBox pictureBox2;
        private Button UpdatePassButton;
        private Label label1;
    }
}