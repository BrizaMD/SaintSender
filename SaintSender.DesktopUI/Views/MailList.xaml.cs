namespace SaintSender.DesktopUI.Views
{
    using System.Collections.Generic;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MailList.xaml
    /// </summary>
    public partial class MailList : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailList"/> class.
        /// </summary>


        private List<MimeKit.MimeMessage> fullinbox;

        public List<MimeKit.MimeMessage> Fullinbox { get; }
        public MailList()
        {
            this.InitializeComponent();
        }

        public void LoadInbox(List<MimeKit.MimeMessage> FullInbox)
        {
            this.fullinbox = FullInbox;

        }
    }
}
