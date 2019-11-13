﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SaintSender.Core.Entities;
using SaintSender.Core.Services;
using SaintSender.DesktopUI.ViewModels;

namespace SaintSender.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected MainWindowViewModel ViewModel => (MainWindowViewModel)Resources["MainWindowViewModel"];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnectionButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.FillListBoxWithMails();
            ConnectionButton.IsEnabled = false;
        }
        private void ComposeButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ClickCount == 2)
            //{
            Maildium maildium = new Maildium();
            maildium = MainWindowViewModel.UserMails.First();
            ReadMailWindow readMailWindow = new ReadMailWindow(maildium);
            readMailWindow.Show();
            //}
        }
    }
}
