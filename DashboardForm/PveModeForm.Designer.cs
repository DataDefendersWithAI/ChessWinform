namespace winform_chat.DashboardForm
{
    partial class PveModeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PveModeForm));
            EvilButton = new Button();
            label1 = new Label();
            label2 = new Label();
            EasyButton = new Button();
            BabyButton = new Button();
            IntermidiateButton = new Button();
            HardButton = new Button();
            comboBox1 = new ComboBox();
            imageList1 = new ImageList(components);
            comboBox2 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // EvilButton
            // 
            EvilButton.BackColor = Color.DarkOrchid;
            EvilButton.BackgroundImage = (Image)resources.GetObject("EvilButton.BackgroundImage");
            EvilButton.BackgroundImageLayout = ImageLayout.Stretch;
            EvilButton.FlatAppearance.BorderSize = 0;
            EvilButton.FlatStyle = FlatStyle.Flat;
            EvilButton.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold);
            EvilButton.ForeColor = Color.Indigo;
            EvilButton.Location = new Point(110, 368);
            EvilButton.Margin = new Padding(3, 2, 3, 2);
            EvilButton.Name = "EvilButton";
            EvilButton.Size = new Size(272, 58);
            EvilButton.TabIndex = 14;
            EvilButton.Text = "😈 Evil";
            EvilButton.UseVisualStyleBackColor = false;
            EvilButton.Click += EvilButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(190, 7);
            label1.Name = "label1";
            label1.Size = new Size(0, 73);
            label1.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(441, 35);
            label2.Name = "label2";
            label2.Size = new Size(289, 74);
            label2.TabIndex = 16;
            label2.Text = "Please choose \r\nyour play mode";
            label2.Click += label2_Click;
            // 
            // EasyButton
            // 
            EasyButton.BackColor = Color.FromArgb(128, 255, 255);
            EasyButton.BackgroundImage = (Image)resources.GetObject("EasyButton.BackgroundImage");
            EasyButton.BackgroundImageLayout = ImageLayout.Stretch;
            EasyButton.FlatAppearance.BorderSize = 0;
            EasyButton.FlatStyle = FlatStyle.Flat;
            EasyButton.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold);
            EasyButton.ForeColor = Color.Teal;
            EasyButton.Location = new Point(110, 109);
            EasyButton.Margin = new Padding(3, 2, 3, 2);
            EasyButton.Name = "EasyButton";
            EasyButton.Size = new Size(272, 58);
            EasyButton.TabIndex = 17;
            EasyButton.Text = "Easy";
            EasyButton.UseVisualStyleBackColor = false;
            EasyButton.Click += EasyButton_Click;
            // 
            // BabyButton
            // 
            BabyButton.BackColor = Color.Lime;
            BabyButton.BackgroundImage = (Image)resources.GetObject("BabyButton.BackgroundImage");
            BabyButton.BackgroundImageLayout = ImageLayout.Stretch;
            BabyButton.FlatAppearance.BorderSize = 0;
            BabyButton.FlatStyle = FlatStyle.Flat;
            BabyButton.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold);
            BabyButton.ForeColor = Color.ForestGreen;
            BabyButton.Location = new Point(110, 22);
            BabyButton.Margin = new Padding(3, 2, 3, 2);
            BabyButton.Name = "BabyButton";
            BabyButton.Size = new Size(272, 58);
            BabyButton.TabIndex = 18;
            BabyButton.Text = "👶 Baby";
            BabyButton.UseVisualStyleBackColor = false;
            BabyButton.Click += BabyButton_Click;
            // 
            // IntermidiateButton
            // 
            IntermidiateButton.BackColor = Color.Yellow;
            IntermidiateButton.BackgroundImage = (Image)resources.GetObject("IntermidiateButton.BackgroundImage");
            IntermidiateButton.BackgroundImageLayout = ImageLayout.Stretch;
            IntermidiateButton.FlatAppearance.BorderSize = 0;
            IntermidiateButton.FlatStyle = FlatStyle.Flat;
            IntermidiateButton.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold);
            IntermidiateButton.ForeColor = Color.DarkGoldenrod;
            IntermidiateButton.Location = new Point(110, 197);
            IntermidiateButton.Margin = new Padding(3, 2, 3, 2);
            IntermidiateButton.Name = "IntermidiateButton";
            IntermidiateButton.Size = new Size(272, 58);
            IntermidiateButton.TabIndex = 19;
            IntermidiateButton.Text = "Intermediate";
            IntermidiateButton.UseVisualStyleBackColor = false;
            IntermidiateButton.Click += IntermidiateButton_Click;
            // 
            // HardButton
            // 
            HardButton.BackColor = Color.LightCoral;
            HardButton.BackgroundImage = (Image)resources.GetObject("HardButton.BackgroundImage");
            HardButton.BackgroundImageLayout = ImageLayout.Stretch;
            HardButton.FlatAppearance.BorderSize = 0;
            HardButton.FlatStyle = FlatStyle.Flat;
            HardButton.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold);
            HardButton.ForeColor = Color.Sienna;
            HardButton.Location = new Point(110, 279);
            HardButton.Margin = new Padding(3, 2, 3, 2);
            HardButton.Name = "HardButton";
            HardButton.Size = new Size(272, 58);
            HardButton.TabIndex = 20;
            HardButton.Text = "Hard";
            HardButton.UseVisualStyleBackColor = false;
            HardButton.Click += HardButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(554, 197);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(176, 29);
            comboBox1.TabIndex = 21;
            comboBox1.Text = "White";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Black");
            imageList1.Images.SetKeyName(1, "White");
            imageList1.Images.SetKeyName(2, "Random");
            imageList1.Images.SetKeyName(3, "Clock.png");
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Segoe UI", 12F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(554, 301);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(176, 29);
            comboBox2.TabIndex = 23;
            comboBox2.Text = "White";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.ImageIndex = 3;
            label3.ImageList = imageList1;
            label3.Location = new Point(484, 279);
            label3.Name = "label3";
            label3.Size = new Size(64, 68);
            label3.TabIndex = 24;
            // 
            // label4
            // 
            label4.ImageIndex = 1;
            label4.ImageList = imageList1;
            label4.Location = new Point(484, 176);
            label4.Name = "label4";
            label4.Size = new Size(64, 68);
            label4.TabIndex = 25;
            // 
            // PveModeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(766, 455);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(HardButton);
            Controls.Add(IntermidiateButton);
            Controls.Add(BabyButton);
            Controls.Add(EasyButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(EvilButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "PveModeForm";
            Text = "PveModeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button EvilButton;
        private Label label1;
        private Label label2;
        private Button EasyButton;
        private Button BabyButton;
        private Button IntermidiateButton;
        private Button HardButton;
        private ComboBox comboBox1;
        private ImageList imageList1;
        private ComboBox comboBox2;
        private Label label3;
        private Label label4;
    }
}