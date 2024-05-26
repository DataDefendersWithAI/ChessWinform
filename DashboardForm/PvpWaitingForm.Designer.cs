namespace winform_chat.DashboardForm
{
    partial class PvpWaitingForm
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
            pnl_wait = new Panel();
            pnl_wait.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 22);
            label1.Name = "label1";
            label1.Size = new Size(143, 15);
            label1.TabIndex = 0;
            label1.Text = "Your game will start soon!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 56);
            label2.Name = "label2";
            label2.Size = new Size(205, 15);
            label2.TabIndex = 1;
            label2.Text = "To cancel request, click Cancel below!";
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(119, 94);
            btn_cancel.Margin = new Padding(3, 2, 3, 2);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(82, 22);
            btn_cancel.TabIndex = 2;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 128);
            label3.Name = "label3";
            label3.Size = new Size(279, 15);
            label3.TabIndex = 3;
            label3.Text = "This dialog will automatically close after game start.";
            // 
            // pnl_wait
            // 
            pnl_wait.Controls.Add(label2);
            pnl_wait.Controls.Add(btn_cancel);
            pnl_wait.Controls.Add(label1);
            pnl_wait.Controls.Add(label3);
            pnl_wait.Location = new Point(13, 11);
            pnl_wait.Margin = new Padding(3, 2, 3, 2);
            pnl_wait.Name = "pnl_wait";
            pnl_wait.Size = new Size(324, 163);
            pnl_wait.TabIndex = 6;
            // 
            // PvpWaitingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 188);
            Controls.Add(pnl_wait);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PvpWaitingForm";
            Text = "PvpWaitingForm";
            FormClosing += ClientForm_FormClosing;
            Load += ClientForm_Load;
            pnl_wait.ResumeLayout(false);
            pnl_wait.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label3;
        private Panel pnl_wait;
    }
}