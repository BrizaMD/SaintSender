using SaintSender.Core.Models;
using SaintSender.Core.Services;
using SaintSender.DesktopUI.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            this.PasswordBox.SelectAll();
            this.PasswordBox.Focus();
            this.EmailBox.SelectAll();
            this.EmailBox.Focus();
            this.DialogResult = true;
            User = new User(EmailBox.Text, PasswordBox.Password);
            userMails = new Backup().TryReadUserMails(User);
            isUserValid = userMails == null ? false : true;
        }
    }
}
