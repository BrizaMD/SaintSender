namespace SaintSender.Core.Services
{
    using MailKit;
    using MailKit.Net.Imap;
    using MailKit.Search;
    using MailKit.Security;
    using SaintSender.Core.Interfaces;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;

    public class Validation : Login
    {
        private const string EmailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        private const string PasswordRequirements = @"^[A - Za - z0 - 9_ -] * $";
        private const int MinimumLengthOfPassword = 12;

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

                    inbox.Open(FolderAccess.ReadOnly);
                    foreach (var mail in inbox)
                    {
                        System.Console.WriteLine(mail.MessageId);
                    }

                    client.Disconnect(true);
                }
                catch (AuthenticationException e)
                {
                    MessageBox.Show("WRONG!!!!!!!");
                }
            }
        }

        public bool ValidateEmail(string email)
        {
            return !Regex.IsMatch(email, EmailPattern) || string.IsNullOrEmpty(email);
        }

        public bool ValidatePassword(string password)
        {
            return password.Length >= MinimumLengthOfPassword || !Regex.IsMatch(password, PasswordRequirements);
        }
    }
}
