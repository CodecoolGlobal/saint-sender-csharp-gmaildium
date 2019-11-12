using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1.Data;
using SaintSender.Core.Services;

namespace SaintSender.Core.Entities
{
    public class MailProvider
    {

        public List<Maildium> GetMailsFromAPI(int mailCount)
        {
            ListMessagesResponse response = JSONHandler.RequestMails(mailCount);
            List<Message> messages = new List<Message>();
            List<Maildium> maildia = new List<Maildium>();

            messages.AddRange(response.Messages);
            foreach (Message message in messages)
            {
                maildia.Add(GetMailById(message.Id));
            }
            return maildia;
        }

        public Maildium GetMailById(string messageId)
        {
            Message message = JSONHandler.RequestMailById(messageId);
            MessagePart payload = message.Payload;
            Maildium maildium = new Maildium()
            {
                Id = message.Id,
                From = GetHeaderValueByHeaderName(payload.Headers, "From"),
                To = GetHeaderValueByHeaderName(payload.Headers, "To"),
                Subject = GetHeaderValueByHeaderName(payload.Headers, "Subject"),
                RecieveDate = GetHeaderValueByHeaderName(payload.Headers, "Date"),
                IsRead = !message.LabelIds.Contains("UNREAD"),
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
