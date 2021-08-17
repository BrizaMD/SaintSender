namespace SaintSender.DesktopUI.ViewModels
{
    using SaintSender.Core.Models;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    class StayLoggedInCheckBox
    {
        public void StayLoggedIn(CheckBox loggedInCheckBox, User user)
        {
            MessageBox.Show("You will stay logged in!");
            loggedInCheckBox.Foreground = Brushes.Red;

            SaveData(user);
        }

        private void SaveData(User user)
        {
            System.Xml.Serialization.XmlSerializer userSerializer =
                new System.Xml.Serialization.XmlSerializer(user.GetType());
            Stream stream = new FileStream("data.xml",
                                            FileMode.Create,
                                            FileAccess.Write,
                                            FileShare.None);
            userSerializer.Serialize(stream, user);
            stream.Close();
        }

        public void LoggedOff(CheckBox loggedInCheckBox)
        {
            MessageBox.Show("You will not stay logged in!");
            loggedInCheckBox.Foreground = Brushes.Green;
        }
    }
}
