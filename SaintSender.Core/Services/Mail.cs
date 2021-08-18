using System;

namespace SaintSender.Core.Services
{
    [Serializable]
    public class Mail
    {
        public string Subject { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public bool IsMailRead { get; set; }
        public DateTime Date { get; set; }

        public Mail(string subject, string from, string body)
        {
            this.Subject = subject;
            this.From = from;
            this.Body = body;
        }

        public Mail()
        {

        }
    }
}