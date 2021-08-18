using SaintSender.Core.Models;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SaintSender.DesktopUI.ViewModels
{
    class Backup
    {
        public bool InitiateBackup(User user, List<Mail> mails)
        {
            BackupService backupService = new BackupService();
            return backupService.SaveData(user, mails);
        }

        public List<Mail> TryReadUserMails(User user)
        {
            BackupService backupService = new BackupService();
            bool userHasSavedBefore = backupService.CheckIfUserSaved(user.EmailAdress);
            bool userEnteredCorrectPassword = backupService.CheckForCorrectPassword(user.Password);
            if (userHasSavedBefore && userEnteredCorrectPassword)
            {
                return backupService.ReadMailsFromFile(user);
            }
            return null;
        }
    }
}
