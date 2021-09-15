using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using SaintSender.Core.Models;

namespace SaintSender.DesktopUI.ViewModels
{
    class StayLoggedInCheckBox
    {
        public void StayLoggedIn(CheckBox loggedInCheckBox, User user)
        {
            MessageBox.Show("You will stay logged in!");
            loggedInCheckBox.Foreground = Brushes.Red;
            SaveLoggedInUser(user);
        }

        private void SaveLoggedInUser(User user)
        {
            var xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.NewLineOnAttributes = true;
            using (var xmlWriter = XmlWriter.Create("loggedInUser.xml", xmlWriterSettings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Users");
                xmlWriter.WriteStartElement("User");
                xmlWriter.WriteElementString("Email", user.EmailAdress);
                xmlWriter.WriteElementString("Password", user.Password);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Flush();
                xmlWriter.Close();
            }
        }

        public void LoggedOff(CheckBox loggedInCheckBox, User user)
        {
            loggedInCheckBox.Foreground = Brushes.Green;
            loggedInCheckBox.IsChecked = false;
        }

        public bool IsUserSaved()
        {
            return File.Exists("loggedInUser.xml");
        }

        public User ReadUserDataFromFile()
        {
            var doc = new XmlDocument();
            doc.Load("loggedInUser.xml");
            var email = doc.DocumentElement.FirstChild.SelectSingleNode("Email").InnerText;
            var password = doc.DocumentElement.FirstChild.SelectSingleNode("Password").InnerText;
            return new User(email, password);
        }

        public void RemoveUserData()
        {
            File.Delete("loggedInUser.xml");
        }
    }
}