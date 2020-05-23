using static MinInt.ModuloWeb.Personas.Utilities.TechnicalResponse;
using MinInt.ModuloWeb.Personas.EventHandlers.Mappers;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries.DTOs;
using MinInt.ModuloWeb.Personas.Queries;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using MediatR;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class NewPassHandler : IRequestHandler<NewPassQuery, NewPassResponse>
    {
        private readonly ApplicationDbContext _context;

        public NewPassHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<NewPassResponse> Handle(NewPassQuery request, CancellationToken cancellationToken)
        {
            var person = (from A in _context.Personas where A.RUT == request.Rut select A).FirstOrDefault();
            var newpassResponse = new NewPassResponse();
            if (person != null)
            {
                newpassResponse = MailMapper.Map(person);
                newpassResponse.ERROR = ErrorCode.None;
            }
            else
            {
                newpassResponse.ERROR = ErrorCode.UsuarioNoResgistrado;
            }
            return Task.FromResult(newpassResponse);
        }
    }
}