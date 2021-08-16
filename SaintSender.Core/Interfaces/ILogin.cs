namespace SaintSender.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface ILogin
    {

        bool ValidateEmail(string email);
        bool ValidatePassword(string password);
        List<MimeKit.MimeMessage> Connect(string user, string password);

    }
}
