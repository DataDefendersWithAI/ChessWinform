
namespace winforms_chat.ChatForm
{
	partial class Chatbox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chatbox));
            topPanel = new Panel();
            statusLabel = new Label();
            phoneLabel = new Label();
            clientnameLabel = new Label();
            bottomPanel = new Panel();
            chatTextbox = new TextBox();
            btn_emojis = new Button();
            attachButton = new Button();
            removeButton = new Button();
            sendButton = new Button();
            itemsPanel = new Panel();
            flp_emojisList = new FlowLayoutPanel();
            topPanel.SuspendLayout();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.RoyalBlue;
            topPanel.Controls.Add(statusLabel);
            topPanel.Controls.Add(phoneLabel);
            topPanel.Controls.Add(clientnameLabel);
            topPanel.Dock = DockStyle.Top;
            topPanel.ForeColor = SystemColors.ButtonHighlight;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(4, 3, 4, 3);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(18, 17, 18, 17);
            topPanel.Size = new Size(479, 89);
            topPanel.TabIndex = 0;
            topPanel.Paint += topPanel_Paint;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Dock = DockStyle.Right;
            statusLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            statusLabel.ForeColor = SystemColors.ControlLightLight;
            statusLabel.Location = new Point(394, 42);
            statusLabel.Margin = new Padding(4, 0, 4, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(67, 15);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "LastViewed";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Dock = DockStyle.Bottom;
            phoneLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            phoneLabel.ForeColor = SystemColors.ControlLightLight;
            phoneLabel.Location = new Point(18, 51);
            phoneLabel.Margin = new Padding(4, 0, 4, 0);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(117, 21);
            phoneLabel.TabIndex = 1;
            phoneLabel.Text = "(408) 262-9190";
            // 
            // clientnameLabel
            // 
            clientnameLabel.AutoSize = true;
            clientnameLabel.Dock = DockStyle.Top;
            clientnameLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            clientnameLabel.ForeColor = SystemColors.ControlLightLight;
            clientnameLabel.Location = new Point(18, 17);
            clientnameLabel.Margin = new Padding(4, 0, 4, 0);
            clientnameLabel.Name = "clientnameLabel";
            clientnameLabel.Size = new Size(119, 25);
            clientnameLabel.TabIndex = 0;
            clientnameLabel.Text = "Client Name";
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = Color.RoyalBlue;
            bottomPanel.Controls.Add(chatTextbox);
            bottomPanel.Controls.Add(btn_emojis);
            bottomPanel.Controls.Add(attachButton);
            bottomPanel.Controls.Add(removeButton);
            bottomPanel.Controls.Add(sendButton);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.ForeColor = SystemColors.ControlLightLight;
            bottomPanel.Location = new Point(0, 633);
            bottomPanel.Margin = new Padding(4, 3, 4, 3);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(18, 12, 18, 12);
            bottomPanel.Size = new Size(479, 62);
            bottomPanel.TabIndex = 1;
            // 
            // chatTextbox
            // 
            chatTextbox.Dock = DockStyle.Fill;
            chatTextbox.Font = new Font("Segoe UI", 12F);
            chatTextbox.Location = new Point(18, 12);
            chatTextbox.Margin = new Padding(4, 3, 4, 3);
            chatTextbox.MaxLength = 128;
            chatTextbox.Multiline = true;
            chatTextbox.Name = "chatTextbox";
            chatTextbox.PlaceholderText = "Please enter a message...";
            chatTextbox.Size = new Size(251, 38);
            chatTextbox.TabIndex = 7;
            // 
            // btn_emojis
            // 
            btn_emojis.BackColor = Color.GhostWhite;
            btn_emojis.BackgroundImage = (Image)resources.GetObject("btn_emojis.BackgroundImage");
            btn_emojis.BackgroundImageLayout = ImageLayout.Zoom;
            btn_emojis.Dock = DockStyle.Right;
            btn_emojis.FlatStyle = FlatStyle.Flat;
            btn_emojis.ForeColor = SystemColors.ControlText;
            btn_emojis.ImageAlign = ContentAlignment.MiddleLeft;
            btn_emojis.Location = new Point(269, 12);
            btn_emojis.Margin = new Padding(4, 3, 4, 3);
            btn_emojis.Name = "btn_emojis";
            btn_emojis.Size = new Size(41, 38);
            btn_emojis.TabIndex = 6;
            btn_emojis.TextAlign = ContentAlignment.MiddleRight;
            btn_emojis.UseVisualStyleBackColor = false;
            btn_emojis.Click += btn_emojis_Click;
            // 
            // attachButton
            // 
            attachButton.BackColor = Color.GhostWhite;
            attachButton.BackgroundImage = (Image)resources.GetObject("attachButton.BackgroundImage");
            attachButton.BackgroundImageLayout = ImageLayout.Center;
            attachButton.Dock = DockStyle.Right;
            attachButton.FlatStyle = FlatStyle.Flat;
            attachButton.ForeColor = SystemColors.ControlText;
            attachButton.ImageAlign = ContentAlignment.MiddleLeft;
            attachButton.Location = new Point(310, 12);
            attachButton.Margin = new Padding(4, 3, 4, 3);
            attachButton.Name = "attachButton";
            attachButton.Size = new Size(41, 38);
            attachButton.TabIndex = 6;
            attachButton.TextAlign = ContentAlignment.MiddleRight;
            attachButton.UseVisualStyleBackColor = false;
            attachButton.Click += attachButton_Click;
            // 
            // removeButton
            // 
            removeButton.BackColor = Color.Red;
            removeButton.Dock = DockStyle.Right;
            removeButton.FlatStyle = FlatStyle.Popup;
            removeButton.Font = new Font("Segoe UI Symbol", 9.75F, FontStyle.Bold);
            removeButton.ForeColor = SystemColors.ControlLightLight;
            removeButton.Location = new Point(351, 12);
            removeButton.Margin = new Padding(4, 3, 4, 3);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(22, 38);
            removeButton.TabIndex = 5;
            removeButton.Text = "X";
            removeButton.UseVisualStyleBackColor = false;
            removeButton.Visible = false;
            // 
            // sendButton
            // 
            sendButton.BackColor = Color.RoyalBlue;
            sendButton.Dock = DockStyle.Right;
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            sendButton.Location = new Point(373, 12);
            sendButton.Margin = new Padding(4, 3, 4, 3);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(88, 38);
            sendButton.TabIndex = 1;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = false;
            // 
            // itemsPanel
            // 
            itemsPanel.AutoScroll = true;
            itemsPanel.Dock = DockStyle.Fill;
            itemsPanel.Location = new Point(0, 89);
            itemsPanel.Margin = new Padding(4, 3, 4, 3);
            itemsPanel.Name = "itemsPanel";
            itemsPanel.Size = new Size(479, 544);
            itemsPanel.TabIndex = 2;
            // 
            // flp_emojisList
            // 
            flp_emojisList.Anchor = AnchorStyles.Bottom;
            flp_emojisList.AutoScroll = true;
            flp_emojisList.BackColor = Color.RoyalBlue;
            flp_emojisList.Location = new Point(160, 354);
            flp_emojisList.Margin = new Padding(3, 2, 3, 2);
            flp_emojisList.Name = "flp_emojisList";
            flp_emojisList.Size = new Size(252, 274);
            flp_emojisList.TabIndex = 2;
            flp_emojisList.Visible = false;
            // 
            // Chatbox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flp_emojisList);
            Controls.Add(itemsPanel);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Chatbox";
            Size = new Size(479, 695);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label phoneLabel;
		private System.Windows.Forms.Label clientnameLabel;
		private System.Windows.Forms.Panel bottomPanel;
		private System.Windows.Forms.Button sendButton;
		private System.Windows.Forms.Button attachButton;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.TextBox chatTextbox;
		private System.Windows.Forms.Panel itemsPanel;
        private System.Windows.Forms.Button btn_emojis;
        private System.Windows.Forms.FlowLayoutPanel flp_emojisList;
    }
}
