﻿using System;
using System.Collections.Generic;
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
using SaintSender.Core.Services;
using SaintSender.DesktopUI.Views;
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
            new ComposeWindow().Show();
        }
    }
}
