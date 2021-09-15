namespace SaintSender.Core.Services
{
    using MailKit;
    using MailKit.Net.Imap;
    using MailKit.Security;
    using SaintSender.Core.Interfaces;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Windows;

    public class Validation : ILogin
    {
        private const string EmailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        private const string PasswordRequirements = @"^[A - Za - z0 - 9_ -] * $";
        private const int MinimumLengthOfPassword = 8;


        public List<MimeKit.MimeMessage> Connect(string user, string password)
        {
            using (var client = new ImapClient(new ProtocolLogger("imap.log")))
            {
                List<MimeKit.MimeMessage> fullInbox = new List<MimeKit.MimeMessage>();
                try
                {
                    client.Connect("imap.gmail.com", 993, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.AuthenticationMechanisms.Remove("NTLM");
                    client.Authenticate(user, password);
                    var inbox = client.Inbox;

                    inbox.Open(FolderAccess.ReadOnly);

                    foreach (var mail in inbox)
                    {
                        fullInbox.Add(mail);
                    }

                    client.Disconnect(true);
                }
                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (AuthenticationException e)
                {
                    MessageBox.Show(e.Message);
                }
                return fullInbox;
            }
        }

        public bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, EmailPattern) || string.IsNullOrEmpty(email);
        }

        public bool ValidatePassword(string password)
        {
            return password.Length >= MinimumLengthOfPassword || Regex.IsMatch(password, PasswordRequirements);
        }
    }
}
