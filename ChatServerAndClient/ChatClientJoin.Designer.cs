namespace winforms_chat
{
    partial class ChatClientJoin
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
            label1 = new Label();
            label2 = new Label();
            btn_cancel = new Button();
            label3 = new Label();
            label4 = new Label();
            txt_userName = new TextBox();
            pnl_wait = new Panel();
            btn_join = new Button();
            pnl_join = new Panel();
            label5 = new Label();
            pnl_wait.SuspendLayout();
            pnl_join.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 29);
            label1.Name = "label1";
            label1.Size = new Size(170, 20);
            label1.TabIndex = 0;
            label1.Text = "Your chat will start soon!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 74);
            label2.Name = "label2";
            label2.Size = new Size(257, 20);
            label2.TabIndex = 1;
            label2.Text = "To cancel request, click Cancel below!";
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(136, 125);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(94, 29);
            btn_cancel.TabIndex = 2;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 169);
            label3.Name = "label3";
            label3.Size = new Size(357, 20);
            label3.TabIndex = 3;
            label3.Text = "This dialog will automatically close after joined chat.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 24);
            label4.Name = "label4";
            label4.Size = new Size(150, 20);
            label4.TabIndex = 4;
            label4.Text = "Enter your name here";
            // 
            // txt_userName
            // 
            txt_userName.Location = new Point(191, 21);
            txt_userName.Name = "txt_userName";
            txt_userName.Size = new Size(158, 27);
            txt_userName.TabIndex = 5;
            // 
            // pnl_wait
            // 
            pnl_wait.Controls.Add(label2);
            pnl_wait.Controls.Add(btn_cancel);
            pnl_wait.Controls.Add(label1);
            pnl_wait.Controls.Add(label3);
            pnl_wait.Location = new Point(213, 184);
            pnl_wait.Name = "pnl_wait";
            pnl_wait.Size = new Size(370, 217);
            pnl_wait.TabIndex = 6;
            pnl_wait.Visible = false;
            // 
            // btn_join
            // 
            btn_join.Location = new Point(136, 84);
            btn_join.Name = "btn_join";
            btn_join.Size = new Size(94, 29);
            btn_join.TabIndex = 7;
            btn_join.Text = "Join";
            btn_join.UseVisualStyleBackColor = true;
            btn_join.Click += btn_join_Click;
            // 
            // pnl_join
            // 
            pnl_join.Controls.Add(label4);
            pnl_join.Controls.Add(btn_join);
            pnl_join.Controls.Add(txt_userName);
            pnl_join.Location = new Point(213, 30);
            pnl_join.Name = "pnl_join";
            pnl_join.Size = new Size(370, 148);
            pnl_join.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 421);
            label5.Name = "label5";
            label5.Size = new Size(749, 20);
            label5.TabIndex = 9;
            label5.Text = "Note: In this demo, you must enter distinct name to identify you on server. Real app identify you by unique UUID";
            // 
            // ChatClientJoin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(pnl_join);
            Controls.Add(pnl_wait);
            Name = "ChatClientJoin";
            Text = "ChatClientJoin";
            FormClosing += ClientForm_FormClosing;
            Load += ClientForm_Load;
            pnl_wait.ResumeLayout(false);
            pnl_wait.PerformLayout();
            pnl_join.ResumeLayout(false);
            pnl_join.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label3;
        private Label label4;
        private TextBox txt_userName;
        private Panel pnl_wait;
        private Button btn_join;
        private Panel pnl_join;
        private Label label5;
    }
}