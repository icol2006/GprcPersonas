using MediatR;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers.HeadQuarters
{
    public class UpdateHeadQuarterHandler : IRequestHandler<UpdateHeadquarterCommand>
    {
        private readonly ApplicationDbContext _context;

        public UpdateHeadQuarterHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateHeadquarterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Jefaturas.SingleOrDefaultAsync(x => x.ID_JEFATURA == request.IdJefatura, cancellationToken);

            if (entity == null) throw new NotFoundException(nameof(Jefaturas), request.IdJefatura);

            entity.TITULO = request.Titulo;
            entity.ID_JEFE = request.IdJefe;
            entity.ID_SUBROGANTE = request.IdSubrogante;

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
