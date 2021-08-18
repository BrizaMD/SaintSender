namespace SaintSender.Core.Models
{
    public class Message
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(string to, string subject, string content)
        {
            this.To = to;
            this.Subject = subject;
            this.Content = content;
        }
    }
}
