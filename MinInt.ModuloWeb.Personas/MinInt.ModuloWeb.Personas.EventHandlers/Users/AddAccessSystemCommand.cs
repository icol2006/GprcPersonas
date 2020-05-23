using MediatR;
using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class AddAccessSystemCommandHandler : IRequestHandler<AddAccessSystemCommand>
    {
        private readonly ApplicationDbContext _context;

        public AddAccessSystemCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddAccessSystemCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.Personas.FindAsync(request.ID_PER);

            if (person == null) throw new NotFoundException(nameof(Domain.Personas), request.ID_PER);

            var sistema = await _context.Sistemas.FindAsync(request.ID_SISTEMA);

            if (sistema == null) throw new NotFoundException(nameof(Sistemas), request.ID_SISTEMA);

            var permisos = await _context.PermisosSistema.FindAsync(request.ID_PERMISOS_SISTEMA);

            if (permisos == null) throw new NotFoundException(nameof(PersonaSistema), request.ID_PERMISOS_SISTEMA);

            var entity = new PersonasSistemas
            {
                ID_PER = request.ID_PER,
                ID_PERMISOS_SISTEMA = request.ID_PERMISOS_SISTEMA,
                ID_SISTEMA = request.ID_SISTEMA
            };

            _context.PersonasSistemas.Add(entity);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
