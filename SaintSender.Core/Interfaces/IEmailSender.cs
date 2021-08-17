using SaintSender.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Interfaces
{
    interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
