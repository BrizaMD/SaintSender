namespace SaintSender.DesktopUI.ViewModels
{
    using SaintSender.Core.Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Xml;
    using System.Xml.Linq;

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
            //System.Xml.Serialization.XmlSerializer userSerializer =
            //    new System.Xml.Serialization.XmlSerializer(user.GetType());
            //Stream stream = new FileStream("users.xml",
            //                                FileMode.Create,
            //                                FileAccess.Write,
            //                                FileShare.None);
            //userSerializer.Serialize(stream, user);
            //stream.Close();
            if (File.Exists("users.xml") == false)
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create("users.xml", xmlWriterSettings))
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
            else
            {
                XDocument xDocument = XDocument.Load("users.xml");
                XElement root = xDocument.Element("Users");
                IEnumerable<XElement> rows = root.Descendants("User");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
                   new XElement("User",
                   new XElement("Email", user.EmailAdress),
                   new XElement("Password", user.Password)));
                xDocument.Save("users.xml");
            }


        }

        public void LoggedOff(CheckBox loggedInCheckBox, User user)
        {
            MessageBox.Show("You will not stay logged in!");
            loggedInCheckBox.Foreground = Brushes.Green;
            DeleteUser();
        }

        private void DeleteUser()
        {

        }
    }
}
