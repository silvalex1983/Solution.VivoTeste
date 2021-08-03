using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.VivoTeste.MessageMicrosservice.Controllers.Request
{
    public class MessageRequest
    {
        private Guid conversationId;
        private DateTime timeStamp;
        private Guid from;
        private Guid to;
        private string text;

        public Guid ConversationId { get => conversationId; set => conversationId = value; }

        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
        public Guid From { get => from; set => from = value; }
        public Guid To { get => to; set => to = value; }
        public string Text { get => text; set => text = value; }
    }
}
