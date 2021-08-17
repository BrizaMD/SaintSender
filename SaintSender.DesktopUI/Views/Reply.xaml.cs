using SaintSender.Core.Models;
using SaintSender.Core.Services;
using System.Text.RegularExpressions;
using System.Windows;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for Reply.xaml
    /// </summary>
    public partial class Reply : Window
    {
        private User user;

        public Reply(Mail mail, User user)
        {
            InitializeComponent();
            this.user = user;
            EmailBox.Text = ExtractEmail(mail.From);
            Mail.Text = $" {mail.Body} ";
        }

        private string ExtractEmail(string text)
        {
            string pattern = @"([a-zA-Z0-9.-]+@[a-zA-Z0-9.-]+.[a-zA-Z0-9_-]+)";
            return Regex.Match(text, pattern).Value;
        }

        public void SendButton(object sender, RoutedEventArgs e)
        {
            // IEnumerable<string> allEmails = new List<string>() { "get emails here" };
            if (EmailBox.Text == "")
            {
                MessageBox.Show("At least one adress should be given!");
                return;
            }

            var message = new Message(EmailBox.Text, Subject.Text, Mail.Text);

            var emailConfiguration = new EmailConfiguration()
            {
                SMTPFrom = user.EmailAdress,
                SMTPHost = "smtp.gmail.com",
                SMTPLogin = user.EmailAdress,
                SMTPPassword = user.Password,
                SMTPPort = 465,
            };

            var _emailSender = new EmailSender(emailConfiguration);

            _emailSender.SendEmail(message);
            this.Close();

        }

        public void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
