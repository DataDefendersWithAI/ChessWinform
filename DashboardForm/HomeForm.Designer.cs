namespace winform_chat.DashboardForm
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            pictureBox1 = new PictureBox();
            PvPButton = new Button();
            PvEButton = new Button();
            label1 = new Label();
            DisplayText = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(60, 84);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(381, 331);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // PvPButton
            // 
            PvPButton.BackColor = Color.IndianRed;
            PvPButton.BackgroundImage = (Image)resources.GetObject("PvPButton.BackgroundImage");
            PvPButton.BackgroundImageLayout = ImageLayout.Stretch;
            PvPButton.FlatAppearance.BorderSize = 0;
            PvPButton.FlatStyle = FlatStyle.Flat;
            PvPButton.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold);
            PvPButton.ForeColor = Color.Sienna;
            PvPButton.Location = new Point(461, 357);
            PvPButton.Margin = new Padding(3, 2, 3, 2);
            PvPButton.Name = "PvPButton";
            PvPButton.Size = new Size(222, 58);
            PvPButton.TabIndex = 13;
            PvPButton.Text = "⚔ PvP ⚔️";
            PvPButton.UseVisualStyleBackColor = false;
            PvPButton.Click += PvPButton_Click;
            // 
            // PvEButton
            // 
            PvEButton.BackColor = Color.Gray;
            PvEButton.BackgroundImage = (Image)resources.GetObject("PvEButton.BackgroundImage");
            PvEButton.BackgroundImageLayout = ImageLayout.Stretch;
            PvEButton.FlatAppearance.BorderSize = 0;
            PvEButton.FlatStyle = FlatStyle.Flat;
            PvEButton.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold);
            PvEButton.Location = new Point(461, 255);
            PvEButton.Margin = new Padding(3, 2, 3, 2);
            PvEButton.Name = "PvEButton";
            PvEButton.Size = new Size(222, 58);
            PvEButton.TabIndex = 14;
            PvEButton.Text = "🤖 PvE 🤖 ";
            PvEButton.UseVisualStyleBackColor = false;
            PvEButton.Click += PvEButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(60, 3);
            label1.Name = "label1";
            label1.Size = new Size(313, 79);
            label1.TabIndex = 15;
            label1.Text = "Chess.ai";
            // 
            // DisplayText
            // 
            DisplayText.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DisplayText.Location = new Point(461, 84);
            DisplayText.Name = "DisplayText";
            DisplayText.Size = new Size(293, 87);
            DisplayText.TabIndex = 16;
            DisplayText.Text = "Welcome user, please choose your play mode";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(766, 455);
            Controls.Add(DisplayText);
            Controls.Add(label1);
            Controls.Add(PvEButton);
            Controls.Add(PvPButton);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "HomeForm";
            Text = "HomeForm";
            Load += HomeForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button PvPButton;
        private Button PvEButton;
        private Label label1;
        private Label DisplayText;
    }
}