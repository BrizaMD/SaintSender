using SaintSender.Core.Services;
using System.Collections.Generic;

namespace SaintSender.Core.Interfaces
{
    interface IInbox
    {
        List<Mail> CreateMails(List<MimeKit.MimeMessage> inbox);
    }
}
