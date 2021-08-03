using Solution.VivoTeste.MessageMicrosservice.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.VivoTeste.MessageMicrosservice.Dominio.Ports 
{ 
   public  interface IMessageConsultaRepositorio
    {
        public Task<MessageEntity> ConsultarMensagemPorID(Guid Id);
        public Task<List<MessageEntity>> ConsultarConversacaoPorID(Guid IdConversation);


    }
}
