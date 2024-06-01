namespace winform_chat.DashboardForm
{
    partial class HistoryForm
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
            listBoxHistory = new ListBox();
            SuspendLayout();
            // 
            // listBoxHistory
            // 
            listBoxHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBoxHistory.BackColor = Color.Gainsboro;
            listBoxHistory.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxHistory.FormattingEnabled = true;
            listBoxHistory.ItemHeight = 32;
            listBoxHistory.Location = new Point(33, 12);
            listBoxHistory.Name = "listBoxHistory";
            listBoxHistory.Size = new Size(464, 420);
            listBoxHistory.TabIndex = 9;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BlanchedAlmond;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxHistory);
            Name = "HistoryForm";
            Text = "HistoryForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxHistory;
    }
}