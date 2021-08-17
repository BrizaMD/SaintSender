using SaintSender.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SaintSender.DesktopUI.ViewModels
{
    class Backup
    {
        private void SaveData(User user)
        {
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
    }
}
