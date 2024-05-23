namespace winforms_chat
{
    partial class SpawnClientAndServer
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
            btn_server = new System.Windows.Forms.Button();
            btn_client = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btn_server
            // 
            btn_server.Location = new System.Drawing.Point(205, 70);
            btn_server.Name = "btn_server";
            btn_server.Size = new System.Drawing.Size(396, 81);
            btn_server.TabIndex = 0;
            btn_server.Text = "Spawn Server";
            btn_server.UseVisualStyleBackColor = true;
            btn_server.Click += btn_server_Click;
            // 
            // btn_client
            // 
            btn_client.Location = new System.Drawing.Point(205, 241);
            btn_client.Name = "btn_client";
            btn_client.Size = new System.Drawing.Size(396, 81);
            btn_client.TabIndex = 1;
            btn_client.Text = "Spawn Client";
            btn_client.UseVisualStyleBackColor = true;
            btn_client.Click += btn_client_Click;
            // 
            // SpawnClientAndServer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btn_client);
            Controls.Add(btn_server);
            Name = "SpawnClientAndServer";
            Text = "SpawnClientAndServer";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_server;
        private System.Windows.Forms.Button btn_client;
    }
}