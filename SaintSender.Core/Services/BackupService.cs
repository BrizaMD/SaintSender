using SaintSender.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SaintSender.Core.Services
{
    public class BackupService
    {
        public bool SaveData(User user, List<Mail> mails)
        {
            try
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create($"{user.EmailAdress}.xml", xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Users");
                    xmlWriter.WriteStartElement("User");
                    xmlWriter.WriteElementString("Email", user.EmailAdress);
                    xmlWriter.WriteElementString("Password", user.Password);
                    xmlWriter.WriteStartElement("Mails");
                    foreach (Mail mail in mails)
                    {
                        xmlWriter.WriteStartElement("Mail");
                        xmlWriter.WriteElementString("Subject", mail.Subject);
                        xmlWriter.WriteElementString("From", mail.From);
                        xmlWriter.WriteElementString("Body", mail.Body);
                        xmlWriter.WriteElementString("Read", mail.IsMailRead.ToString());
                        xmlWriter.WriteElementString("Date", mail.Date.ToString());
                        xmlWriter.WriteEndElement();
                    }
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                    return true;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Mail> ReadMailsFromFile(User user)
        {
            throw new NotImplementedException();
        }

        public bool CheckForCorrectPassword(string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfUserSaved(string emailAdress)
        {
            throw new NotImplementedException();
        }
    }
}
