namespace ChessAI
{
    partial class ChatBox_Server_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatBox_Server_Form));
            btnListen = new Button();
            richTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.BackColor = Color.PaleGreen;
            btnListen.Location = new Point(545, 19);
            btnListen.Margin = new Padding(3, 2, 3, 2);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(108, 36);
            btnListen.TabIndex = 0;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = false;
            btnListen.Click += btnListen_Click;
            // 
            // richTextBox
            // 
            richTextBox.Location = new Point(13, 72);
            richTextBox.Margin = new Padding(3, 2, 3, 2);
            richTextBox.Name = "richTextBox";
            richTextBox.ReadOnly = true;
            richTextBox.Size = new Size(677, 258);
            richTextBox.TabIndex = 1;
            richTextBox.Text = "";
            // 
            // ChatBox_Server_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(700, 338);
            Controls.Add(richTextBox);
            Controls.Add(btnListen);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChatBox_Server_Form";
            Text = "ChatBox_Server_Form";
            Load += ServerForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnListen;
        private RichTextBox richTextBox;
    }
}