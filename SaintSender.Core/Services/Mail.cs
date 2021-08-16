using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{

    public class Mail
    {
        private string subject;
        private string from;
        public string Subject { get => subject; set => subject = value; }
        public string From { get => from; set => from = value; }

        public Mail(string subject, string from)
        {
            this.Subject = subject;
            this.From = from;
        }

        public Mail()
        {
        }
        public override string ToString()
        {
            return this.subject + " " + this.from;
        }
    }
}
