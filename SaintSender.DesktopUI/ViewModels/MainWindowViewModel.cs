using SaintSender.Core.Entities;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.DesktopUI.ViewModels
{
    class MainWindowViewModel
    {
        private MailProvider _mailProvider = new MailProvider();
        private List<Maildium> _userMails = new List<Maildium>();

        public List<Maildium> UserMails { get => _userMails; private set => _userMails = value; }

        public MainWindowViewModel()
        {
            JSONHandler.UpdateService();
        }

        internal void FillListBoxWithMails()
        {
            _userMails = _mailProvider.GetMailsFromAPI(20);
        }
    }
}
