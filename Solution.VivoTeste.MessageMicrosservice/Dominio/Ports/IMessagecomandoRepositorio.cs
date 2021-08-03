using Solution.VivoTeste.MessageMicrosservice.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.VivoTeste.MessageMicrosservice.Dominio.Ports
{
   public interface IMessagecomandoRepositorio
    {
        public Task SalvarMensagem(MessageEntity bot);
      

    }
}
