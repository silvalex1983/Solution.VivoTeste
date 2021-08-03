using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Solution.VivoTeste.MessageMicrosservice.Aplicacao.Services;
using Solution.VivoTeste.MessageMicrosservice.Controllers.Request;
using Solution.VivoTeste.MessageMicrosservice.Dominio.Entidade;
using Solution.VivoTeste.MessageMicrosservice.Dominio.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace Solution.VivoTeste.MessageMicrosservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/messages")]

    public class MessageController : ControllerBase
    {

        private readonly ILogger<MessageController> logger;
        private readonly IServicoMensagem messageService;


        public MessageController(ILogger<MessageController> logger, IServicoMensagem messageService)
        {
            this.logger = logger;
            this.messageService = messageService;

        }

        [Route("api/messages/{id:Guid}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConsultarMensagemPorID(Guid id)
        {
            Solution.VivoTeste.MessageMicrosservice.Controllers.Result.Result<MessageEntity> resultMessageEntity = new Solution.VivoTeste.MessageMicrosservice.Controllers.Result.Result<MessageEntity>();
            try
            {
                MessageEntity serviceResultMessageEntity = await messageService.ConsultarMensagemPorID(id);

                if (serviceResultMessageEntity == null) return NotFound();

                resultMessageEntity.entidade = serviceResultMessageEntity;
                resultMessageEntity.Mensagem = "Sucesso";
            }
            catch (Exception e)
            {
                resultMessageEntity.Mensagem = e.Message;
            }

            var resultMessageEntityText = JsonConvert.SerializeObject(resultMessageEntity);

            return Ok(resultMessageEntityText);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SalvarMensagem([FromBody] MessageRequest request)
        {
            Solution.VivoTeste.MessageMicrosservice.Controllers.Result.Result<MessageEntity> resultMessageEntity = new Solution.VivoTeste.MessageMicrosservice.Controllers.Result.Result<MessageEntity>();

            try
            {
                await messageService.SalvarMensagem(request);

                resultMessageEntity.Mensagem = "Sucesso";
               
            }
            catch (Exception e)
            {
                resultMessageEntity.Mensagem = e.Message;
            }

            var resultMessageEntityText = JsonConvert.SerializeObject(resultMessageEntity);

            return Ok(resultMessageEntityText);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConsultarConversacaoPorID(Guid idConversation)
        {
            Solution.VivoTeste.MessageMicrosservice.Controllers.Result.Result<MessageEntity[]> resultMessageEntity = new Solution.VivoTeste.MessageMicrosservice.Controllers.Result.Result<MessageEntity[]>();
            try
            {
                List<MessageEntity> serviceResultMessageEntity = await messageService.ConsultarConversacaoPorID(idConversation);
                if (serviceResultMessageEntity == null || serviceResultMessageEntity.Count==0) return NotFound();

                resultMessageEntity.entidade = serviceResultMessageEntity.ToArray();
                resultMessageEntity.Mensagem = "Sucesso";
            }
            catch (Exception e)
            {
                resultMessageEntity.Mensagem = e.Message;
            }


            var resultMessageEntityText = JsonConvert.SerializeObject(resultMessageEntity);

            return Ok(resultMessageEntityText);
        }

    }
}
