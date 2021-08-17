using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SaintSender.Core.Services;

namespace SaintSender.DesktopUI.ViewModels
{
    class ScrollInInbox
    {
        private int pageNumber;
        private int pageSize;
        private List<Mail> mails;

        public ScrollInInbox(int pageNumber, int pageSize, List<Mail> mails)
        {
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
            this.mails = mails;
        }

        public void ScrollInbox(ListView inbox)
        {
            inbox.ItemsSource = this.mails.Skip((this.pageNumber - 1) * this.pageSize)
                                                .Take(this.pageSize);
        }

    }
}
