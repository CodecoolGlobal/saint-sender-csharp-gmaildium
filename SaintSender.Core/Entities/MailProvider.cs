using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1.Data;
using SaintSender.Core.Services;

namespace SaintSender.Core.Entities
{
    public class MailProvider
    {

        public void FillListWithMailsFromAPI(ICollection<Maildium> userMails, int mailCount)
        {
            ListMessagesResponse response = JSONHandler.RequestMails(mailCount);
            List<Message> messages = new List<Message>();

            messages.AddRange(response.Messages);
            foreach (Message message in messages)
            {
                userMails.Add(GetMailById(message.Id));
            }
        }

        public Maildium GetMailById(string messageId)
        {
            Message message = JSONHandler.RequestMailById(messageId);
            String rawMessage = JSONHandler.RequestRawMailBodyById(messageId);
            MessagePart payload = message.Payload;

            if (rawMessage == null)
            {
                rawMessage = payload.Body.Data;
            }
            rawMessage.Replace("/ -/ g", "+").Replace("/ _ / g", "/");


            Maildium maildium = new Maildium()
            {
                Id = message.Id,
                From = GetHeaderValueByHeaderName(payload.Headers, "From"),
                To = GetHeaderValueByHeaderName(payload.Headers, "To"),
                Subject = GetHeaderValueByHeaderName(payload.Headers, "Subject"),
                RecieveDate = GetHeaderValueByHeaderName(payload.Headers, "Date"),
                IsRead = !message.LabelIds.Contains("UNREAD"),
                MessageBody = rawMessage
            };
            return maildium;
        }

        private string GetHeaderValueByHeaderName(IList<MessagePartHeader> headers, string headerName)
        {
            return (from header
                   in headers
                    where header.Name.Equals(headerName)
                    select header.Value).First();
        }

    }
}
