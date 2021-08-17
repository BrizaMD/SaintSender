namespace SaintSender.DesktopUI
{
    using System.Net.NetworkInformation;
    using System.Windows;
    using SaintSender.DesktopUI.ViewModels;
    using SaintSender.DesktopUI.Views;
    using SaintSender.Core.Services;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel;
        private bool isLoggedIn;
        private bool isNetworkAvailable;
        private List<Mail> mails;
        private int pageNumber = 0;
        private int pageSize = 5;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            // set DataContext to the ViewModel object
            this.mainWindowViewModel = new MainWindowViewModel();
            this.DataContext = this.mainWindowViewModel;
            this.InitializeComponent();
            this.isLoggedIn = false;
            this.isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();

            if (!this.isNetworkAvailable)
            {
                MessageBox.Show("No internet connection");

                // load mails from file if authenticated user has saved before
            }
            else
            {
                MessageBox.Show("Yeyy we have internet!");
            }
        }

        private void UserAccountActions(object sender, RoutedEventArgs e)
        {
            if (this.isLoggedIn)
            {
                LogOut();
            }
            else
            {
                Login();
            }
        }


        private void SendMail_Click(object sender, RoutedEventArgs e)
        {
            SendMail sendMail = new SendMail();
            sendMail.ShowDialog();

        private void Login()
        {
            Login loginWindow = new Login();
            loginWindow.ShowDialog();
            this.LoginState.Content = "Logout";
            this.isLoggedIn = true;
            DisplayMails(loginWindow);
        }

        private void LogOut()
        {
            this.LoginState.Content = "Login";
            this.isLoggedIn = false;
            Inbox.Visibility = Visibility.Hidden;
            UserControls.Visibility = Visibility.Hidden;
            MessageBox.Show("You have logged out!");
        }

        private void DisplayMails(Login loginWindow)
        {
            mails = new InboxService().CreateMails(loginWindow.FullInbox);
            ScrollInbox();
            Inbox.Visibility = Visibility.Visible;
            UserControls.Visibility = Visibility.Visible;
        }

        private void PreviousButtonClick(object sender, RoutedEventArgs e)
        {
            ScrollInbox();
            this.pageNumber -= 1;
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            ScrollInbox();
            this.pageNumber++;
        }

        private void ScrollInbox()
        {
            this.Inbox.ItemsSource = this.mails.Skip((this.pageNumber - 1) * this.pageSize)
                                    .Take(this.pageSize);
        }

        private void RefreshButtonClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}