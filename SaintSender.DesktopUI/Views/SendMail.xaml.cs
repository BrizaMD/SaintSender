using SaintSender.Core.Models;
using SaintSender.Core.Services;
using System.Collections.Generic;
using System.Windows;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for SendMail.xaml
    /// </summary>
    public partial class SendMail : Window
    {
        public SendMail()
        {
            this.InitializeComponent();
        }

        public void SendButton(object sender, RoutedEventArgs e)
        {
            // IEnumerable<string> allEmails = new List<string>() { "get emails here" };
            

            var message = new Message(EmailBox.Text, Subject.Text, Mail.Text);

            var emailConfiguration = new EmailConfiguration()
            {
                SMTPFrom = "cc.dreamteamdeluxe@gmail.com",    //get our email
                SMTPHost = "smtp.gmail.com",
                SMTPLogin = "cc.dreamteamdeluxe@gmail.com",
                SMTPPassword = "unclebob",
                SMTPPort = 465,
            };

            var _emailSender = new EmailSender(emailConfiguration);

            _emailSender.SendEmail(message);
            this.Close();

        }
    }
}