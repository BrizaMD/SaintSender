namespace SaintSender.DesktopUI.Views
{
    using MimeKit;
    using SaintSender.Core.Models;
    using SaintSender.Core.Services;
    using System.Collections.Generic;
    using System.Windows;

    /// <summary>
    /// Interaction logic for Login.xaml.
    /// </summary>

    // e-mail : cc.dreamteamdeluxe@gmail.com

    // password : unclebob
    public partial class Login : Window
    {
        public Login()
        {
            this.InitializeComponent();
        }

        public string Email => this.EmailBox.Text;

        public User User { get; set; }

        public List<MimeMessage> FullInbox { get; set; }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            this.PasswordBox.SelectAll();
            this.PasswordBox.Focus();
            this.EmailBox.SelectAll();
            this.EmailBox.Focus();
            this.DialogResult = true;
            Validation tryLogin = new Validation();
            this.FullInbox = tryLogin.Connect(EmailBox.Text, PasswordBox.Password);
            User = new User(EmailBox.Text, PasswordBox.Password);
        }
    }
}