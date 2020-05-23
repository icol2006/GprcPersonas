using Grpc.Core;
using Jefaturas;
using MediatR;
using Microsoft.Extensions.Logging;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands;
using System.Threading.Tasks;


namespace MinInt.ModuloWeb.Personas.Server.Services
{
    public class JefaturaService : jefatura.jefaturaBase
    {
        private readonly ILogger<JefaturaService> _logger;
        private readonly IMediator _mediator;

        public JefaturaService(ILogger<JefaturaService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public override async Task<JefaturaReply> Create(JefaturaRequest request, ServerCallContext context)
        {
            var data = new JefaturaCreateCommand();
            data.TITULO = request.TITULO;
            data.ID_JEFE = request.IDJEFE;
            data.ID_SUBROGANTE = request.IDSUBROGANTE;
            data.ID_EVALUADOR = request.IDEVALUADOR;

            await Crear(data);

            return new JefaturaReply
            {
                Respuesta = true
            };
        }

        public async Task Crear(JefaturaCreateCommand command)
        {
            await _mediator.Publish(command);
        }


    }
}
