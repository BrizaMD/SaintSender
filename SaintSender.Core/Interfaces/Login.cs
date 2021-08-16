namespace SaintSender.Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface Login
    {

        bool ValidateEmail(string email);
        bool ValidatePassword(string password);
    }
}
