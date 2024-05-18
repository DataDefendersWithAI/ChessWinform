namespace ChessAI
{
    partial class Lab3_Bai4
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
            btn_startServer = new Button();
            btn_startClient = new Button();
            SuspendLayout();
            // 
            // btn_startServer
            // 
            btn_startServer.BackColor = Color.PaleGreen;
            btn_startServer.Font = new Font("Segoe UI", 13F);
            btn_startServer.Location = new Point(282, 129);
            btn_startServer.Name = "btn_startServer";
            btn_startServer.Size = new Size(215, 85);
            btn_startServer.TabIndex = 0;
            btn_startServer.Text = "Start Chat Server";
            btn_startServer.UseVisualStyleBackColor = false;
            btn_startServer.Click += btn_startServer_Click;
            // 
            // btn_startClient
            // 
            btn_startClient.BackColor = Color.PaleGreen;
            btn_startClient.Font = new Font("Segoe UI", 13F);
            btn_startClient.Location = new Point(282, 250);
            btn_startClient.Name = "btn_startClient";
            btn_startClient.Size = new Size(215, 80);
            btn_startClient.TabIndex = 1;
            btn_startClient.Text = "Start Chat Client";
            btn_startClient.UseVisualStyleBackColor = false;
            btn_startClient.Click += btn_startClient_Click;
            // 
            // Lab3_Bai4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_startClient);
            Controls.Add(btn_startServer);
            Name = "Lab3_Bai4";
            Text = "Lab3_Bai4";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_startServer;
        private Button btn_startClient;
    }
}