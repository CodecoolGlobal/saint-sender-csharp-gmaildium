﻿using SaintSender.Core.Entities;
using SaintSender.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for ReadMailWindow.xaml
    /// </summary>
    public partial class ReadMailWindow : Window
    {
        public ReadWindowViewModel viewModel;

        public ReadMailWindow(Maildium maildium)
        { 
            viewModel = new ReadWindowViewModel();
            viewModel.Maildium = maildium;
            InitializeComponent();
            FillFields();
        }

        private void FillFields()
        {
            viewModel.GetFields(FromTextBlock, SubjectTextBlock, DateTextBlock, MessageTextBox);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
