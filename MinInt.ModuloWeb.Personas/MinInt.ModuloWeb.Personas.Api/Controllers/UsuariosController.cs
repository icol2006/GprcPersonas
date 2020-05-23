using Emails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MinInt.ModuloWeb.Personas.Api.Models;
using MinInt.ModuloWeb.Personas.Api.Services;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands;
using MinInt.ModuloWeb.Personas.Queries;
using MinInt.ModuloWeb.Personas.Queries.DTOs;
using MinInt.ModuloWeb.Personas.Queries.Users;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.Api.Controllers
{
    [Route("Usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<DefaultController> logger;
        private UrlsConfig _urls;

        public UsuariosController(IMediator mediator,
            IOptions<UrlsConfig> options,
            ILogger<DefaultController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
            _urls = options.Value;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel credencials)
        {
            var result = await mediator.Send(new LoginQuery(credencials.rut, credencials.pass));

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int numberPage, int pageSize)
        {
            var users = await mediator.Send(new GetAllUsersQuery { PageNumber = numberPage, PageSize = pageSize });

            return Ok(users);
        }


        [HttpGet("GetAllNoChief")]
        public async Task<IActionResult> GetAll()
        {
            var users = await mediator.Send(new GetAllUsersNoChiefQuery());

            return Ok(users);
        }

        [HttpPost("WriteNewPass")]
        public async Task<IActionResult> WriteNewPass(string Password, int IdPer)
        {
            var person = await mediator.Send(new WriteNewPassQuery(Password, IdPer));

            await GrpcCallerService.CallService(_urls.GrpcMail, channel =>
            {
                var client = new Mailer.MailerClient(channel);
                client.MailChagedPassword(new MailRequest
                {
                    CuentaDestino = person.CORREO_ELECTRONICO,
                    Nombre = person.NOMBRE_COMPLETO,
                    IdPersona = person.ID_PER,
                    CodEmail = 1
                });

                return Task.CompletedTask;
            });

            return Ok(person);
        }

        [HttpPost("SendMailUrlNewPass")]
        public async Task<IActionResult> NewPass(int rut)
        {
            var person = await mediator.Send(new NewPassQuery(rut));

            await GrpcCallerService.CallService(_urls.GrpcMail, channel =>
            {
                var client = new Mailer.MailerClient(channel);
                client.MailChagedPassword(new MailRequest
                {
                    CuentaDestino = person.CORREO_ELECTRONICO,
                    Nombre = person.NOMBRE_COMPLETO,
                    IdPersona = person.ID_PER,
                    CodEmail = 1
                });

                return Task.CompletedTask;
            });

            return Ok(person);
        }

        [HttpGet("GetAccessUser")]
        public async Task<GetAccessUserResponse> GetAccessUserAsync(int personId)
        {
            return await mediator.Send(new GetAccesUserQuery { PersonId = personId });
        }

        [HttpPost("AddAccessUser")]
        public async Task<GetAccessUserResponse> AddAccessUserAsync(AddAccessUserCommand command)
        {
            var personId = await mediator.Send(command);
            return await mediator.Send(new GetAccesUserQuery { PersonId = personId });
        }

        [HttpPost("SubstracAccessUser")]
        public async Task<GetAccessUserResponse> SubstracAccessUserAsync(SubstracAccessUserCommand command)
        {
            var personId = await mediator.Send(command);

            return await mediator.Send(new GetAccesUserQuery { PersonId = personId });
        }

        [HttpGet("GetAccessSystem/person-id/{personId}/permission-id/{permissionId}")]
        public async Task<GetAccessSystemResponse> GetAccessSystem(int personId, int permissionId)
        {
            return await mediator.Send(new GetAccessSystemQuery { ID_PER = personId, ID_SISTEMA = permissionId });
        }

        [HttpPost("AddAccessSystem")]
        public async Task<GetAccessSystemResponse> AddAccessSystemAsync(AddAccessSystemCommand command)
        {
            await mediator.Send(command);

            return await mediator.Send(new GetAccessSystemQuery { ID_PER = command.ID_PER, ID_SISTEMA = command.ID_SISTEMA });
        }

        [HttpPost("SubstracAccessSystem")]
        public async Task<GetAccessSystemResponse> SubstracAccessSystemAsync(SubstracAccessSystemCommand command)
        {
            await mediator.Send(command).ConfigureAwait(false);

            return await mediator.Send(new GetAccessSystemQuery { ID_PER = command.ID_PER, ID_SISTEMA = command.ID_SISTEMA });
        }
    }
}