using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winforms_chat
{
	public partial class ChatMainForm : Form
	{
		public ChatMainForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ChatForm.ChatboxInfo cbi = new ChatForm.ChatboxInfo();
			cbi.NamePlaceholder = "Chatbox";
			cbi.PhonePlaceholder = "For table: 123456";

			var chat_panel = new ChatForm.Chatbox(cbi);
			chat_panel.Name = "chat_panel";
			chat_panel.Dock = DockStyle.Fill;
			this.Controls.Add(chat_panel);

            // Test: Add message to chatbox with message "Hello World!"
            chat_panel.AddMessage(new ChatForm.TextChatModel() { Author = "System", Body = "Joined chat in table 123456!", Inbound = true, Time = DateTime.Now });
            chat_panel.AddMessage(new ChatForm.TextChatModel() { Author = "OtherPlayer", Body = "Hello World!", Inbound = true, Time = DateTime.Now });
		}
	}
}
