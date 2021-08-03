using Solution.VivoTeste.MessageMicrosservice.Controllers.Request;
using Solution.VivoTeste.MessageMicrosservice.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.VivoTeste.MessageMicrosservice.Dominio.Ports
{
   public  interface IServicoMensagem
    {
        public Task<MessageEntity> ConsultarMensagemPorID(Guid id);
        public Task SalvarMensagem(MessageRequest request);
        public  Task<List<MessageEntity>> ConsultarConversacaoPorID(Guid IdConversation);

    }
}
