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
        public User User { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        /// 
        private List<MimeKit.MimeMessage> fullInbox;
        public Login()
        {
            this.InitializeComponent();
        }

        public string Email => this.EmailBox.Text;

        public List<MimeMessage> FullInbox { get => this.fullInbox; set => this.fullInbox = value; }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            if (this.IsValidInputs())
            {
                this.PasswordBox.SelectAll();
                this.PasswordBox.Focus();
                this.EmailBox.SelectAll();
                this.EmailBox.Focus();
                this.DialogResult = true;
                this.Connect(EmailBox.Text, PasswordBox.Password);
                User = new User(EmailBox.Text, PasswordBox.Password);
            }
        }

        public void Connect(string user, string password)
        {
            Validation tryLogin = new Validation();
            this.fullInbox = tryLogin.Connect(user, password);
        }

        private bool IsValidInputs()
        {
            return true;
        }
    }
}