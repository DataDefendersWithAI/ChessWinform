using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace winforms_chat.ChatForm
{
    public partial class Chatbox : UserControl
    {
        public ChatboxInfo chatbox_info;
        public OpenFileDialog fileDialog = new OpenFileDialog();
        public string initialdirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private Action<string> sendHandler;

        public Chatbox(ChatboxInfo _chatbox_info, Action<string> sendHandler)
        {
            InitializeComponent();

            chatbox_info = _chatbox_info;

            clientnameLabel.Text = chatbox_info.NamePlaceholder;
            statusLabel.Text = chatbox_info.StatusPlaceholder;
            phoneLabel.Text = chatbox_info.PhonePlaceholder;
            chatTextbox.Text = chatbox_info.ChatPlaceholder;

            chatTextbox.Enter += ChatEnter;
            chatTextbox.Leave += ChatLeave;
            sendButton.Click += SendMessage;
            attachButton.Click += BuildAttachment;
            removeButton.Click += CancelAttachment;

            chatTextbox.KeyDown += OnEnter;
            this.sendHandler = sendHandler;

            // Because this isn't chat software, we'll remove first chat item.
            // AddMessage(null);
        }

        /// <summary>
        /// ChatItem objects are generated dynamically from IChatModel. By default, a ChatItem is allowed to be resized up to 60% of the entire screen.
        /// I've thought about it being editable from outside, but there's no real need to.
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(IChatModel message)
        {
            var chatItem = new ChatItem(message);
            chatItem.Name = "chatItem" + itemsPanel.Controls.Count;
            chatItem.Dock = DockStyle.Top;
            itemsPanel.Controls.Add(chatItem);
            chatItem.BringToFront();

            chatItem.ResizeBubbles((int)(itemsPanel.Width * 0.6));

            itemsPanel.ScrollControlIntoView(chatItem);
        }

        //Improves the chat UI slightly by having a placeholder text. Note that this is implemented because Winforms doesn't have a native "placeholder" UI. Can be buggy.
        void ChatLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(chatTextbox.Text))
            {
                chatTextbox.Text = chatbox_info.ChatPlaceholder;
                chatTextbox.ForeColor = Color.Gray;
            }
        }

        //Improves the chat UI slightly by having a placeholder text. Note that this is implemented because Winforms doesn't have a native "placeholder" UI. Can be buggy.
        void ChatEnter(object sender, EventArgs e)
        {
            chatTextbox.ForeColor = Color.Black;
            if (chatTextbox.Text == chatbox_info.ChatPlaceholder)
            {
                chatTextbox.Text = "";
            }
        }

        //Cross-tested this with the Twilio API and the RingCentral API, and async messaging is the way to go.
        async void SendMessage(object sender, EventArgs e)
        {
            string tonumber = phoneLabel.Text;
            string chatmessage = chatTextbox.Text;

            IChatModel chatModel = null;
            TextChatModel textModel = null;

            //Each IChatModel is specifically built for a single purpose. For that reason, if you want to display a text item AND and image, you'd make two IChatModels for
            //their respective purposes. AttachmentChatModel and ImageChatModel, however, can really be used interchangeably.
            if (chatbox_info.Attachment != null && chatbox_info.AttachmentType.Contains("image"))
            {
                chatModel = new ImageChatModel()
                {
                    Author = chatbox_info.User,
                    Image = Image.FromStream(new MemoryStream(chatbox_info.Attachment)),
                    ImageName = chatbox_info.AttachmentName,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now,
                };

            }
            else if (chatbox_info.Attachment != null)
            {
                chatModel = new AttachmentChatModel()
                {
                    Author = chatbox_info.User,
                    Attachment = chatbox_info.Attachment,
                    Filename = chatbox_info.AttachmentName,
                    Read = true,
                    Inbound = false,
                    Time = DateTime.Now
                };
            }

            if (!string.IsNullOrWhiteSpace(chatmessage) && chatmessage != chatbox_info.ChatPlaceholder)
            {
                textModel = new TextChatModel()
                {
                    Author = chatbox_info.User,
                    Body = chatmessage,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now
                };
            }

            try
            {
                /*

                    INSERT SENDING LOGIC HERE. Again, this is just a UserControl, not a complete app. For the Ringcentral API, I was able to reduce this section
                    down to a single method.

                */

                // Send the message with JSON format
                // Send message: {"TableCode": newTableCode, "type": "chat", "from": userName, "to": opponentUserName, "message": message, "date": DateTime.Now}

                // Send message to server
                sendHandler?.Invoke(chatmessage);

                /*
                 * END OF SENDING LOGIC
                 */

                if (chatModel != null)
                {
                    AddMessage(chatModel);
                    CancelAttachment(null, null);
                }
                if (textModel != null)
                {
                    AddMessage(textModel);
                    chatTextbox.Text = string.Empty;
                }
            }
            catch (Exception exc)
            {
                //If any exception is found, then it is printed on the screen. Feel free to change this method if you don't want people to see exceptions.
                textModel = new TextChatModel()
                {
                    Author = chatbox_info.User,
                    Body = "The message could not be processed. Please see the reason below.\r\n" + exc.Message,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now
                };
                AddMessage(textModel);
            }
        }

        void BuildAttachment(object sender, EventArgs e)
        {
            fileDialog.InitialDirectory = initialdirectory;
            fileDialog.Reset();
            fileDialog.Multiselect = false;

            var result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selected = fileDialog.FileName;
                try
                {
                    var file = File.ReadAllBytes(selected);
                    //Limits the size of the attachment to 1.45 MB, which is less than the max possible size of an SMS attachment of 1.5 MB.
                    if (file.Length > 1450000)
                    {
                        //MessageBox.Show("The attachment provided " + fileDialog.SafeFileName + " is too big to be sent by SMS. Please select another.", "Attachment not added.");
                        Debug.WriteLine("The attachment provided " + fileDialog.SafeFileName + " is too big to be sent by SMS. Please select another.");
                        return;
                    }
                    else
                    {
                        chatbox_info.Attachment = file;
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show("There was an issue with retrieving the file.", "File Operation Error");
                    Debug.WriteLine("There was an issue with retrieving the file.");
                }
            }
            else
            {
                return;
            }

            if (chatbox_info.Attachment != null)
            {
                string smallname = fileDialog.SafeFileName;
                chatbox_info.AttachmentName = fileDialog.SafeFileName;

                string name = Path.GetFileNameWithoutExtension(smallname);
                string extension = Path.GetExtension(smallname);
                if (smallname.Length > 12)
                {
                    smallname = name.Substring(0, 7) + ".." + extension;
                    attachButton.Text = smallname;
                }
                else
                {
                    attachButton.Text = smallname;
                }

                removeButton.Visible = true;
                attachButton.Width = 115;
                chatbox_info.AttachmentType = ChatUtility.GetMimeType(extension);
            }
        }

        void CancelAttachment(object sender, EventArgs e)
        {
            attachButton.Text = string.Empty;
            chatbox_info.Attachment = null;
            chatbox_info.AttachmentName = null;
            chatbox_info.AttachmentType = null;
            removeButton.Visible = false;
            attachButton.Width = 35;
        }

        //Inspired from Slack, you can also press Shift + Enter to enter text.
        async void OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyValue == 13)
            {
                SendMessage(this, null);
            }
        }

        //When the Control resizes, it will trigger the resize event for all the ChatItem object inside as well, again with a default width of 60%.
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            foreach (var control in itemsPanel.Controls)
            {
                if (control is ChatItem)
                {
                    (control as ChatItem).ResizeBubbles((int)(itemsPanel.Width * 0.6));
                }
            }
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void attachButton_Click(object sender, EventArgs e)
        {

        }

        // JakeClark's work to add emojis to the chatbox

        // Define list of emojis - chess pieces
        string[] emojis = { "♔", "♕", "♖", "♗", "♘", "♙", "♚", "♛", "♜", "♝", "♞", "♟",
            // Append face emojis
            "😀", "😁", "😂", "🤣", "😃", "😄", "😅", "😆", "😉", "😊", "😋", "😎", "😍", "😘", "😗", "😙", "😚", "☺", "🙂", "🤗", "🤩", "🤔", "🤨", "😐", "😑", "😶", "🙄", "😏", "😣", "😥", "😮", "🤐", "😯", "😪", "😫", "😴", "😌", "😛", "😜", "😝", "🤤", "😒", "😓", "😔", "😕", "🙃", "🤑", "😲", "☹", "🙁", "😖", "😞", "😟", "😤", "😢", "😭", "😦", "😧", "😨", "😩", "🤯", "😬", "😰", "😱", "😳", "🤪", "😵", "😡", "😠", "🤬", "😷", "🤒", "🤕", "🤢", "🤮", "🤧", "😇", "🤠", "🤡", "🤥", "🤫", "🤭", "🧐", "🤓", "😈", "👿", "👹", "👺", "💀", "👻", "👽", "🤖", "💩", "😺", "😸", "😹", "😻", "😼", "😽", "🙀", "😿", "😾",
            // Append hand emojis
            "👍", "👎", "👌", "👊", "✊", "🤛", "🤜", "🤞", "✌", "🤘", "🤟", "👈", "👉", "👆", "👇", "☝", "👋", "🤚", "🖐", "✋", "🖖", "👏", "🙌", "👐", "🤲", "🤝", "🙏", "✍", "💅", "🤳", "💪", "🦵", "🦶", "👂", "👃", "🧠", "🦷", "🦴", "👀", "👁", "👅", "👄", "💋", "👓", "🕶", "🥽", "🥼", "🦺", "👔", "👕", "👖", "🧣", "🧤", "🧥", "🧦", "👗", "👘", "👙", "👚", "👛", "👜", "👝", "🛍", "🎒", "👞", "👟", "🥾", "🥿", "👠", "👡", "🩰", "👢", "👑", "👒", "🎩", "🎓", "🧢", "⛑", "📿", "💄", "💍", "💎", "🐵", "🐒", "🦍", "🦧", "🐶", "🐕", "🦮", "🐕‍🦺", "🐩", "🐺", "🦊", "🦝", "🐱", "🐈", "🐈‍⬛", "🦁", "🐯", "🐅",
            // Add animal emojis
            "🐆", "🐴", "🐎", "🦄", "🦓", "🦌", "🦬", "🐮", "🐂", "🐃", "🐄", "🐷", "🐖", "🐗", "🐽", "🐏", "🐑", "🐐", "🐪", "🐫", "🦙", "🦒", "🐘", "🦏", "🦛", "🦘", "🦡", "🐭", "🐁", "🐀", "🐹", "🐰", "🐇", "🐿", "🦔", "🦇", "🐻", "🐨", "🐼", "🦥", "🦦", "🦨", "🦣", "🦘", "🦡", "🦃", "🐔", "🐓", "🐣", "🐤", "🐥", "🐦", "🐧", "🕊", "🦅", "🦆", "🦢", "🦉", "🦤", "🪶", "🦩", "🦚", "🦜", "🐸", "🐊", "🐢", "🦎", "🐍", "🐲", "🐉", "🦕", "🦖", "🐳", "🐋", "🐬", "🐟", "🐠", "🐡", "🦈", "🐙", "🐚", "🐌", "🦋", "🐛", "🐜", "🐝", "🐞", "🦗", "🕷", "🕸", "🦂", "🦟", "🦠", "🐢", "🐍", "🦎", "🐙", "🦑", "🦐", "🦞", "Use ⊞ Win + W to get more emoji!"
            };

        string[] recentEmojisUsed = { };

        private void generateEmojisPanel()
        {
            // Clear emojis list
            flp_emojisList.Controls.Clear();

            // If flp_emojisList is visible, populate it with emojis
            if (flp_emojisList.Visible)
            {
                foreach (string emoji in recentEmojisUsed)
                {
                    Button btn = new Button();
                    // Set size 40x40
                    btn.Size = new Size(40, 40);
                    // Set color to white
                    btn.BackColor = Color.White;
                    // Set font size to 20
                    btn.Font = new Font("Segoe UI Emoji", 15);
                    // Remove button border
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
                    btn.Text = emoji;
                    btn.Click += new EventHandler(emoji_Click);
                    flp_emojisList.Controls.Add(btn);
                }

                foreach (string emoji in emojis)
                {
                    // If the emoji is in the recentEmojisUsed array, skip it
                    if (recentEmojisUsed.Contains(emoji))
                    {
                        continue;
                    }
                    Button btn = new Button();
                    // Set size 40x40
                    btn.Size = new Size(40, 40);
                    // Set color to white
                    btn.BackColor = Color.White;
                    // Set font size to 20
                    btn.Font = new Font("Segoe UI Emoji", 15);
                    // Remove button border
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
                    btn.Text = emoji;
                    btn.Click += new EventHandler(emoji_Click);
                    flp_emojisList.Controls.Add(btn);
                }
            }
        }

        // Make flp_emojisList overflow-x-hidden
        private void flp_emojisList_Paint(object sender, PaintEventArgs e)
        {
            flp_emojisList.AutoScroll = true;
            flp_emojisList.WrapContents = true;
        }

        private void emoji_Click(object sender, EventArgs e)
        {
            // Get the emoji from the button's text
            Button btn = (Button)sender;
            string emoji = btn.Text;

            // If the emoji is already in the recentEmojisUsed array, remove it
            if (recentEmojisUsed.Contains(emoji))
            {
                recentEmojisUsed = recentEmojisUsed.Where(val => val != emoji).ToArray();
            }

            // Add the emoji to the beginning of the recentEmojisUsed array
            recentEmojisUsed = new string[] { emoji }.Concat(recentEmojisUsed).ToArray();

            // If the recentEmojisUsed array has more than 10 emojis, remove the last one
            if (recentEmojisUsed.Length > 10)
            {
                recentEmojisUsed = recentEmojisUsed.Take(10).ToArray();
            }

            // Generate emojis panel
            generateEmojisPanel();

            // Append the emoji to the chatbox
            chatTextbox.AppendText(emoji);
        }

        private void btn_emojis_Click(object sender, EventArgs e)
        {
            // Toggle flp_emojisList visibility
            flp_emojisList.Visible = !flp_emojisList.Visible;

            // Generate emojis panel
            generateEmojisPanel();
        }
    }
}
