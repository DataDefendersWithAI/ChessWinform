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
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(708, 27);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(250, 288);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(708, 321);
            button1.Name = "button1";
            button1.Size = new Size(140, 83);
            button1.TabIndex = 2;
            button1.Text = "Opponent move";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(708, 453);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(250, 288);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "";
            // 
            // cntSvr
            // 
            cntSvr.BackColor = Color.Chartreuse;
            cntSvr.Font = new Font("Segoe UI", 13F);
            cntSvr.Location = new Point(854, 336);
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
            button2.Location = new Point(708, 410);
            button2.Name = "button2";
            button2.Size = new Size(140, 37);
            button2.TabIndex = 5;
            button2.Text = "Offline";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
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
            flowLayoutPanel1.Location = new Point(541, 27);
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
            Queen.Size = new Size(68, 68);
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
            Rook.Size = new Size(68, 68);
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
            Knight.Size = new Size(68, 68);
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
            Bishop.Size = new Size(68, 68);
            Bishop.TabIndex = 3;
            Bishop.Text = " ";
            Bishop.UseVisualStyleBackColor = true;
            // 
            // ChessAIClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 753);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button2);
            Controls.Add(cntSvr);
            Controls.Add(richTextBox2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Name = "ChessAIClient";
            Text = "Form1";
            Load += ClientForm_Load;
            Paint += boardPaint;
            MouseClick += boardClick;
            flowLayoutPanel1.ResumeLayout(false);
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
    }
}
