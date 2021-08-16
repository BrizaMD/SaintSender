namespace SaintSender.DesktopUI.Views
{
    using MailKit;
    using MailKit.Net.Imap;
    using MailKit.Security;
    using System.Linq;
    using System.Windows;

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
            using (var client = new ImapClient(new ProtocolLogger("imap.log")))
            {
                try
                {
                    // client.Connect("smtp.gmail.com", 465, true);
                    // client.Authenticate(user, password);
                    client.Connect("imap.gmail.com", 993, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.AuthenticationMechanisms.Remove("NTLM");
                    client.Authenticate(user, password);
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadWrite);
                    if (inbox.Count > 0)
                    {
                        var range = Enumerable.Range(0, inbox.Count).ToArray();
                        inbox.AddFlags(range, MessageFlags.Deleted, false);
                        inbox.Expunge();
                    }
                    client.Disconnect(true);
                }
                catch (AuthenticationException e)
                {
                    MessageBox.Show("WRONG!!!!!!!");
                }
            }
        }

        private bool IsValidInputs()
        {
            return true;
        }
    }
}