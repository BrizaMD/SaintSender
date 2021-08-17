﻿using System;
using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace SaintSender.Core.Models
{
    public class Message
    {
        // public List<MailboxAddress> To { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(string to, string subject, string content)
        {
            this.To = to;
            // To.AddRange(to.Select(x => new MailboxAddress(x)));
            this.Subject = subject;
            this.Content = content;
        }
    }
}