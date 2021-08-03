using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Solution.VivoTeste.MessageMicrosservice.Dominio.Entidade
{
    public class MessageEntity
    {

        public Guid Id;
        public Guid ConversationId;
        public DateTime TimeStamp;
        public Guid From;
        public Guid To;
        public string Text;

    }
}
