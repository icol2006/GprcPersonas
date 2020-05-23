using MediatR;
using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class SubstractAccessSystemHandler : IRequestHandler<SubstracAccessSystemCommand>
    {
        private readonly ApplicationDbContext _context;

        public SubstractAccessSystemHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SubstracAccessSystemCommand request, CancellationToken cancellationToken)
        {
            var person = await _context.Personas.FindAsync(request.ID_PER);

            if (person == null) throw new NotFoundException(nameof(Domain.Personas), request.ID_PER);

            var sistema = await _context.Sistemas.FindAsync(request.ID_SISTEMA);

            if (sistema == null) throw new NotFoundException(nameof(Sistemas), request.ID_SISTEMA);

            var permisos = await _context.PermisosSistema.FindAsync(request.ID_PERMISOS_SISTEMA);

            if (permisos == null) throw new NotFoundException(nameof(PersonaSistema), request.ID_PERMISOS_SISTEMA);

            var systemPerson = await _context.PersonasSistemas.FindAsync(
                permisos.ID_PERMISOS_SISTEMA,
                person.ID_PER,
                sistema.ID_SISTEMA
            )
            .ConfigureAwait(false);

            _context.PersonasSistemas.Remove(systemPerson);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
