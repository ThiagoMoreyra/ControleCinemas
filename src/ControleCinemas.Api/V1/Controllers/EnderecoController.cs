using ControleCinemas.Api.Controllers;
using ControleCinemas.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleCinemas.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v1/enderecos")]
    public class EnderecoController : MainController
    {
        public EnderecoController(INotificador notificador) : base(notificador)
        {
        }
    }
}