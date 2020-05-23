using MediatR;
using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class AddAccessUserHandler : IRequestHandler<AddAccessUserCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public AddAccessUserHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddAccessUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new PersonasUsuario
            {
                ID_PER = request.ID_PER,
                ID_PERMISOS_USUARIOS = request.ID_PERMISOS_USUARIOS
            };

            _context.PersonasUsuario.Add(entity);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return request.ID_PER;
        }
    }
}
