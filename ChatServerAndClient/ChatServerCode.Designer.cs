﻿namespace winforms_chat
{
    partial class ChatServerCode
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
            btn_joinRandom = new Button();
            listview_userQueue = new ListView();
            btn_autoJoin = new Button();
            SuspendLayout();
            // 
            // btn_joinRandom
            // 
            btn_joinRandom.Location = new Point(25, 23);
            btn_joinRandom.Name = "btn_joinRandom";
            btn_joinRandom.Size = new Size(197, 60);
            btn_joinRandom.TabIndex = 0;
            btn_joinRandom.Text = "Join 2 random people to random room";
            btn_joinRandom.UseVisualStyleBackColor = true;
            btn_joinRandom.Click += btn_joinRandom_Click;
            // 
            // listview_userQueue
            // 
            listview_userQueue.Location = new Point(25, 89);
            listview_userQueue.Name = "listview_userQueue";
            listview_userQueue.Size = new Size(763, 358);
            listview_userQueue.TabIndex = 1;
            listview_userQueue.UseCompatibleStateImageBehavior = false;
            // 
            // btn_autoJoin
            // 
            btn_autoJoin.Location = new Point(248, 23);
            btn_autoJoin.Name = "btn_autoJoin";
            btn_autoJoin.Size = new Size(197, 60);
            btn_autoJoin.TabIndex = 2;
            btn_autoJoin.Text = "Auto join 2 random people to random room";
            btn_autoJoin.UseVisualStyleBackColor = true;
            btn_autoJoin.Click += btn_autoJoin_Click;
            // 
            // ChatServerCode
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_autoJoin);
            Controls.Add(listview_userQueue);
            Controls.Add(btn_joinRandom);
            Name = "ChatServerCode";
            Text = "ChatServer";
            FormClosed += ClientForm_FormClosed;
            Load += ClientForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_joinRandom;
        private System.Windows.Forms.ListView listview_userQueue;
        private Button btn_autoJoin;
    }
}