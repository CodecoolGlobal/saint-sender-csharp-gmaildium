using SaintSender.Core.Entities;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.DesktopUI.ViewModels
{
    public class MainWindowViewModel
    {
        private MailProvider _mailProvider = new MailProvider();
        private ObservableCollection<Maildium> _userMails = new AsyncObservableCollection<Maildium>();

        public ObservableCollection<Maildium> UserMails { get => _userMails; private set => _userMails = value; }

        internal Task FillListBoxWithMails()
        {
            var task = Task.Run(() => _mailProvider.FillListWithMailsFromAPI(UserMails, 20));
            return task;
        }

        internal Task ClearList()
        {
            var task = Task.Run(() => _userMails.Clear());
            return task;
        }

    }
}
