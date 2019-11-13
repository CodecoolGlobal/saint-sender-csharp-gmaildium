using SaintSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SaintSender.DesktopUI.ViewModels
{
    public class ReadWindowViewModel : ObjectDataProvider
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }

        public ReadWindowViewModel(Maildium maildium)
        {
            From = maildium.From;
            Subject = maildium.Subject;
            Date = "rzstf";
            Message = maildium.MessageBody;

        }

    }
}
