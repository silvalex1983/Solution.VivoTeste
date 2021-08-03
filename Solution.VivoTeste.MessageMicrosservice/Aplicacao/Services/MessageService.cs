
using Solution.VivoTeste.MessageMicrosservice.Controllers.Request;
using Solution.VivoTeste.MessageMicrosservice.Dominio.Entidade;
using Solution.VivoTeste.MessageMicrosservice.Dominio.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.VivoTeste.MessageMicrosservice.Aplicacao.Services
{
    public class MessageService : IServicoMensagem
    {
        private readonly IMessageConsultaRepositorio messageConsultaRepositorio;
        private readonly IMessagecomandoRepositorio messagecomandoRepositorio;

        public MessageService(IMessageConsultaRepositorio messageReadOnlyRepository, IMessagecomandoRepositorio messageWriteOnlyRepository)
        {
            this.messageConsultaRepositorio = messageReadOnlyRepository;
            this.messagecomandoRepositorio = messageWriteOnlyRepository;
        }
       
        public async Task SalvarMensagem(MessageRequest request)
        {
            MessageEntity messageEntity = new MessageEntity();
            messageEntity.Id = Guid.NewGuid();
            messageEntity.ConversationId = request.ConversationId;
            messageEntity.From = request.From;
            messageEntity.Text = request.Text;
            messageEntity.To = request.To;
            messageEntity.TimeStamp = request.TimeStamp;

            await messagecomandoRepositorio .SalvarMensagem(messageEntity);
        }

       public async Task<MessageEntity> ConsultarMensagemPorID(Guid id)
        {
            return await messageConsultaRepositorio.ConsultarMensagemPorID(id);
        }

        public async Task<List<MessageEntity>> ConsultarConversacaoPorID(Guid IdConversation)
        {
            return await messageConsultaRepositorio.ConsultarConversacaoPorID(IdConversation);
        }
    }
}
