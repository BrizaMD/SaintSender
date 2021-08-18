using SaintSender.Core.Models;
using SaintSender.Core.Services;
using System.Collections.Generic;

namespace SaintSender.Core.Interfaces
{
    interface IBackUp
    {
        bool SaveData(User user, List<Mail> mails);

        List<Mail> ReadMailsFromFile(User user);

        bool CheckForCorrectPassword(string emailAdress, string password);

        bool CheckIfUserSaved(string emailAdress);
    }
}
