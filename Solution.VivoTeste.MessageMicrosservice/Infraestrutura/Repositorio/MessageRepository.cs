using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Solution.VivoTeste.MessageMicrosservice.Dominio.Entidade;
using Solution.VivoTeste.MessageMicrosservice.Dominio.Ports;
using Solution.VivoTeste.MessageMicrosservice.Infraestrutura.Contexto;

namespace Solution.VivoTeste.MessageMicrosservice.Infraestrutura.Repositorio
{
    public class MessageRepository : IMessageConsultaRepositorio, IMessagecomandoRepositorio
    {
        private readonly MessageContext _context;

        public MessageRepository(MessageContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task SalvarMensagem(MessageEntity message)
        {
            _context.Message.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task<MessageEntity> ConsultarMensagemPorID(Guid Id)
        {
            MessageEntity message = await _context
               .Message.Where(o => o.Id == Id).FirstOrDefaultAsync();

            return message;
        }
        public async Task<List<MessageEntity>> ConsultarConversacaoPorID(Guid IdConversation)
        {
            List<MessageEntity> message = await _context
               .Message.Where(o => o.ConversationId == IdConversation).ToListAsync();

            return message;
        }

    }
}
