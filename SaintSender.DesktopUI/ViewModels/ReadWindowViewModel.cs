using SaintSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.DesktopUI.ViewModels
{
    public class ReadWindowViewModel
    {
        public ReadWindowViewModel(Maildium maildium)
        {
            Maildium = maildium;
        }
        public Maildium Maildium { get; set; } 

        public string From { get; set; } = "Kis Józsi";


    }

}
