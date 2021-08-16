namespace SaintSender.DesktopUI.Views
{
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
    using MailKit.Net.Imap;
    using System.Net.Mail;

    /// <summary>
    /// Interaction logic for Login.xaml.
    /// </summary>

    //e-mail : cc.dreamteamdeluxe@gmail.com
    //password : unclebob

    public partial class Login : Window
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            if (IsValidInputs())
            {
                this.PasswordBox.SelectAll();
                this.PasswordBox.Focus();
                this.EmailBox.SelectAll();
                this.EmailBox.Focus();
                this.DialogResult = true;


            }
        }

        public void Connect(string user, string password)
        {
            //using (var client = new ImapClient(new ProtocolLogger("imap.log")))
            //{
            //    try
            //    {
            //        client.Connect(server, this.port, true);
            //        client.AuthenticationMechanisms.Remove("XOAUTH2");
            //        client.AuthenticationMechanisms.Remove("NTLM");
            //        client.Authenticate(user, password);
            //        var inbox = client.Inbox;
            //        inbox.Open(FolderAccess.ReadWrite);

            //        if (inbox.Count > 0)
            //        {
            //            var range = Enumerable.Range(0, inbox.Count).ToArray();
            //            inbox.AddFlags(range, MessageFlags.Deleted, false);
            //            inbox.Expunge();
            //        }
            //        client.Disconnect(true);
            //    }
            //    catch (AuthenticationException e)
            //    {
            //        throw e;
            //    }
            //}
        }
        private bool IsValidInputs()
        {
            return true;
        }

        public string Email
        {
            get { return EmailBox.Text; }
        }
    }
}