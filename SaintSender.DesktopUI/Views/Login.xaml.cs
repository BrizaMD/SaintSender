namespace SaintSender.DesktopUI.Views
{
    using MailKit;
    using MailKit.Net.Imap;
    using MailKit.Security;
    using System.Linq;
    using System.Windows;
    using SaintSender.Core.Services;

    /// <summary>
    /// Interaction logic for Login.xaml.
    /// </summary>

    // e-mail : cc.dreamteamdeluxe@gmail.com

    // password : unclebob
    public partial class Login : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        public Login()
        {
            this.InitializeComponent();
        }

        public string Email => this.EmailBox.Text;

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
            }
        }

        public void Connect(string user, string password)
        {
            Validation tryLogin = new Validation();
            tryLogin.Connect(user, password);
        }

        private bool IsValidInputs()
        {
            return true;
        }
    }
}