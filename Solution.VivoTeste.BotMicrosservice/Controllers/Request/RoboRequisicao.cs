using System;

namespace Solution.VivoTeste.BotMicrosservice.Controllers.Request
{
    public class RoboRequisicao
    {
        private Guid id;
        private string name;

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
