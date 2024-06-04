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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatServerLog));
            btn_listen = new Button();
            rtb_chatLog = new RichTextBox();
            btn_openCodeForm = new Button();
            SuspendLayout();
            // 
            // btn_listen
            // 
            btn_listen.Location = new Point(538, 9);
            btn_listen.Margin = new Padding(3, 2, 3, 2);
            btn_listen.Name = "btn_listen";
            btn_listen.Size = new Size(151, 49);
            btn_listen.TabIndex = 0;
            btn_listen.Text = "Listen";
            btn_listen.UseVisualStyleBackColor = true;
            btn_listen.Click += btnListen_Click;
            // 
            // rtb_chatLog
            // 
            rtb_chatLog.Location = new Point(10, 63);
            rtb_chatLog.Margin = new Padding(3, 2, 3, 2);
            rtb_chatLog.Name = "rtb_chatLog";
            rtb_chatLog.Size = new Size(680, 266);
            rtb_chatLog.TabIndex = 1;
            rtb_chatLog.Text = "";
            // 
            // btn_openCodeForm
            // 
            btn_openCodeForm.Location = new Point(10, 10);
            btn_openCodeForm.Margin = new Padding(3, 2, 3, 2);
            btn_openCodeForm.Name = "btn_openCodeForm";
            btn_openCodeForm.Size = new Size(151, 49);
            btn_openCodeForm.TabIndex = 2;
            btn_openCodeForm.Text = "Open server code (require server opened)";
            btn_openCodeForm.UseVisualStyleBackColor = true;
            btn_openCodeForm.Click += btn_openCodeForm_Click;
            // 
            // ChatServerLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btn_openCodeForm);
            Controls.Add(rtb_chatLog);
            Controls.Add(btn_listen);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
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