namespace ChessAI
{
    partial class ChessAIClient
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessAIClient));
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            richTextBox2 = new RichTextBox();
            cntSvr = new Button();
            button2 = new Button();
            imageList1 = new ImageList(components);
            flowLayoutPanel1 = new FlowLayoutPanel();
            Queen = new Button();
            Rook = new Button();
            Knight = new Button();
            Bishop = new Button();
            label1 = new Label();
            panel1 = new Panel();
            opponentTimer = new Label();
            ourTimer = new Label();
            opponentCaptured = new FlowLayoutPanel();
            ourCaptured = new FlowLayoutPanel();
            ourName = new Label();
            opponentName = new Label();
            opponentFlag = new Button();
            imageList2 = new ImageList(components);
            ourFlag = new Button();
            drawBtn = new Button();
            resignBtn = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(981, 27);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(269, 288);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(981, 321);
            button1.Name = "button1";
            button1.Size = new Size(139, 83);
            button1.TabIndex = 2;
            button1.Text = "Opponent move";
            button1.UseVisualStyleBackColor = false;
            button1.Click += OpponentMoveButton_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(981, 453);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(269, 288);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "";
            // 
            // cntSvr
            // 
            cntSvr.BackColor = Color.Chartreuse;
            cntSvr.Font = new Font("Segoe UI", 13F);
            cntSvr.Location = new Point(1145, 339);
            cntSvr.Name = "cntSvr";
            cntSvr.Size = new Size(104, 83);
            cntSvr.TabIndex = 4;
            cntSvr.Text = "Connect server";
            cntSvr.UseVisualStyleBackColor = false;
            cntSvr.Click += cntSvr_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.PaleGoldenrod;
            button2.Font = new Font("Segoe UI", 13F);
            button2.Location = new Point(981, 411);
            button2.Name = "button2";
            button2.Size = new Size(139, 37);
            button2.TabIndex = 5;
            button2.Text = "Offline";
            button2.UseVisualStyleBackColor = false;
            button2.Click += OfflineButton_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "BBishop");
            imageList1.Images.SetKeyName(1, "BKnight");
            imageList1.Images.SetKeyName(2, "BQueen");
            imageList1.Images.SetKeyName(3, "BRook");
            imageList1.Images.SetKeyName(4, "WBishop");
            imageList1.Images.SetKeyName(5, "WKnight");
            imageList1.Images.SetKeyName(6, "WQueen");
            imageList1.Images.SetKeyName(7, "WRook");
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.SandyBrown;
            flowLayoutPanel1.Controls.Add(Queen);
            flowLayoutPanel1.Controls.Add(Rook);
            flowLayoutPanel1.Controls.Add(Knight);
            flowLayoutPanel1.Controls.Add(Bishop);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Location = new Point(901, 172);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(73, 300);
            flowLayoutPanel1.TabIndex = 6;
            flowLayoutPanel1.Visible = false;
            // 
            // Queen
            // 
            Queen.ImageIndex = 1;
            Queen.ImageList = imageList1;
            Queen.Location = new Point(3, 3);
            Queen.Name = "Queen";
            Queen.Size = new Size(69, 68);
            Queen.TabIndex = 0;
            Queen.Text = " ";
            Queen.UseVisualStyleBackColor = true;
            // 
            // Rook
            // 
            Rook.ImageIndex = 1;
            Rook.ImageList = imageList1;
            Rook.Location = new Point(3, 77);
            Rook.Name = "Rook";
            Rook.Size = new Size(69, 68);
            Rook.TabIndex = 1;
            Rook.Text = " ";
            Rook.UseVisualStyleBackColor = true;
            // 
            // Knight
            // 
            Knight.ImageKey = "WKnight";
            Knight.ImageList = imageList1;
            Knight.Location = new Point(3, 151);
            Knight.Name = "Knight";
            Knight.Size = new Size(69, 68);
            Knight.TabIndex = 2;
            Knight.Text = " ";
            Knight.UseVisualStyleBackColor = true;
            // 
            // Bishop
            // 
            Bishop.ImageIndex = 1;
            Bishop.ImageList = imageList1;
            Bishop.Location = new Point(3, 225);
            Bishop.Name = "Bishop";
            Bishop.Size = new Size(69, 68);
            Bishop.TabIndex = 3;
            Bishop.Text = " ";
            Bishop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 296);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCyan;
            panel1.Location = new Point(18, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(664, 625);
            panel1.TabIndex = 7;
            panel1.Paint += boardPaint;
            panel1.MouseClick += boardClick;
            // 
            // opponentTimer
            // 
            opponentTimer.BackColor = Color.DarkGray;
            opponentTimer.BorderStyle = BorderStyle.Fixed3D;
            opponentTimer.FlatStyle = FlatStyle.Flat;
            opponentTimer.Font = new Font("Cascadia Code", 16F);
            opponentTimer.Location = new Point(688, 124);
            opponentTimer.Name = "opponentTimer";
            opponentTimer.Size = new Size(125, 43);
            opponentTimer.TabIndex = 8;
            opponentTimer.Text = "9:59";
            opponentTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ourTimer
            // 
            ourTimer.BackColor = Color.LightGray;
            ourTimer.BorderStyle = BorderStyle.Fixed3D;
            ourTimer.FlatStyle = FlatStyle.Flat;
            ourTimer.Font = new Font("Cascadia Code", 16F);
            ourTimer.Location = new Point(688, 509);
            ourTimer.Name = "ourTimer";
            ourTimer.Size = new Size(125, 43);
            ourTimer.TabIndex = 9;
            ourTimer.Text = "9:59";
            ourTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // opponentCaptured
            // 
            opponentCaptured.BackColor = Color.Transparent;
            opponentCaptured.BorderStyle = BorderStyle.Fixed3D;
            opponentCaptured.Location = new Point(688, 27);
            opponentCaptured.Name = "opponentCaptured";
            opponentCaptured.Size = new Size(271, 41);
            opponentCaptured.TabIndex = 10;
            // 
            // ourCaptured
            // 
            ourCaptured.BackColor = Color.Transparent;
            ourCaptured.BackgroundImageLayout = ImageLayout.None;
            ourCaptured.BorderStyle = BorderStyle.Fixed3D;
            ourCaptured.Location = new Point(688, 607);
            ourCaptured.Name = "ourCaptured";
            ourCaptured.Size = new Size(271, 45);
            ourCaptured.TabIndex = 11;
            // 
            // ourName
            // 
            ourName.BackColor = Color.Transparent;
            ourName.BorderStyle = BorderStyle.Fixed3D;
            ourName.FlatStyle = FlatStyle.Flat;
            ourName.Font = new Font("Cascadia Code", 10F);
            ourName.Location = new Point(688, 563);
            ourName.Name = "ourName";
            ourName.Size = new Size(272, 43);
            ourName.TabIndex = 12;
            ourName.Text = "Bob (2500)";
            ourName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // opponentName
            // 
            opponentName.BackColor = Color.Transparent;
            opponentName.BorderStyle = BorderStyle.Fixed3D;
            opponentName.FlatStyle = FlatStyle.Flat;
            opponentName.Font = new Font("Cascadia Code", 10F);
            opponentName.Location = new Point(688, 72);
            opponentName.Name = "opponentName";
            opponentName.Size = new Size(272, 43);
            opponentName.TabIndex = 13;
            opponentName.Text = "Mittens (1)";
            opponentName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // opponentFlag
            // 
            opponentFlag.ImageIndex = 1;
            opponentFlag.ImageList = imageList2;
            opponentFlag.Location = new Point(819, 124);
            opponentFlag.Name = "opponentFlag";
            opponentFlag.Size = new Size(42, 43);
            opponentFlag.TabIndex = 5;
            opponentFlag.Text = " ";
            opponentFlag.UseVisualStyleBackColor = true;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth8Bit;
            imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            imageList2.TransparentColor = Color.Transparent;
            imageList2.Images.SetKeyName(0, "BBishop");
            imageList2.Images.SetKeyName(1, "BKnight");
            imageList2.Images.SetKeyName(2, "BQueen");
            imageList2.Images.SetKeyName(3, "BRook");
            imageList2.Images.SetKeyName(4, "WBishop");
            imageList2.Images.SetKeyName(5, "WKnight");
            imageList2.Images.SetKeyName(6, "WQueen");
            imageList2.Images.SetKeyName(7, "WRook");
            // 
            // ourFlag
            // 
            ourFlag.ImageIndex = 1;
            ourFlag.ImageList = imageList2;
            ourFlag.Location = new Point(819, 509);
            ourFlag.Name = "ourFlag";
            ourFlag.Size = new Size(42, 43);
            ourFlag.TabIndex = 14;
            ourFlag.Text = " ";
            ourFlag.UseVisualStyleBackColor = true;
            // 
            // drawBtn
            // 
            drawBtn.BackColor = Color.Khaki;
            drawBtn.Font = new Font("Segoe UI", 13F);
            drawBtn.Location = new Point(18, 676);
            drawBtn.Name = "drawBtn";
            drawBtn.Size = new Size(117, 53);
            drawBtn.TabIndex = 15;
            drawBtn.Text = "Draw";
            drawBtn.UseVisualStyleBackColor = false;
            // 
            // resignBtn
            // 
            resignBtn.BackColor = Color.LightCoral;
            resignBtn.Font = new Font("Segoe UI", 13F);
            resignBtn.Location = new Point(141, 676);
            resignBtn.Name = "resignBtn";
            resignBtn.Size = new Size(117, 53);
            resignBtn.TabIndex = 16;
            resignBtn.Text = "Resign";
            resignBtn.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // ChessAIClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1261, 753);
            Controls.Add(resignBtn);
            Controls.Add(drawBtn);
            Controls.Add(ourFlag);
            Controls.Add(opponentName);
            Controls.Add(ourName);
            Controls.Add(ourCaptured);
            Controls.Add(opponentCaptured);
            Controls.Add(ourTimer);
            Controls.Add(opponentFlag);
            Controls.Add(opponentTimer);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button2);
            Controls.Add(cntSvr);
            Controls.Add(richTextBox2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Name = "ChessAIClient";
            Text = "Form1";
            Load += ClientForm_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button button1;
        private RichTextBox richTextBox2;
        private Button cntSvr;
        private Button button2;
        private ImageList imageList1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button Queen;
        private Button Rook;
        private Button Knight;
        private Button Bishop;
        private Panel panel1;
        private Label label1;
        private Label opponentTimer;
        private Label ourTimer;
        private FlowLayoutPanel opponentCaptured;
        private FlowLayoutPanel ourCaptured;
        private Label ourName;
        private Label opponentName;
        private Button opponentFlag;
        private ImageList imageList2;
        private Button ourFlag;
        private Button drawBtn;
        private Button resignBtn;
        private System.Windows.Forms.Timer timer1;
    }
}
