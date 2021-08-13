using SaintSender.DesktopUI.ViewModels;
using SaintSender.DesktopUI.Views;
using System.Windows;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;
        private bool isLoggedIn;

        public MainWindow()
        {
            // set DataContext to the ViewModel object
            _vm = new MainWindowViewModel();
            DataContext = _vm;
            InitializeComponent();
            isLoggedIn = false;
        }

        private void GreetBtn_Click(object sender, RoutedEventArgs e)
        {
            // dispatch user interaction to view model
            _vm.Greet();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (isLoggedIn)
            {
                LoginState.Content = "Login";
                isLoggedIn = false;
                MessageBox.Show("You have logged out!");
            }
            else
            {
                Login loginWindow = new Login();
                loginWindow.ShowDialog();
                LoginState.Content = "Logout";
                isLoggedIn = true;
            }
            
            // validate login format and authenticate
            
        }
    }
}
