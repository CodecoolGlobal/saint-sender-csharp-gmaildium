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
            MessagePart payload = message.Payload;
            string payloadMessage = string.Empty;
            if (payload.Body.Data == null)
            {
                payloadMessage = GetMessageFromEmailBody(payload.Parts[0]);
            }
            else
            {
                payloadMessage = GetMessageFromEmailBody(payload);
            }
            
            

            Maildium maildium = new Maildium()
            {
                Id = message.Id,
                From = GetHeaderValueByHeaderName(payload.Headers, "From"),
                To = GetHeaderValueByHeaderName(payload.Headers, "To"),
                Subject = GetHeaderValueByHeaderName(payload.Headers, "Subject"),
                RecieveDate = GetHeaderValueByHeaderName(payload.Headers, "Date"),
                IsRead = !message.LabelIds.Contains("UNREAD"),
                MessageBody = payloadMessage
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

        private string GetMessageFromEmailBody(MessagePart messagePart)
        {
            string message = string.Empty;
            string messageData = messagePart.Body.Data;

            if (messageData == null && messagePart.Parts.Count > 0)
            {
                messageData = GetMessageFromEmailBody(messagePart.Parts[0]);
            }

            try
            {
                messageData.Replace("-", "+").Replace("_", "/");
                byte[] data = Convert.FromBase64String(messageData);
                string decodedString = Encoding.UTF8.GetString(data);
                message = decodedString;
            }
            catch (FormatException)
            {
                message = "<There was an error in decoding your message. This may be the result of your email contaning images, attachments or other non text based elements.>";
            }
            
            
            

            return message;
        }
    }
}
