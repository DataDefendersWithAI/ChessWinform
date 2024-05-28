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
            btn_createRoom = new Button();
            label1 = new Label();
            btn_autoJoin = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            listBoxPlayerRooms = new ListBox();
            listview_userQueue = new ListView();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btn_createRoom
            // 
            btn_createRoom.BackColor = Color.Salmon;
            btn_createRoom.Font = new Font("Showcard Gothic", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_createRoom.Location = new Point(502, 310);
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
            btn_autoJoin.Location = new Point(502, 261);
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
            label2.Location = new Point(515, 27);
            label2.Name = "label2";
            label2.Size = new Size(113, 23);
            label2.TabIndex = 5;
            label2.Text = "Game mode";
            label2.Click += label2_Click;
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
            listBoxPlayerRooms.Size = new Size(464, 324);
            listBoxPlayerRooms.TabIndex = 8;
            // 
            // listview_userQueue
            // 
            listview_userQueue.Location = new Point(533, 128);
            listview_userQueue.Margin = new Padding(3, 2, 3, 2);
            listview_userQueue.Name = "listview_userQueue";
            listview_userQueue.Size = new Size(186, 129);
            listview_userQueue.TabIndex = 1;
            listview_userQueue.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(502, 96);
            label3.Name = "label3";
            label3.Size = new Size(253, 25);
            label3.TabIndex = 9;
            label3.Text = "Please select your game mode";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(142, 406);
            label4.Name = "label4";
            label4.Size = new Size(501, 25);
            label4.TabIndex = 10;
            label4.Text = "Game mode: Minutes per game| increment seconds per move\r\n";
            // 
            // PvpModeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(767, 440);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(listBoxPlayerRooms);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(btn_autoJoin);
            Controls.Add(label1);
            Controls.Add(btn_createRoom);
            Controls.Add(listview_userQueue);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PvpModeForm";
            Text = "ChatServer";
            FormClosed += ClientForm_FormClosed;
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
        private ListView listview_userQueue;
        private Label label3;
        private Label label4;
    }
}