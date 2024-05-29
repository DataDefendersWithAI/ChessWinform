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
            pnl_wait = new Panel();
            pnl_wait.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 25.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(65, 146);
            label1.Name = "label1";
            label1.Size = new Size(529, 43);
            label1.TabIndex = 0;
            label1.Text = "Your game will start soon!";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(207, 243);
            label2.Name = "label2";
            label2.Size = new Size(234, 19);
            label2.TabIndex = 1;
            label2.Text = "To cancel request, click Cancel below!";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_cancel
            // 
            btn_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_cancel.BackColor = Color.LightCoral;
            btn_cancel.Font = new Font("Segoe UI", 15F);
            btn_cancel.Location = new Point(251, 278);
            btn_cancel.Margin = new Padding(3, 2, 3, 2);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(157, 40);
            btn_cancel.TabIndex = 2;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = false;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // pnl_wait
            // 
            pnl_wait.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_wait.Controls.Add(label2);
            pnl_wait.Controls.Add(btn_cancel);
            pnl_wait.Controls.Add(label1);
            pnl_wait.Location = new Point(-1, 0);
            pnl_wait.Margin = new Padding(3, 2, 3, 2);
            pnl_wait.Name = "pnl_wait";
            pnl_wait.Size = new Size(704, 337);
            pnl_wait.TabIndex = 6;
            // 
            // ChatClientJoin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(pnl_wait);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ChatClientJoin";
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
        private Panel pnl_wait;
    }
}