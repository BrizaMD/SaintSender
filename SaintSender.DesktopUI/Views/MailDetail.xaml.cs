using SaintSender.Core.Models;
using SaintSender.Core.Services;
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

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for MailDetail.xaml
    /// </summary>
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
