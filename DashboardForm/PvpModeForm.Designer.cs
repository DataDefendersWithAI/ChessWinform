namespace winform_chat.DashboardForm
{
    partial class PvpModeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PvpModeForm));
            btn_createRoom = new Button();
            label1 = new Label();
            btn_autoJoin = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            listBoxPlayerRooms = new ListBox();
            label3 = new Label();
            label4 = new Label();
            cntSvr = new Button();
            srvIP = new TextBox();
            button1 = new Button();
            strSvr = new Button();
            label5 = new Label();
            log1 = new Label();
            label6 = new Label();
            imageList1 = new ImageList(components);
            SuspendLayout();
            // 
            // btn_createRoom
            // 
            btn_createRoom.BackColor = Color.Salmon;
            btn_createRoom.Font = new Font("Showcard Gothic", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_createRoom.Location = new Point(502, 189);
            btn_createRoom.Margin = new Padding(3, 2, 3, 2);
            btn_createRoom.Name = "btn_createRoom";
            btn_createRoom.Size = new Size(253, 45);
            btn_createRoom.TabIndex = 2;
            btn_createRoom.Text = "Create Room";
            btn_createRoom.UseVisualStyleBackColor = false;
            btn_createRoom.Click += btn_createRoom_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 13F);
            label1.Location = new Point(33, 27);
            label1.Name = "label1";
            label1.Size = new Size(128, 23);
            label1.TabIndex = 3;
            label1.Text = "Select room";
            // 
            // btn_autoJoin
            // 
            btn_autoJoin.BackColor = Color.Chartreuse;
            btn_autoJoin.Font = new Font("Showcard Gothic", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_autoJoin.Location = new Point(502, 140);
            btn_autoJoin.Margin = new Padding(3, 2, 3, 2);
            btn_autoJoin.Name = "btn_autoJoin";
            btn_autoJoin.Size = new Size(253, 45);
            btn_autoJoin.TabIndex = 4;
            btn_autoJoin.Text = "🔄 Auto matching";
            btn_autoJoin.UseVisualStyleBackColor = false;
            btn_autoJoin.Click += btn_autoJoin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Showcard Gothic", 13F);
            label2.Location = new Point(505, 24);
            label2.Name = "label2";
            label2.Size = new Size(138, 23);
            label2.TabIndex = 5;
            label2.Text = "Time control";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.WhiteSmoke;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.Location = new Point(502, 55);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(253, 38);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // listBoxPlayerRooms
            // 
            listBoxPlayerRooms.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxPlayerRooms.BackColor = Color.Gainsboro;
            listBoxPlayerRooms.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxPlayerRooms.FormattingEnabled = true;
            listBoxPlayerRooms.ItemHeight = 32;
            listBoxPlayerRooms.Location = new Point(22, 55);
            listBoxPlayerRooms.Name = "listBoxPlayerRooms";
            listBoxPlayerRooms.Size = new Size(464, 420);
            listBoxPlayerRooms.TabIndex = 8;
            //listBoxPlayerRooms.SelectedIndexChanged += listBoxPlayerRooms_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(502, 96);
            label3.Name = "label3";
            label3.Size = new Size(252, 25);
            label3.TabIndex = 9;
            label3.Text = "Please select your time control";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(142, 537);
            label4.Name = "label4";
            label4.Size = new Size(501, 25);
            label4.TabIndex = 10;
            label4.Text = "Game mode: Minutes per game| increment seconds per move\r\n";
            // 
            // cntSvr
            // 
            cntSvr.BackColor = Color.PaleGreen;
            cntSvr.Font = new Font("Showcard Gothic", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cntSvr.Location = new Point(502, 387);
            cntSvr.Margin = new Padding(3, 2, 3, 2);
            cntSvr.Name = "cntSvr";
            cntSvr.Size = new Size(253, 45);
            cntSvr.TabIndex = 12;
            cntSvr.Text = "Connect server";
            cntSvr.UseVisualStyleBackColor = false;
            cntSvr.Click += cntSvr_Click;
            // 
            // srvIP
            // 
            srvIP.BackColor = Color.Azure;
            srvIP.BorderStyle = BorderStyle.None;
            srvIP.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            srvIP.ForeColor = SystemColors.InactiveCaption;
            srvIP.Location = new Point(502, 349);
            srvIP.Margin = new Padding(3, 2, 3, 2);
            srvIP.Name = "srvIP";
            srvIP.Size = new Size(253, 25);
            srvIP.TabIndex = 13;
            srvIP.Text = "Enter server IP";
            srvIP.TextChanged += srvIP_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.Wheat;
            button1.Font = new Font("Showcard Gothic", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(502, 238);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(253, 45);
            button1.TabIndex = 14;
            button1.Text = "refresh";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // strSvr
            // 
            strSvr.BackColor = Color.Yellow;
            strSvr.Font = new Font("Showcard Gothic", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            strSvr.Location = new Point(502, 436);
            strSvr.Margin = new Padding(3, 2, 3, 2);
            strSvr.Name = "strSvr";
            strSvr.Size = new Size(253, 45);
            strSvr.TabIndex = 15;
            strSvr.Text = "Start server";
            strSvr.UseVisualStyleBackColor = false;
            strSvr.Click += strSvr_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Malgun Gothic", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(167, 24);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(96, 25);
            label5.TabIndex = 16;
            label5.Text = "Player 999";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // log1
            // 
            log1.AutoSize = true;
            log1.Font = new Font("Segoe UI", 13F);
            log1.ForeColor = Color.Red;
            log1.Location = new Point(502, 312);
            log1.Name = "log1";
            log1.Size = new Size(253, 25);
            log1.TabIndex = 17;
            log1.Text = "Please select your game mode";
            // 
            // label6
            // 
            label6.ImageIndex = 0;
            label6.ImageList = imageList1;
            label6.Location = new Point(649, 9);
            label6.Name = "label6";
            label6.Size = new Size(37, 43);
            label6.TabIndex = 25;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Clock.png");
            // 
            // PvpModeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(772, 571);
            Controls.Add(label6);
            Controls.Add(log1);
            Controls.Add(label5);
            Controls.Add(strSvr);
            Controls.Add(button1);
            Controls.Add(srvIP);
            Controls.Add(cntSvr);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(listBoxPlayerRooms);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(btn_autoJoin);
            Controls.Add(label1);
            Controls.Add(btn_createRoom);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PvpModeForm";
            Text = "ChatServer";
            FormClosing += ClientForm_FormClosed;
            Load += ClientForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_createRoom;
        private Label label1;
        private Button btn_autoJoin;
        private Label label2;
        private ComboBox comboBox1;
        private ListBox listBoxPlayerRooms;
        private Label label3;
        private Label label4;
        private Button cntSvr;
        private TextBox srvIP;
        private Button button1;
        private Button strSvr;
        private Label label5;
        private Label log1;
        private Label label6;
        private ImageList imageList1;
    }
}