using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Solution.VivoTeste.BotMicrosservice.Aplicacao.Services;
using Solution.VivoTeste.BotMicrosservice.Controllers.Request;
using Solution.VivoTeste.BotMicrosservice.Dominio.Entidade;
using Solution.VivoTeste.BotMicrosservice.Dominio.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.VivoTeste.BotMicrosservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/bot")]
    public class BotController : ControllerBase
    {

        private readonly ILogger<BotController> logger;
        private readonly IServicoRobo botService;


        public BotController(ILogger<BotController> logger, IServicoRobo botService)
        {
            this.logger = logger;
            this.botService = botService;

        }

        [HttpGet]
       [AllowAnonymous]
        public async Task<IActionResult> ConsultarRoboPeloID(Guid id)
        {
            Solution.VivoTeste.BotMicrosservice.Controllers.Result.Result<BotEntity> resultBotEntity = new Solution.VivoTeste.BotMicrosservice.Controllers.Result.Result<BotEntity>();
            try
            {
                BotEntity obj = await botService.ConsultarRoboPeloID(id);

                if (obj == null) return NotFound();

                resultBotEntity.entidade = obj;
                resultBotEntity.Mensagem = "Sucesso";
            }
            catch (Exception e)
            {
                resultBotEntity.Mensagem = e.Message;
            }
            var resultMessageEntityText = JsonConvert.SerializeObject(resultBotEntity);

            return Ok(resultMessageEntityText);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IncluirRobo([FromBody] RoboRequisicao request)
        {
            Solution.VivoTeste.BotMicrosservice.Controllers.Result.Result<BotEntity> resultBotEntity = new Solution.VivoTeste.BotMicrosservice.Controllers.Result.Result<BotEntity>();

            try
            {
                await botService.IncluirRobo(request);

                resultBotEntity.Mensagem = "Sucesso";
               
            }
            catch (Exception e)
            {
                resultBotEntity.Mensagem = e.Message;
            }

            var resultMessageEntityText = JsonConvert.SerializeObject(resultBotEntity);

            return Ok(resultMessageEntityText);
        }

        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> DeletarRobo(Guid id)
        {
            Solution.VivoTeste.BotMicrosservice.Controllers.Result.Result<BotEntity> resultBotEntity = new Solution.VivoTeste.BotMicrosservice.Controllers.Result.Result<BotEntity>();

            try
            {
                await botService.DeletarRobo(id);

                resultBotEntity.Mensagem = "Sucesso";

            }
            catch (Exception e)
            {
                resultBotEntity.Mensagem = e.Message;
            }

            var resultMessageEntityText = JsonConvert.SerializeObject(resultBotEntity);

            return Ok(resultMessageEntityText);
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> AtualizarRobo(RoboRequisicao request)
        {
            Solution.VivoTeste.BotMicrosservice.Controllers.Result.Result<BotEntity> resultBotEntity = new Solution.VivoTeste.BotMicrosservice.Controllers.Result.Result<BotEntity>();

            try
            {
                await botService.AtualizarRobo(request);
                resultBotEntity.Mensagem = "Sucesso";

            }
            catch (Exception e)
            {
                resultBotEntity.Mensagem = e.Message;
            }

            var resultMessageEntityText = JsonConvert.SerializeObject(resultBotEntity);

            return Ok(resultMessageEntityText);
        }
    }
}
