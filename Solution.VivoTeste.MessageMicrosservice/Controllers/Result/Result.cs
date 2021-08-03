using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Solution.VivoTeste.MessageMicrosservice.Controllers.Result
{
    public class Result<T>
    {
        public T entidade;

        public string Mensagem;

    }
}
