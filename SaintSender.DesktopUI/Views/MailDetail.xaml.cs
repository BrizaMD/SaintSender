namespace SaintSender.DesktopUI.Views
{
    using System.Windows;
    using SaintSender.Core.Models;
    using SaintSender.Core.Services;

    public partial class MailDetail : Window
    {
        private Mail mail;
        private User user;

        public MailDetail(Mail mail, User user)
        {
            InitializeComponent();
            this.mail = mail;
            this.user = user;
            this.Sender.Text = mail.From;
            this.Subject.Text = mail.Subject;
            this.Date.Text = mail.Date.ToString();
            this.Body.Text = mail.Body;
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ReplyButton(object sender, RoutedEventArgs e)
        {
            Reply replyWindow = new Reply(mail, user);
            replyWindow.ShowDialog();
            this.Close();
        }
    }
}
