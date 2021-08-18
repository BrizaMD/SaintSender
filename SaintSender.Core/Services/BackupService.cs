namespace SaintSender.Core.Services
{
    using SaintSender.Core.Interfaces;
    using SaintSender.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    public class BackupService : IBackUp
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
            var userMails = XDocument
                                .Load($"{user.EmailAdress}.xml")
                                .Root
                                .Element("User")
                                .Element("Mails")
                                .Elements("Mail")
                                .Select(p => new Mail
                                {
                                    Subject = (string)p.Element("Subject"),
                                    From = (string)p.Element("From"),
                                    Date = (DateTime)p.Element("Date"),
                                    IsMailRead = (bool)p.Element("Read"),
                                    Body = (string)p.Element("Body"),
                                })
                                .ToList();

            return userMails;
        }

        public bool CheckForCorrectPassword(string emailAdress, string password)
        {
            var readPassword = XDocument
                .Load($"{emailAdress}.xml")
                .Root
                .Element("User")
                .Element("Password")
                .Value;
            return readPassword.Equals(password);
        }

        public bool CheckIfUserSaved(string emailAdress)
        {
            return File.Exists($"{emailAdress}.xml");
        }
    }
}