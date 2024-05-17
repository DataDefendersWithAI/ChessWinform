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
            button1 = new Button();
            listView1 = new ListView();
            label_statusText = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(25, 23);
            button1.Name = "button1";
            button1.Size = new Size(197, 60);
            button1.TabIndex = 0;
            button1.Text = "Join 2 random people to random room";
            button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Location = new Point(25, 89);
            listView1.Name = "listView1";
            listView1.Size = new Size(763, 358);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label_statusText
            // 
            label_statusText.AutoSize = true;
            label_statusText.Location = new Point(288, 43);
            label_statusText.Name = "label_statusText";
            label_statusText.Size = new Size(76, 20);
            label_statusText.TabIndex = 2;
            label_statusText.Text = "StatusText";
            // 
            // ChatServerCode
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}