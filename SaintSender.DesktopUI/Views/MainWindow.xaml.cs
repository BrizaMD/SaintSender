namespace SaintSender.DesktopUI
{
    using SaintSender.Core.Models;
    using SaintSender.Core.Services;
    using SaintSender.DesktopUI.ViewModels;
    using SaintSender.DesktopUI.Views;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Validation = Core.Services.Validation;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Timer refreshInboxTimer;
        private MainWindowViewModel mainWindowViewModel;
        private bool isLoggedIn;
        private bool isNetworkAvailable;
        private List<Mail> mails;
        private int pageNumber = 0;
        private int pageSize = 5;
        private User user;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.mainWindowViewModel = new MainWindowViewModel();
            this.DataContext = this.mainWindowViewModel;
            this.InitializeComponent();
            this.isLoggedIn = false;
            this.isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
            this.StartApp();
        }

        private void StartApp()
        {
            if (!this.isNetworkAvailable)
            {
                MessageBox.Show("No internet connection");
            }
            else
            {
                InitializeOnlineLogin();
            }
        }

        private void InitializeOnlineLogin()
        {
            StayLoggedInCheckBox stayLoggedInCheckBox = new StayLoggedInCheckBox();
            if (stayLoggedInCheckBox.IsUserSaved())
            {
                this.user = stayLoggedInCheckBox.ReadUserDataFromFile();
                AutomaticLogin();
            }
        }

        private void DecideAccountAction(object sender, RoutedEventArgs e)
        {
            if (this.isLoggedIn)
            {
                LogOut();
            }
            else if (!isNetworkAvailable)
            {
                LoginOffline();
            }
            else
            {
                Login();
            }
        }

        private void SendMailClick(object sender, RoutedEventArgs e)
        {
            SendMail sendMail = new SendMail(user);
            sendMail.ShowDialog();
        }

        private void Login()
        {
            Login loginWindow = new Login();
            loginWindow.ShowDialog();
            this.user = loginWindow.User;

            if (loginWindow.FullInbox is null)
            {
                MessageBox.Show("Wrong e-mail or password!");
                return;
            }

            this.LoginSetup();
            this.DisplayMails(loginWindow);
            this.StartAutoRefresh();
        }

        private void LoginOffline()
        {
            OfflineLogin loginWindow = new OfflineLogin();
            loginWindow.ShowDialog();
            this.user = loginWindow.User;

            if (!loginWindow.isUserValid)
            {
                MessageBox.Show("No internet and there is no backup.");
                return;
            }

            this.LoginSetup();
            this.DisplayMails(loginWindow);
        }

        private void AutomaticLogin()
        {
            this.mails = new InboxService()
                .CreateMails(new Validation()
                .Connect(this.user.EmailAdress, this.user.Password));
            this.LoginSetup();
            this.SetupUi();
        }

        private void SetupUi()
        {
            LoggedInCheckBox.Foreground = Brushes.Green;
            LoggedInCheckBox.IsChecked = true;
            this.ScrollInbox();
            Inbox.Visibility = Visibility.Visible;
            UserControls.Visibility = Visibility.Visible;
        }

        private void LoginSetup()
        {
            this.LoginState.Content = "Logout";
            this.isLoggedIn = true;
            this.pageNumber = 0;
            this.pageSize = 5;
        }

        private void StartAutoRefresh()
        {
            refreshInboxTimer = new Timer(60000);
            refreshInboxTimer.Elapsed += new ElapsedEventHandler(RefreshInbox);
            refreshInboxTimer.Enabled = true;
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
            this.mails = new InboxService().CreateMails(loginWindow.FullInbox);
            this.SetupDisplayMailUi();
        }

        private void DisplayMails(OfflineLogin loginWindow)
        {
            this.mails = loginWindow.userMails;
            this.SetupDisplayMailUi();
        }

        private void SetupDisplayMailUi()
        {
            this.ScrollInbox();
            Inbox.Visibility = Visibility.Visible;
            UserControls.Visibility = Visibility.Visible;
        }

        private void PreviousButtonClick(object sender, RoutedEventArgs e)
        {
            this.ScrollInbox();
            this.pageNumber--;
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            this.ScrollInbox();
            this.pageNumber++;
        }

        private void ScrollInbox()
        {
            this.Inbox.ItemsSource = this.mails
                                         .Skip((this.pageNumber - 1) * this.pageSize)
                                         .Take(this.pageSize);
        }

        private void RefreshButtonClick(object sender, RoutedEventArgs e)
        {
            RefreshInbox();
        }

        private void RefreshInbox(object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                RefreshInbox();
            });
        }

        private void RefreshInbox()
        {
            Inbox.IsEnabled = false;
            pageNumber = 0;
            pageSize = 5;
            Validation tryLogin = new Validation();
            this.mails = new InboxService()
                   .CreateMails(new Validation().Connect(this.user.EmailAdress, this.user.Password));
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

        private void ForgetMeButton(object sender, RoutedEventArgs e)
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

        private void BackUpButton(object sender, RoutedEventArgs e)
        {
            bool isBackupSuccessful = new Backup().InitiateBackup(user, mails);
            if (isBackupSuccessful)
            {
                MessageBox.Show("Your mails were backed up successfully.");
            }
            else
            {
                MessageBox.Show("Something went wrong. Backup unsuccessful.");
            }
        }
    }
}