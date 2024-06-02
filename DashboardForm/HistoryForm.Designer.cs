namespace winform_chat.DashboardForm
{
    partial class HistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
            listBoxHistory = new ListBox();
            panel1 = new Panel();
            rvwBtn = new Button();
            cpyBtn = new Button();
            gameDate = new Label();
            label8 = new Label();
            gameTermination = new Label();
            gameResult = new Label();
            bside = new Button();
            imageList1 = new ImageList(components);
            wside = new Button();
            richTextBoxPGN = new RichTextBox();
            button2 = new Button();
            button1 = new Button();
            BlackSide = new Label();
            WhiteSide = new Label();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxHistory
            // 
            listBoxHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBoxHistory.BackColor = Color.WhiteSmoke;
            listBoxHistory.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxHistory.FormattingEnabled = true;
            listBoxHistory.ItemHeight = 32;
            listBoxHistory.Location = new Point(31, 44);
            listBoxHistory.Name = "listBoxHistory";
            listBoxHistory.Size = new Size(464, 420);
            listBoxHistory.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.BackColor = Color.LightCoral;
            panel1.Controls.Add(rvwBtn);
            panel1.Controls.Add(cpyBtn);
            panel1.Controls.Add(gameDate);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(gameTermination);
            panel1.Controls.Add(gameResult);
            panel1.Controls.Add(bside);
            panel1.Controls.Add(wside);
            panel1.Controls.Add(richTextBoxPGN);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(BlackSide);
            panel1.Controls.Add(WhiteSide);
            panel1.Location = new Point(501, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(291, 420);
            panel1.TabIndex = 10;
            // 
            // rvwBtn
            // 
            rvwBtn.BackColor = Color.MediumSlateBlue;
            rvwBtn.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rvwBtn.ForeColor = Color.GreenYellow;
            rvwBtn.Location = new Point(85, 186);
            rvwBtn.Name = "rvwBtn";
            rvwBtn.Size = new Size(135, 50);
            rvwBtn.TabIndex = 22;
            rvwBtn.Text = "Review";
            rvwBtn.UseVisualStyleBackColor = false;
            rvwBtn.Click += rvwBtn_Click;
            // 
            // cpyBtn
            // 
            cpyBtn.BackColor = Color.PaleTurquoise;
            cpyBtn.Font = new Font("Segoe UI", 12F);
            cpyBtn.Location = new Point(209, 278);
            cpyBtn.Name = "cpyBtn";
            cpyBtn.Size = new Size(65, 29);
            cpyBtn.TabIndex = 21;
            cpyBtn.Text = "Copy";
            cpyBtn.UseVisualStyleBackColor = false;
            cpyBtn.Click += cpyBtn_Click;
            // 
            // gameDate
            // 
            gameDate.BackColor = Color.Transparent;
            gameDate.FlatStyle = FlatStyle.Flat;
            gameDate.Font = new Font("Segoe UI", 12F);
            gameDate.Location = new Point(16, 249);
            gameDate.Name = "gameDate";
            gameDate.Size = new Size(258, 29);
            gameDate.TabIndex = 20;
            gameDate.Text = "Date: 35- 03 -2025";
            gameDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(16, 278);
            label8.Name = "label8";
            label8.Size = new Size(61, 29);
            label8.TabIndex = 19;
            label8.Text = "PGN: ";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gameTermination
            // 
            gameTermination.BackColor = Color.Transparent;
            gameTermination.FlatStyle = FlatStyle.Flat;
            gameTermination.Font = new Font("Segoe UI", 12F);
            gameTermination.Location = new Point(7, 154);
            gameTermination.Name = "gameTermination";
            gameTermination.Size = new Size(280, 29);
            gameTermination.TabIndex = 18;
            gameTermination.Text = "You have resigned";
            gameTermination.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gameResult
            // 
            gameResult.BackColor = Color.OliveDrab;
            gameResult.BorderStyle = BorderStyle.Fixed3D;
            gameResult.Font = new Font("Varela Round", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gameResult.ForeColor = Color.LawnGreen;
            gameResult.Location = new Point(85, 122);
            gameResult.Name = "gameResult";
            gameResult.Size = new Size(135, 29);
            gameResult.TabIndex = 17;
            gameResult.Text = "1/2 : 1/2";
            gameResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bside
            // 
            bside.BackColor = Color.Transparent;
            bside.ImageKey = "b_king_png_shadow_1024px.png";
            bside.ImageList = imageList1;
            bside.Location = new Point(226, 109);
            bside.Name = "bside";
            bside.Size = new Size(42, 42);
            bside.TabIndex = 16;
            bside.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "b_king_png_shadow_1024px.png");
            imageList1.Images.SetKeyName(1, "w_king_png_shadow_1024px.png");
            // 
            // wside
            // 
            wside.BackColor = Color.FromArgb(0, 192, 0);
            wside.ImageKey = "w_king_png_shadow_1024px.png";
            wside.ImageList = imageList1;
            wside.Location = new Point(37, 109);
            wside.Name = "wside";
            wside.Size = new Size(42, 42);
            wside.TabIndex = 15;
            wside.UseVisualStyleBackColor = false;
            // 
            // richTextBoxPGN
            // 
            richTextBoxPGN.Location = new Point(16, 310);
            richTextBoxPGN.Name = "richTextBoxPGN";
            richTextBoxPGN.Size = new Size(258, 93);
            richTextBoxPGN.TabIndex = 14;
            richTextBoxPGN.Text = "";
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.ImageKey = "w_king_png_shadow_1024px.png";
            button2.ImageList = imageList1;
            button2.Location = new Point(7, 10);
            button2.Name = "button2";
            button2.Size = new Size(42, 42);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.ImageKey = "b_king_png_shadow_1024px.png";
            button1.ImageList = imageList1;
            button1.Location = new Point(7, 60);
            button1.Name = "button1";
            button1.Size = new Size(42, 42);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = false;
            // 
            // BlackSide
            // 
            BlackSide.BackColor = Color.LemonChiffon;
            BlackSide.BorderStyle = BorderStyle.Fixed3D;
            BlackSide.Font = new Font("Segoe UI", 12F);
            BlackSide.Location = new Point(55, 65);
            BlackSide.Name = "BlackSide";
            BlackSide.Size = new Size(219, 29);
            BlackSide.TabIndex = 1;
            BlackSide.Text = "You";
            BlackSide.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // WhiteSide
            // 
            WhiteSide.BackColor = Color.LemonChiffon;
            WhiteSide.BorderStyle = BorderStyle.Fixed3D;
            WhiteSide.Font = new Font("Segoe UI", 12F);
            WhiteSide.Location = new Point(55, 23);
            WhiteSide.Name = "WhiteSide";
            WhiteSide.Size = new Size(219, 29);
            WhiteSide.TabIndex = 0;
            WhiteSide.Text = "You";
            WhiteSide.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 12);
            label1.Name = "label1";
            label1.Size = new Size(165, 23);
            label1.TabIndex = 11;
            label1.Text = "Match history";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(517, 12);
            label2.Name = "label2";
            label2.Size = new Size(123, 23);
            label2.TabIndex = 12;
            label2.Text = "Match info";
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BlanchedAlmond;
            ClientSize = new Size(800, 478);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(listBoxHistory);
            Name = "HistoryForm";
            Text = "HistoryForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxHistory;
        private Panel panel1;
        private Label WhiteSide;
        private Label label1;
        private Label label2;
        private Button button2;
        private ImageList imageList1;
        private Button button1;
        private Label BlackSide;
        private Label gameResult;
        private Button bside;
        private Button wside;
        private RichTextBox richTextBoxPGN;
        private Label label8;
        private Label gameTermination;
        private Button cpyBtn;
        private Label gameDate;
        private Button rvwBtn;
    }
}