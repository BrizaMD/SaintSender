namespace SaintSender.DesktopUI.ViewModels
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    class StayLoggedInCheckBox
    {
        public void StayLoggedIn(CheckBox loggedInCheckBox)
        {
            MessageBox.Show("You will stay logged in!");
            loggedInCheckBox.Foreground = Brushes.Red;
        }


        public void LoggedOff(CheckBox loggedInCheckBox)
        {
            MessageBox.Show("You will not stay logged in!");
            loggedInCheckBox.Foreground = Brushes.Green;
        }
    }
}
