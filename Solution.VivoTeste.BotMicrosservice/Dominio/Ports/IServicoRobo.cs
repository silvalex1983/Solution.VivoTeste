using Solution.VivoTeste.BotMicrosservice.Controllers.Request;
using Solution.VivoTeste.BotMicrosservice.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.VivoTeste.BotMicrosservice.Dominio.Ports
{
   public  interface IServicoRobo
    {
        public Task<BotEntity> ConsultarRoboPeloID(Guid id);

        public Task IncluirRobo(RoboRequisicao request);

        public  Task DeletarRobo(Guid id);


        public Task AtualizarRobo(RoboRequisicao request);
       
    }
}
