namespace winform_chat
{
    partial class PvpForm
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
            listview_userQueue = new ListView();
            btn_autoJoin = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // listview_userQueue
            // 
            listview_userQueue.Location = new Point(25, 69);
            listview_userQueue.Name = "listview_userQueue";
            listview_userQueue.Size = new Size(501, 378);
            listview_userQueue.TabIndex = 1;
            listview_userQueue.UseCompatibleStateImageBehavior = false;
            // 
            // btn_autoJoin
            // 
            btn_autoJoin.Font = new Font("Segoe UI", 13F);
            btn_autoJoin.Location = new Point(553, 205);
            btn_autoJoin.Name = "btn_autoJoin";
            btn_autoJoin.Size = new Size(212, 60);
            btn_autoJoin.TabIndex = 2;
            btn_autoJoin.Text = "🔄 Auto matching";
            btn_autoJoin.UseVisualStyleBackColor = true;
            btn_autoJoin.Click += btn_autoJoin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(25, 36);
            label1.Name = "label1";
            label1.Size = new Size(130, 30);
            label1.TabIndex = 3;
            label1.Text = "Select room";
            // 
            // PvpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btn_autoJoin);
            Controls.Add(listview_userQueue);
            Name = "PvpForm";
            Text = "ChatServer";
            FormClosed += ClientForm_FormClosed;
            Load += ClientForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ListView listview_userQueue;
        private Button btn_autoJoin;
        private Label label1;
    }
}