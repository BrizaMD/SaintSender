using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{

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
        public override string ToString()
        {
            return this.Subject + " " + this.From;
        }
    }
}
