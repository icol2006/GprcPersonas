using MediatR;
using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class JefaturaCreateHandler : INotificationHandler<JefaturaCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public JefaturaCreateHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Handle(JefaturaCreateCommand command, CancellationToken cancellationToken)
        {
            _context.Add(new Jefaturas
            {
                TITULO = command.TITULO,
                ID_JEFE = command.ID_JEFE,
                ID_SUBROGANTE = command.ID_SUBROGANTE
            });

            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
