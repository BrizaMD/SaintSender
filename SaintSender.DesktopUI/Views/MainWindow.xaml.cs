namespace SaintSender.DesktopUI
{
    using SaintSender.Core.Models;
    using SaintSender.Core.Services;
    using SaintSender.DesktopUI.ViewModels;
    using SaintSender.DesktopUI.Views;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Windows;
    using System.Windows.Media;
    using System;
    using SaintSender.Core.Models;
    using System.Windows.Controls;
    using System.Threading;
    using System.ComponentModel;
    using Validation = Core.Services.Validation;

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
        private User user;
        private ScrollInInbox scroll;
        private BackgroundWorker worker;

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
                StayLoggedInCheckBox stayLoggedInCheckBox = new StayLoggedInCheckBox();
                if (stayLoggedInCheckBox.IsUserSaved())
                {
                    this.user = stayLoggedInCheckBox.ReadUserDataFromFile();
                    AutomaticLogin();
                }

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
            SendMail sendMail = new SendMail(user);
            sendMail.ShowDialog();
        }

        private void Login()
        {
            Login loginWindow = new Login();
            loginWindow.ShowDialog();
            user = loginWindow.User;
            this.LoginState.Content = "Logout";
            this.isLoggedIn = true;
            pageNumber = 0;
            pageSize = 5;
            DisplayMails(loginWindow);
        }

        private void AutomaticLogin()
        {
            Validation tryLogin = new Validation();
            mails = new InboxService()
                    .CreateMails(tryLogin.Connect(this.user.EmailAdress, this.user.Password));
            pageNumber = 0;
            pageSize = 5;
            this.isLoggedIn = true;
            this.LoginState.Content = "Logout";
            LoggedInCheckBox.Foreground = Brushes.Green;
            LoggedInCheckBox.IsChecked = true;
            ScrollInbox();
            Inbox.Visibility = Visibility.Visible;
            UserControls.Visibility = Visibility.Visible;
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
            Inbox.IsEnabled = false;
            pageNumber = 0;
            pageSize = 5;
            Validation tryLogin = new Validation();
            mails = new InboxService()
                    .CreateMails(tryLogin.Connect(this.user.EmailAdress, this.user.Password));
            ScrollInbox();
            Inbox.IsEnabled = true;

        }

        private void StayLoggedInButton(object sender, RoutedEventArgs e)
        {
            StayLoggedInCheckBox checkBox = new StayLoggedInCheckBox();

            if (LoggedInCheckBox.IsChecked is true)
            {
                checkBox.StayLoggedIn(this.LoggedInCheckBox, user);
            }
            else
            {
                checkBox.LoggedOff(this.LoggedInCheckBox, user);
            }
        }

        private void ForgetMe_Click(object sender, RoutedEventArgs e)
        {
            StayLoggedInCheckBox checkBox = new StayLoggedInCheckBox();
            checkBox.LoggedOff(LoggedInCheckBox, user);
            checkBox.RemoveUserData();
        }

        private void ListViewDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var mail = (Mail)(sender as ListView).SelectedItem;
            if (mail != null)
            {
                MailDetail detailWindow = new MailDetail(mail, user);
                detailWindow.ShowDialog();
            }
        }
    }
}