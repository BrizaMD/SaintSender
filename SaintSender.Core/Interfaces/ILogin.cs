namespace SaintSender.Core.Interfaces
{
    using System.Collections.Generic;

    interface ILogin
    {

        bool ValidateEmail(string email);

        bool ValidatePassword(string password);

        List<MimeKit.MimeMessage> Connect(string user, string password);

    }
}
