using SaintSender.Core.Models;
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
                // this.Connect(EmailBox.Text, PasswordBox.Password); <- check and read file
                // User = new User(EmailBox.Text, PasswordBox.Password); <- load into this IF found
                Backup backup = new Backup();
                backup.TryReadUserMails(new User(EmailBox.Text, PasswordBox.Password));
            }
        }

        private bool IsValidInputs()
        {
            return true;
        }
    }
}
