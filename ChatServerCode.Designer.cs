namespace winforms_chat
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
            button1 = new System.Windows.Forms.Button();
            listView1 = new System.Windows.Forms.ListView();
            label_statusText = new System.Windows.Forms.Label();
            btn_openListener = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(25, 23);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(197, 60);
            button1.TabIndex = 0;
            button1.Text = "Join 2 random people to random room";
            button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.HideSelection = false;
            listView1.Location = new System.Drawing.Point(25, 89);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(763, 358);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label_statusText
            // 
            label_statusText.AutoSize = true;
            label_statusText.Location = new System.Drawing.Point(288, 43);
            label_statusText.Name = "label_statusText";
            label_statusText.Size = new System.Drawing.Size(76, 20);
            label_statusText.TabIndex = 2;
            label_statusText.Text = "StatusText";
            // 
            // btn_openListener
            // 
            btn_openListener.Location = new System.Drawing.Point(591, 23);
            btn_openListener.Name = "btn_openListener";
            btn_openListener.Size = new System.Drawing.Size(197, 60);
            btn_openListener.TabIndex = 3;
            btn_openListener.Text = "Open listener (server must turn on!)";
            btn_openListener.UseVisualStyleBackColor = true;
            // 
            // ChatServerCode
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btn_openListener);
            Controls.Add(label_statusText);
            Controls.Add(listView1);
            Controls.Add(button1);
            Name = "ChatServerCode";
            Text = "ChatServer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label_statusText;
        private System.Windows.Forms.Button btn_openListener;
    }
}