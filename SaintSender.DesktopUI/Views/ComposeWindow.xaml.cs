using System;
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
using System.ComponentModel.DataAnnotations;

namespace SaintSender.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for ComposeWindow.xaml
    /// </summary>
    public partial class ComposeWindow : Window
    {
        protected ComposeWindowViewModel ViewModel => (ComposeWindowViewModel)Resources["ComposeWindowViewModel"];
        public ComposeWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure? Your message will be lost!", "Cancel", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Close();
                    break;
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = ShowAppropriateMessageBoxAndGetAnswer();
            if (result == MessageBoxResult.Yes)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            ViewModel.SendMessage(Subject.Text, Message.Text, To.Text);
            MessageBox.Show("Email has been sent!");
            Close();
        }

        private MessageBoxResult ShowAppropriateMessageBoxAndGetAnswer()
        {
            MessageBoxResult result = MessageBoxResult.Yes;
            var address = new EmailAddressAttribute();

            if (!address.IsValid(To.Text))
            {
                MessageBox.Show("Invalid email address!");
                result = MessageBoxResult.No;
            }
            else if (Subject.Text == string.Empty || Message.Text == string.Empty)
            {
                result = MessageBox.Show("Some fields were left empty. Are you sure " +
                    "you want to send the email?", "Confirmation", MessageBoxButton.YesNo);
            }

            return result;
        }
    }
}
