namespace SaintSender.DesktopUI.Views
{
    using SaintSender.Core.Services;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MailList.xaml
    /// </summary>
    public partial class MailList : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailList"/> class.
        /// </summary>


        private List<MimeKit.MimeMessage> inbox;
        private List<Mail> mails = new List<Mail>();
        public MailList(List<MimeKit.MimeMessage> fullInbox)
        {
            this.InitializeComponent();
            this.inbox = fullInbox;
            CreateMail();
            //InboxUI.ItemsSource = mails;
        }

        public MailList() { }

        private void CreateMail()
        {
            foreach (var item in this.inbox)
            {
                mails.Add(new Mail() { Subject = item.Subject, From = item.From.ToString() });
            }
        }

        //public void LoadInbox(List<MimeKit.MimeMessage> FullInbox)
        //{
        //    this.fullinbox = FullInbox;

        //    var dt = new DataTable();

        //    // create columns and headers
        //    int columnCount = 4;
        //    // copy rows data
        //    for (int i = 0; i < FullInbox.Count; i++)
        //    {
        //        dt.Rows.Add("elem");
        //    }

        //    // display in a DataGrid
        //    dataGrid.ItemsSource = dt.DefaultView;

        //}
    }
}
