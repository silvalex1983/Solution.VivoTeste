using Solution.VivoTeste.BotMicrosservice.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.VivoTeste.BotMicrosservice.Dominio.Ports
{
   public interface IRoboComandoRepositorio
    {
        public Task AtualizarRobo(BotEntity bot);
        public Task DeletarRobo(BotEntity bot);
        public Task IncluirRobo(BotEntity bot);
      

    }
}
