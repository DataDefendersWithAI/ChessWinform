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
            OppMoveButton = new Button();
            richTextBox2 = new RichTextBox();
            cntSvr = new Button();
            OfflineButton = new Button();
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
            label2 = new Label();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(954, 56);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(288, 321);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // OppMoveButton
            // 
            OppMoveButton.BackColor = Color.LightGreen;
            OppMoveButton.Font = new Font("Segoe UI", 13F);
            OppMoveButton.Location = new Point(1042, 396);
            OppMoveButton.Margin = new Padding(3, 2, 3, 2);
            OppMoveButton.Name = "OppMoveButton";
            OppMoveButton.Size = new Size(107, 79);
            OppMoveButton.TabIndex = 4;
            OppMoveButton.Text = "Opponent move";
            OppMoveButton.UseVisualStyleBackColor = false;
            OppMoveButton.Click += OpponentMoveButton_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(954, 479);
            richTextBox2.Margin = new Padding(3, 2, 3, 2);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(300, 217);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "";
            // 
            // cntSvr
            // 
            cntSvr.BackColor = Color.Chartreuse;
            cntSvr.Font = new Font("Segoe UI", 13F);
            cntSvr.Location = new Point(1155, 396);
            cntSvr.Margin = new Padding(3, 2, 3, 2);
            cntSvr.Name = "cntSvr";
            cntSvr.Size = new Size(87, 79);
            cntSvr.TabIndex = 4;
            cntSvr.Text = "Connect server";
            cntSvr.UseVisualStyleBackColor = false;
            cntSvr.Click += cntSvr_Click;
            // 
            // OfflineButton
            // 
            OfflineButton.BackColor = Color.PaleGoldenrod;
            OfflineButton.Font = new Font("Segoe UI", 13F);
            OfflineButton.Location = new Point(954, 396);
            OfflineButton.Margin = new Padding(3, 2, 3, 2);
            OfflineButton.Name = "OfflineButton";
            OfflineButton.Size = new Size(82, 79);
            OfflineButton.TabIndex = 5;
            OfflineButton.Text = "Offline";
            OfflineButton.UseVisualStyleBackColor = false;
            OfflineButton.Click += OfflineButton_Click;
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
            flowLayoutPanel1.Location = new Point(1230, 422);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(64, 225);
            flowLayoutPanel1.TabIndex = 6;
            flowLayoutPanel1.Visible = false;
            // 
            // Queen
            // 
            Queen.ImageIndex = 1;
            Queen.ImageList = imageList1;
            Queen.Location = new Point(3, 2);
            Queen.Margin = new Padding(3, 2, 3, 2);
            Queen.Name = "Queen";
            Queen.Size = new Size(60, 51);
            Queen.TabIndex = 0;
            Queen.Text = " ";
            Queen.UseVisualStyleBackColor = true;
            // 
            // Rook
            // 
            Rook.ImageIndex = 1;
            Rook.ImageList = imageList1;
            Rook.Location = new Point(3, 57);
            Rook.Margin = new Padding(3, 2, 3, 2);
            Rook.Name = "Rook";
            Rook.Size = new Size(60, 51);
            Rook.TabIndex = 1;
            Rook.Text = " ";
            Rook.UseVisualStyleBackColor = true;
            // 
            // Knight
            // 
            Knight.ImageKey = "WKnight";
            Knight.ImageList = imageList1;
            Knight.Location = new Point(3, 112);
            Knight.Margin = new Padding(3, 2, 3, 2);
            Knight.Name = "Knight";
            Knight.Size = new Size(60, 51);
            Knight.TabIndex = 2;
            Knight.Text = " ";
            Knight.UseVisualStyleBackColor = true;
            // 
            // Bishop
            // 
            Bishop.ImageIndex = 1;
            Bishop.ImageList = imageList1;
            Bishop.Location = new Point(3, 167);
            Bishop.Margin = new Padding(3, 2, 3, 2);
            Bishop.Name = "Bishop";
            Bishop.Size = new Size(60, 51);
            Bishop.TabIndex = 3;
            Bishop.Text = " ";
            Bishop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 220);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCyan;
            panel1.Location = new Point(16, 20);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(650, 650);
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
            opponentTimer.Location = new Point(683, 129);
            opponentTimer.Name = "opponentTimer";
            opponentTimer.Size = new Size(109, 32);
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
            ourTimer.Location = new Point(683, 502);
            ourTimer.Name = "ourTimer";
            ourTimer.Size = new Size(109, 32);
            ourTimer.TabIndex = 9;
            ourTimer.Text = "9:59";
            ourTimer.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // opponentCaptured
            // 
            opponentCaptured.BackColor = Color.Transparent;
            opponentCaptured.BorderStyle = BorderStyle.Fixed3D;
            opponentCaptured.Location = new Point(683, 56);
            opponentCaptured.Margin = new Padding(3, 2, 3, 2);
            opponentCaptured.Name = "opponentCaptured";
            opponentCaptured.Size = new Size(238, 32);
            opponentCaptured.TabIndex = 10;
            // 
            // ourCaptured
            // 
            ourCaptured.BackColor = Color.Transparent;
            ourCaptured.BackgroundImageLayout = ImageLayout.None;
            ourCaptured.BorderStyle = BorderStyle.Fixed3D;
            ourCaptured.Location = new Point(683, 575);
            ourCaptured.Margin = new Padding(3, 2, 3, 2);
            ourCaptured.Name = "ourCaptured";
            ourCaptured.Size = new Size(238, 35);
            ourCaptured.TabIndex = 11;
            // 
            // ourName
            // 
            ourName.BackColor = Color.Transparent;
            ourName.BorderStyle = BorderStyle.Fixed3D;
            ourName.FlatStyle = FlatStyle.Flat;
            ourName.Font = new Font("Cascadia Code", 10F);
            ourName.Location = new Point(683, 542);
            ourName.Name = "ourName";
            ourName.Size = new Size(238, 32);
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
            opponentName.Location = new Point(683, 90);
            opponentName.Name = "opponentName";
            opponentName.Size = new Size(238, 32);
            opponentName.TabIndex = 13;
            opponentName.Text = "Mittens (1)";
            opponentName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // opponentFlag
            // 
            opponentFlag.ImageIndex = 1;
            opponentFlag.ImageList = imageList2;
            opponentFlag.Location = new Point(798, 129);
            opponentFlag.Margin = new Padding(3, 2, 3, 2);
            opponentFlag.Name = "opponentFlag";
            opponentFlag.Size = new Size(37, 32);
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
            ourFlag.Location = new Point(798, 502);
            ourFlag.Margin = new Padding(3, 2, 3, 2);
            ourFlag.Name = "ourFlag";
            ourFlag.Size = new Size(37, 32);
            ourFlag.TabIndex = 14;
            ourFlag.Text = " ";
            ourFlag.UseVisualStyleBackColor = true;
            // 
            // drawBtn
            // 
            drawBtn.BackColor = Color.Khaki;
            drawBtn.Font = new Font("Segoe UI", 13F);
            drawBtn.Location = new Point(683, 631);
            drawBtn.Margin = new Padding(3, 2, 3, 2);
            drawBtn.Name = "drawBtn";
            drawBtn.Size = new Size(102, 40);
            drawBtn.TabIndex = 15;
            drawBtn.Text = "Draw";
            drawBtn.UseVisualStyleBackColor = false;
            // 
            // resignBtn
            // 
            resignBtn.BackColor = Color.LightCoral;
            resignBtn.Font = new Font("Segoe UI", 13F);
            resignBtn.Location = new Point(819, 631);
            resignBtn.Margin = new Padding(3, 2, 3, 2);
            resignBtn.Name = "resignBtn";
            resignBtn.Size = new Size(102, 40);
            resignBtn.TabIndex = 16;
            resignBtn.Text = "Resign";
            resignBtn.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Cascadia Code", 15F);
            label2.Location = new Point(954, 20);
            label2.Name = "label2";
            label2.Size = new Size(288, 32);
            label2.TabIndex = 17;
            label2.Text = "Game log";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ChessAIClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 707);
            Controls.Add(OfflineButton);
            Controls.Add(cntSvr);
            Controls.Add(label2);
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
            Controls.Add(richTextBox2);
            Controls.Add(OppMoveButton);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChessAIClient";
            Text = "Form1";
            Load += ClientForm_Load;
            SizeChanged += boardResize;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }


        #endregion

        private RichTextBox richTextBox1;
        private Button OppMoveButton;
        private RichTextBox richTextBox2;
        private Button cntSvr;
        private Button OfflineButton;
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
        private Label label2;
    }
}
