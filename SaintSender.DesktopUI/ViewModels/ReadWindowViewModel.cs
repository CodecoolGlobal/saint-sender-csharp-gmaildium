﻿using SaintSender.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SaintSender.DesktopUI.ViewModels
{
    public class ReadWindowViewModel
    {
        public Maildium Maildium { get; set; }

        internal void GetFields(in TextBlock fromTextBlock, in TextBlock subjectTextBlock, in TextBlock dateTextBlock, in TextBox messageTextBox)
        {
            fromTextBlock.Text = Maildium.From;
            subjectTextBlock.Text = Maildium.Subject;
            string date = Maildium.ReceiveDate;
            dateTextBlock.Text = date.Substring(0, 22);
            messageTextBox.Text = Maildium.MessageBody;
        }
    }
}
