using MediatR;
using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class CreateHeadquarterHandler : IRequestHandler<CreateHeadquarterCommand, long>
    {
        private readonly ApplicationDbContext _context;

        public CreateHeadquarterHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateHeadquarterCommand request, CancellationToken cancellationToken)
        {
            var entity = new Jefaturas
            {
                TITULO = request.Titulo,
                ID_JEFE = request.IdJefe,
                ID_SUBROGANTE = request.IdSubrogante
            };

            _context.Jefaturas.Add(entity);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return entity.ID_JEFATURA;
        }
    }
}
