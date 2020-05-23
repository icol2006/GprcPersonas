using MediatR;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class SubstractAccessUserHandler : IRequestHandler<SubstracAccessUserCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public SubstractAccessUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(SubstracAccessUserCommand request, CancellationToken cancellationToken)
        {
            var personUser = await _context.PersonasUsuario.FirstOrDefaultAsync(x => x.ID_PER == request.ID_PER && x.ID_PERMISOS_USUARIOS == request.ID_PERMISOS_USUARIOS);

            if (personUser == null) throw new NotFoundException(nameof(PersonasUsuario), personUser.ID_PERMISOS_USUARIOS);

            _context.PersonasUsuario.Remove(personUser);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return personUser.ID_PER;
        }
    }
}
