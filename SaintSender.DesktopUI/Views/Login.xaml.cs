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

    /// <summary>
    /// Interaction logic for Login.xaml.
    /// </summary>
    ///cc.dreamteamdeluxe@gmail.com
    //unclebob
    public partial class Login : Window
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            if (isValidInputs())
            {
                this.PasswordBox.SelectAll();
                this.PasswordBox.Focus();
                this.EmailBox.SelectAll();
                this.EmailBox.Focus();
                this.DialogResult = true;
            }
        }

        public void Connect() { }

        private bool isValidInputs()
        {
            return true;
        }

        public string Email
        {
            get { return EmailBox.Text; }
        }
    }
}