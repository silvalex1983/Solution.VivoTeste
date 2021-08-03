
using Solution.VivoTeste.BotMicrosservice.Controllers.Request;
using Solution.VivoTeste.BotMicrosservice.Dominio.Entidade;
using Solution.VivoTeste.BotMicrosservice.Dominio.Ports;
using System;
using System.Threading.Tasks;

namespace Solution.VivoTeste.BotMicrosservice.Aplicacao.Services
{
    public class ServicoRobo : IServicoRobo
    {
        private readonly IRoboConsultaRepositorio consultaRepositorio;
        private readonly IRoboComandoRepositorio comandoRepositorio;

        public ServicoRobo(IRoboConsultaRepositorio consultaRepositorio, IRoboComandoRepositorio comandoRepositorio)
        {
            this.consultaRepositorio = consultaRepositorio;
            this.comandoRepositorio = comandoRepositorio;
        }
        public async Task AtualizarRobo(RoboRequisicao request)
        {
            BotEntity botEntity = new BotEntity();
            botEntity.Id = request.Id;
            botEntity.Name = request.Name;

            await comandoRepositorio.AtualizarRobo(botEntity);
        }

        public async Task DeletarRobo(Guid id)
        {
            BotEntity botEntity = new BotEntity();
            botEntity.Id = id;
           await comandoRepositorio.DeletarRobo(botEntity);
        }

        public async Task IncluirRobo(RoboRequisicao request)
        {
            BotEntity botEntity = new BotEntity();
            botEntity.Id = request.Id;
            botEntity.Name = request.Name;

            await comandoRepositorio .IncluirRobo(botEntity);
        }

       public async Task<BotEntity> ConsultarRoboPeloID(Guid id)
        {
            return await consultaRepositorio.ConsultarRoboPeloID(id);
        }
    }
}
