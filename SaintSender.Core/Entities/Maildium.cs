using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Entities
{
    public struct Maildium
    {
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string RecieveDate { get; set; }
        public bool IsRead { get; set; }
        public string MessageBody { get; set; }
    }
}
