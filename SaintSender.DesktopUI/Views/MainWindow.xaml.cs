namespace SaintSender.DesktopUI
{
    using System.Windows;
    using SaintSender.DesktopUI.ViewModels;
    using SaintSender.DesktopUI.Views;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;
        private bool isLoggedIn;

        public MainWindow()
        {
            // set DataContext to the ViewModel object
            this._vm = new MainWindowViewModel();
            this.DataContext = this._vm;
            this.InitializeComponent();
            this.isLoggedIn = false;
        }



        private void Login(object sender, RoutedEventArgs e)
        {
            if (this.isLoggedIn)
            {
                this.LoginState.Content = "Login";
                this.isLoggedIn = false;
                MessageBox.Show("You have logged out!");
            }
            else
            {
                Login loginWindow = new Login();
                loginWindow.ShowDialog();
                this.LoginState.Content = "Logout";
                this.isLoggedIn = true;
            }

            // validate login format and authenticate
        }
    }
}
