using Solution.VivoTeste.BotMicrosservice.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.VivoTeste.BotMicrosservice.Dominio.Ports 
{ 
   public  interface IRoboConsultaRepositorio
    {
        public Task<BotEntity> ConsultarRoboPeloID(Guid Id);
       
    }
}
