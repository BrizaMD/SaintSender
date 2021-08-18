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
    }
}
