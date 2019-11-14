using Google.Apis.Gmail.v1.Data;
using MimeKit;
using SaintSender.Core.Entities;
using SaintSender.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.DesktopUI.ViewModels
{
    public class ComposeWindowViewModel
    {
        MailComposer _mailComposer = new MailComposer();

        internal void SendMessage(string subject, string messageBody, string to)
        {
            Message message = CreateMessage(subject, messageBody, to);
            _mailComposer.SendMessage("me", message);
        }

        private Message CreateMessage(string subject, string messageBody, string to)
        {
            MailMessage mail = new MailMessage();
            mail.Subject = subject;
            mail.Body = messageBody;
            mail.To.Add(new MailAddress(to));
            MimeMessage mimeMessage = MimeMessage.CreateFromMailMessage(mail);

            Message message = new Message();
            message.Raw = Base64UrlEncode(mimeMessage.ToString());

            return message;
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
    }
}
