using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Solution.VivoTeste.BotMicrosservice.Dominio.Entidade;
using Solution.VivoTeste.BotMicrosservice.Dominio.Ports;
using Solution.VivoTeste.BotMicrosservice.Infraestrutura.Contexto;

namespace Solution.VivoTeste.BotMicrosservice.Infraestrutura.Repositorio
{
    public class BotRepository: IRoboConsultaRepositorio, IRoboComandoRepositorio
    {
        private readonly BotContext _context;

        public BotRepository(BotContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task IncluirRobo(BotEntity bot)
        {
            _context.Bot.Add(bot);
            await _context.SaveChangesAsync();
        }

        public async Task <BotEntity> ConsultarRoboPeloID(Guid Id)
        {
            BotEntity bot =  _context
               .Bot.Where(o => o.Id == Id).FirstOrDefault();

            return bot;
        }

        public async Task AtualizarRobo(BotEntity bot)
        {
            _context.Entry(bot).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarRobo(BotEntity bot)
        {
            _context.Entry(bot).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
