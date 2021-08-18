using SaintSender.Core.Models;
using SaintSender.Core.Services;
using System.Windows;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for SendMail.xaml
    /// </summary>
    public partial class SendMail : Window
    {
        private User user;

        public SendMail(User user)
        {
            this.InitializeComponent();
            this.user = user;
        }

        public void SendButton(object sender, RoutedEventArgs e)
        {
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