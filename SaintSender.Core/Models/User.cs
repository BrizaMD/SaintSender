using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Models
{
    public class User
    {

        public User(string emailAdress, string password)
        {
            EmailAdress = emailAdress;
            Password = password;
        }

        public string EmailAdress { get; set; }
        public string Password { get; set; }

    }
}
