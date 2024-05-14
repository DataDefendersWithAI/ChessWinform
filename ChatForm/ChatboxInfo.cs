namespace winforms_chat.ChatForm
{
    public class ChatboxInfo
    {
        public string User { get; set; }
        public string NamePlaceholder { get; set; }
        public string PhonePlaceholder { get; set; }
        public string StatusPlaceholder { get; set; }
        // Replace old placeholder: "Please enter a message..."
        public string ChatPlaceholder = "";
        public byte[] Attachment { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentType { get; set; }
    }
}
