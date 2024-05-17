namespace winforms_chat
{
    partial class ChatServerLog
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
            btn_listen = new Button();
            rtb_chatLog = new RichTextBox();
            btn_openCodeForm = new Button();
            SuspendLayout();
            // 
            // btn_listen
            // 
            btn_listen.Location = new Point(615, 12);
            btn_listen.Name = "btn_listen";
            btn_listen.Size = new Size(173, 65);
            btn_listen.TabIndex = 0;
            btn_listen.Text = "Listen";
            btn_listen.UseVisualStyleBackColor = true;
            btn_listen.Click += btnListen_Click;
            // 
            // rtb_chatLog
            // 
            rtb_chatLog.Location = new Point(12, 84);
            rtb_chatLog.Name = "rtb_chatLog";
            rtb_chatLog.Size = new Size(776, 354);
            rtb_chatLog.TabIndex = 1;
            rtb_chatLog.Text = "";
            // 
            // btn_openCodeForm
            // 
            btn_openCodeForm.Location = new Point(12, 13);
            btn_openCodeForm.Name = "btn_openCodeForm";
            btn_openCodeForm.Size = new Size(173, 65);
            btn_openCodeForm.TabIndex = 2;
            btn_openCodeForm.Text = "Open server code (require server opened)";
            btn_openCodeForm.UseVisualStyleBackColor = true;
            btn_openCodeForm.Click += btn_openCodeForm_Click;
            // 
            // ChatServerLog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_openCodeForm);
            Controls.Add(rtb_chatLog);
            Controls.Add(btn_listen);
            Name = "ChatServerLog";
            Text = "ChatServerLog";
            Load += ServerForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_listen;
        private System.Windows.Forms.RichTextBox rtb_chatLog;
        private Button btn_openCodeForm;
    }
}