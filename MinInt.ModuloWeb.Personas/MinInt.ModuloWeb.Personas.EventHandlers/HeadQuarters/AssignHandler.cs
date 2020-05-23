using MediatR;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands.Headquarters;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers.HeadQuarters
{
    public class AssignHandler : IRequestHandler<AssignCommand>
    {
        private readonly ApplicationDbContext _context;

        public AssignHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AssignCommand request, CancellationToken cancellationToken)
        {
            await _context.Personas
                .Where(x => request.IdPer.Any(personIds => personIds == x.ID_PER))
                .ForEachAsync(x => _context.Entry(x).Property("ID_JEFATURA").CurrentValue = request.IdJefatura)
                .ConfigureAwait(false);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
