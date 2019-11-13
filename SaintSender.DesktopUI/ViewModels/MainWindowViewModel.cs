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

        public ObservableCollection<Maildium> UserMails { get; private set; } = new ObservableCollection<Maildium>();

        public MainWindowViewModel()
        {
            JSONHandler.UpdateService();
        }

        internal void FillListBoxWithMails()
        {
            _mailProvider.FillListWithMailsFromAPI(UserMails, 20);
        }
    }
}
