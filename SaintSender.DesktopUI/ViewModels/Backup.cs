using SaintSender.Core.Models;
using SaintSender.Core.Services;
using System.Collections.Generic;

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
            bool userEnteredCorrectPassword = backupService.CheckForCorrectPassword(user.EmailAdress, user.Password);
            if (userHasSavedBefore && userEnteredCorrectPassword)
            {
                return backupService.ReadMailsFromFile(user);
            }
            return null;
        }
    }
}
