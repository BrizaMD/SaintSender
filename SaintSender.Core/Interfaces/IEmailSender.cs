using SaintSender.Core.Models;

namespace SaintSender.Core.Interfaces
{
    interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
