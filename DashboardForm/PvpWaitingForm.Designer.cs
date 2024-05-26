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
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 23F);
            label1.Location = new Point(134, 180);
            label1.Name = "label1";
            label1.Size = new Size(372, 42);
            label1.TabIndex = 0;
            label1.Text = "Your game will start soon!";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(174, 258);
            label2.Name = "label2";
            label2.Size = new Size(303, 25);
            label2.TabIndex = 1;
            label2.Text = "To cancel request, click Cancel below!";
            // 
            // btn_cancel
            // 
            btn_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_cancel.Location = new Point(249, 285);
            btn_cancel.Margin = new Padding(3, 2, 3, 2);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(142, 39);
            btn_cancel.TabIndex = 2;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(140, 354);
            label3.Name = "label3";
            label3.Size = new Size(366, 21);
            label3.TabIndex = 3;
            label3.Text = "This dialog will automatically close after game start.";
            label3.Click += label3_Click;
            // 
            // pnl_wait
            // 
            pnl_wait.BackColor = Color.MintCream;
            pnl_wait.Controls.Add(label2);
            pnl_wait.Controls.Add(btn_cancel);
            pnl_wait.Controls.Add(label1);
            pnl_wait.Controls.Add(label3);
            pnl_wait.Dock = DockStyle.Fill;
            pnl_wait.Location = new Point(0, 0);
            pnl_wait.Margin = new Padding(3, 2, 3, 2);
            pnl_wait.Name = "pnl_wait";
            pnl_wait.Size = new Size(672, 397);
            pnl_wait.TabIndex = 6;
            // 
            // PvpWaitingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 397);
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