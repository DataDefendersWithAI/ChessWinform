﻿
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
            topPanel.Margin = new Padding(5, 4, 5, 4);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(21, 23, 21, 23);
            topPanel.Size = new Size(547, 119);
            topPanel.TabIndex = 0;
            topPanel.Paint += topPanel_Paint;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Dock = DockStyle.Right;
            statusLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            statusLabel.ForeColor = SystemColors.ControlLightLight;
            statusLabel.Location = new Point(441, 55);
            statusLabel.Margin = new Padding(5, 0, 5, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(85, 20);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "LastViewed";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Dock = DockStyle.Bottom;
            phoneLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            phoneLabel.ForeColor = SystemColors.ControlLightLight;
            phoneLabel.Location = new Point(21, 68);
            phoneLabel.Margin = new Padding(5, 0, 5, 0);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(148, 28);
            phoneLabel.TabIndex = 1;
            phoneLabel.Text = "(408) 262-9190";
            // 
            // clientnameLabel
            // 
            clientnameLabel.AutoSize = true;
            clientnameLabel.Dock = DockStyle.Top;
            clientnameLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            clientnameLabel.ForeColor = SystemColors.ControlLightLight;
            clientnameLabel.Location = new Point(21, 23);
            clientnameLabel.Margin = new Padding(5, 0, 5, 0);
            clientnameLabel.Name = "clientnameLabel";
            clientnameLabel.Size = new Size(149, 32);
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
            bottomPanel.Location = new Point(0, 844);
            bottomPanel.Margin = new Padding(5, 4, 5, 4);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(21, 16, 21, 16);
            bottomPanel.Size = new Size(547, 83);
            bottomPanel.TabIndex = 1;
            // 
            // chatTextbox
            // 
            chatTextbox.Dock = DockStyle.Fill;
            chatTextbox.Font = new Font("Segoe UI", 12F);
            chatTextbox.Location = new Point(21, 16);
            chatTextbox.Margin = new Padding(5, 4, 5, 4);
            chatTextbox.MaxLength = 128;
            chatTextbox.Multiline = true;
            chatTextbox.Name = "chatTextbox";
            chatTextbox.PlaceholderText = "Please enter a message...";
            chatTextbox.Size = new Size(285, 51);
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
            btn_emojis.Location = new Point(306, 16);
            btn_emojis.Margin = new Padding(5, 4, 5, 4);
            btn_emojis.Name = "btn_emojis";
            btn_emojis.Size = new Size(47, 51);
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
            attachButton.Location = new Point(353, 16);
            attachButton.Margin = new Padding(5, 4, 5, 4);
            attachButton.Name = "attachButton";
            attachButton.Size = new Size(47, 51);
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
            removeButton.Location = new Point(400, 16);
            removeButton.Margin = new Padding(5, 4, 5, 4);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(25, 51);
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
            sendButton.Location = new Point(425, 16);
            sendButton.Margin = new Padding(5, 4, 5, 4);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(101, 51);
            sendButton.TabIndex = 1;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = false;
            // 
            // itemsPanel
            // 
            itemsPanel.AutoScroll = true;
            itemsPanel.Dock = DockStyle.Fill;
            itemsPanel.Location = new Point(0, 119);
            itemsPanel.Margin = new Padding(5, 4, 5, 4);
            itemsPanel.Name = "itemsPanel";
            itemsPanel.Size = new Size(547, 725);
            itemsPanel.TabIndex = 2;
            // 
            // flp_emojisList
            // 
            flp_emojisList.Anchor = AnchorStyles.Bottom;
            flp_emojisList.AutoScroll = true;
            flp_emojisList.BackColor = Color.RoyalBlue;
            flp_emojisList.Location = new Point(183, 472);
            flp_emojisList.Name = "flp_emojisList";
            flp_emojisList.Size = new Size(288, 365);
            flp_emojisList.TabIndex = 2;
            flp_emojisList.Visible = false;
            // 
            // Chatbox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(flp_emojisList);
            Controls.Add(itemsPanel);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Chatbox";
            Size = new Size(547, 927);
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