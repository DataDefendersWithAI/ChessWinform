namespace winform_chat.DashboardForm
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
            panel4.Location = new Point(57, 325);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(466, 46);
            panel4.TabIndex = 39;
            // 
            // ReTypePasswordBox
            // 
            ReTypePasswordBox.BackColor = Color.Azure;
            ReTypePasswordBox.BorderStyle = BorderStyle.None;
            ReTypePasswordBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ReTypePasswordBox.ForeColor = SystemColors.InactiveCaption;
            ReTypePasswordBox.Location = new Point(115, 13);
            ReTypePasswordBox.Margin = new Padding(3, 2, 3, 2);
            ReTypePasswordBox.Name = "ReTypePasswordBox";
            ReTypePasswordBox.Size = new Size(395, 25);
            ReTypePasswordBox.TabIndex = 7;
            ReTypePasswordBox.Text = "Retype password";
            ReTypePasswordBox.Enter += ReTypePasswordBox_Enter;
            ReTypePasswordBox.Leave += ReTypePasswordBox_Leave;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(0, 0);
            pictureBox6.Margin = new Padding(3, 2, 3, 2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(109, 46);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 6;
            pictureBox6.TabStop = false;
            // 
            // StatusText
            // 
            StatusText.AutoSize = true;
            StatusText.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StatusText.ForeColor = Color.Red;
            StatusText.Location = new Point(10, 409);
            StatusText.Name = "StatusText";
            StatusText.Size = new Size(357, 29);
            StatusText.TabIndex = 37;
            StatusText.Text = "Current Status: Not Logged In";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Azure;
            panel2.Controls.Add(PasswordBox);
            panel2.Controls.Add(pictureBox4);
            panel2.Location = new Point(57, 274);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(466, 46);
            panel2.TabIndex = 36;
            // 
            // PasswordBox
            // 
            PasswordBox.BackColor = Color.Azure;
            PasswordBox.BorderStyle = BorderStyle.None;
            PasswordBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordBox.ForeColor = SystemColors.InactiveCaption;
            PasswordBox.Location = new Point(115, 13);
            PasswordBox.Margin = new Padding(3, 2, 3, 2);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(395, 25);
            PasswordBox.TabIndex = 7;
            PasswordBox.Text = "Enter password";
            PasswordBox.Enter += PasswordBox_Enter;
            PasswordBox.Leave += PasswordBox_Leave;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(109, 46);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Azure;
            panel1.Controls.Add(CurrAccountBox);
            panel1.Controls.Add(pictureBox3);
            panel1.Location = new Point(57, 62);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(466, 46);
            panel1.TabIndex = 35;
            // 
            // CurrAccountBox
            // 
            CurrAccountBox.BackColor = Color.Azure;
            CurrAccountBox.BorderStyle = BorderStyle.None;
            CurrAccountBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CurrAccountBox.ForeColor = SystemColors.InactiveCaption;
            CurrAccountBox.Location = new Point(115, 11);
            CurrAccountBox.Margin = new Padding(3, 2, 3, 2);
            CurrAccountBox.Name = "CurrAccountBox";
            CurrAccountBox.Size = new Size(395, 25);
            CurrAccountBox.TabIndex = 1;
            CurrAccountBox.Text = "Enter current username";
            CurrAccountBox.Enter += CurrAccountBox_Enter;
            CurrAccountBox.Leave += CurrAccountBox_Leave;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(109, 46);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(178, 7);
            label2.Name = "label2";
            label2.Size = new Size(314, 47);
            label2.TabIndex = 34;
            label2.Text = "Change username";
            // 
            // panel6
            // 
            panel6.BackColor = Color.Azure;
            panel6.Controls.Add(NewAccountBox);
            panel6.Controls.Add(pictureBox1);
            panel6.Location = new Point(57, 112);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(466, 46);
            panel6.TabIndex = 43;
            // 
            // NewAccountBox
            // 
            NewAccountBox.BackColor = Color.Azure;
            NewAccountBox.BorderStyle = BorderStyle.None;
            NewAccountBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NewAccountBox.ForeColor = SystemColors.InactiveCaption;
            NewAccountBox.Location = new Point(115, 11);
            NewAccountBox.Margin = new Padding(3, 2, 3, 2);
            NewAccountBox.Name = "NewAccountBox";
            NewAccountBox.Size = new Size(395, 25);
            NewAccountBox.TabIndex = 1;
            NewAccountBox.Text = "Enter username";
            NewAccountBox.Enter += NewAccountBox_Enter;
            NewAccountBox.Leave += NewAccountBox_Leave;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 46);
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
            UpdateUserButton.Location = new Point(546, 84);
            UpdateUserButton.Margin = new Padding(3, 2, 3, 2);
            UpdateUserButton.Name = "UpdateUserButton";
            UpdateUserButton.Size = new Size(135, 46);
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
            panel3.Location = new Point(57, 223);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(466, 46);
            panel3.TabIndex = 45;
            // 
            // AccountBox
            // 
            AccountBox.BackColor = Color.Azure;
            AccountBox.BorderStyle = BorderStyle.None;
            AccountBox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AccountBox.ForeColor = SystemColors.InactiveCaption;
            AccountBox.Location = new Point(115, 11);
            AccountBox.Margin = new Padding(3, 2, 3, 2);
            AccountBox.Name = "AccountBox";
            AccountBox.Size = new Size(395, 25);
            AccountBox.TabIndex = 1;
            AccountBox.Text = "Enter username";
            AccountBox.Enter += AccountBox_Enter;
            AccountBox.Leave += AccountBox_Leave;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(109, 46);
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
            UpdatePassButton.Location = new Point(546, 275);
            UpdatePassButton.Margin = new Padding(3, 2, 3, 2);
            UpdatePassButton.Name = "UpdatePassButton";
            UpdatePassButton.Size = new Size(135, 46);
            UpdatePassButton.TabIndex = 45;
            UpdatePassButton.Text = "Update";
            UpdatePassButton.UseVisualStyleBackColor = true;
            UpdatePassButton.Click += UpdatePassButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(178, 169);
            label1.Name = "label1";
            label1.Size = new Size(309, 47);
            label1.TabIndex = 46;
            label1.Text = "Change password";
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(700, 492);
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
            Margin = new Padding(3, 2, 3, 2);
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