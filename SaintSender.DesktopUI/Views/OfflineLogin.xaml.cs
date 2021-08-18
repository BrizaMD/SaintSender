using SaintSender.Core.Models;
using SaintSender.Core.Services;
using SaintSender.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for OfflineLogin.xaml
    /// </summary>
    public partial class OfflineLogin : Window
    {
        public User User { get; set; }
        public bool isUserValid { get; set; }
        public List<Mail> userMails { get; set; }

        public OfflineLogin()
        {
            InitializeComponent();
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            if (this.IsValidInputs())
            {
                this.PasswordBox.SelectAll();
                this.PasswordBox.Focus();
                this.EmailBox.SelectAll();
                this.EmailBox.Focus();
                this.DialogResult = true;
                Backup backup = new Backup();
                User = new User(EmailBox.Text, PasswordBox.Password);
                userMails = backup.TryReadUserMails(User);
                isUserValid = userMails == null ? false : true;
            }
        }

        private bool IsValidInputs()
        {
            return true;
        }
    }
}
