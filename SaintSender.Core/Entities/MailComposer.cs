using System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1.Data;
using SaintSender.Core.Services;

namespace SaintSender.Core.Entities
{
    public class MailComposer
    {
        public void SendMessage(string userId, Message message)
        {
            JSONHandler.RequestSendMessage(userId, message);
        }
    }
}
