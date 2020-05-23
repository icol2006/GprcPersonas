using Emails;
using Grpc.Core;
using Grpc.Net.Client;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MinInt.ModuloWeb.Personas.Queries;
using MinInt.ModuloWeb.Personas.Queries.Users;
using MinInt.ModuloWeb.Personas.Utilities;
using Personas;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.Api
{
    public class PersonaService : persona.personaBase
    {
        public IConfiguration _configuration { get; }
        private readonly ILogger<PersonaService> _logger;
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        /// <param name="configuration"></param>
        public PersonaService(ILogger<PersonaService> logger, IMediator mediator, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<LoginReply> Login(LoginRequest request, ServerCallContext context)
        {
            var result = _mediator.Send(new LoginQuery(request.Rut, request.Pass));

            return Task.FromResult(new LoginReply
            {
                //Error = (ErrorCode)result.Result
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<NewPassReply> NewPass(NewPassRequest request, ServerCallContext context)
        {
            var person = _mediator.Send(new NewPassQuery(request.Rut));

            if (person.Result.ERROR == TechnicalResponse.ErrorCode.None)
            {

                var channel = GrpcChannel.ForAddress(_configuration.GetSection("Mail").GetSection("url").Value);
                var client = new Mailer.MailerClient(channel);

                var reply = client.MailChagedPassword(new MailRequest
                {
                    CuentaDestino = person.Result.CORREO_ELECTRONICO,
                    Nombre = person.Result.NOMBRE_COMPLETO,
                    IdPersona = person.Result.ID_PER,
                    CodEmail = 1
                });

                var error = reply.Error; //Que se hace con el error
            }

            return Task.FromResult(new NewPassReply
            {
                //Error = (ErrorCode)person.Result.ERROR
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<WriteNewPassReply> WriteNewPass(WriteNewPassRequest request, ServerCallContext context)
        {
            var person = _mediator.Send(new WriteNewPassQuery(request.Pass, request.IdPer));

            return Task.FromResult(new WriteNewPassReply
            {
                //Error = (ErrorCode)person.Result.ERROR
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="responseStream"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GetAllUsers(GetAllUsersRequest request, IServerStreamWriter<GetAllUsersReply> responseStream, ServerCallContext context)
        {
            //var users = _mediator.Send(new GetAllUsersQuery());

            //foreach (var item in users.Result.usuarios)
            //{
            //    await responseStream.WriteAsync(new GetAllUsersReply()
            //    {
            //        Usuario = new Usuario()
            //        {
            //            IdPer = item.ID_PER,
            //            Nombres = item.NOMBRES,
            //            ApPaterno = item.AP_PATERNO,
            //            ApMaterno = item.AP_MATERNO,
            //            Rut = (int)item.RUT,
            //            DigVer = item.DIG_VER,
            //            CorreoElectronico = item.CORREO_ELECTRONICO
            //        },
            //        //Error = (ErrorCode)users.Result.ERROR
            //    });
            //}

            return Task.CompletedTask;
        }

        public override async Task<GetByIdReply> GetById(GetByIdRequest request, ServerCallContext context)
        {
            var user = (await _mediator.Send(new GetUserByIdQuery { IdPer = request.IdPer })).Data;

            return new GetByIdReply
            {
                CentroCosto = user.CentroCosto,
                IdCentroCosto = user.IdCentroCosto,
                IdJefe = user.IdJefe,
                IdPer = user.IdPer,
                IdSubrrogante = user.IdSubrrogante,
                Nombre = user.Nombre,
                NombreJefe = user.NombreJefe,
                NombreJefeSubrrogante = user.NombreJefeSubrrogante
            };
        }
    }
}