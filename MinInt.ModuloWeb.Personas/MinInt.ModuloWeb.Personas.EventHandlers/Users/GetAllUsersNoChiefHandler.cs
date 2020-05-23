using MediatR;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers.Users
{
    public class GetAllUsersNoChiefHandler : IRequestHandler<GetAllUsersNoChiefQuery, IList<string>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllUsersNoChiefHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<string>> Handle(GetAllUsersNoChiefQuery request, CancellationToken cancellationToken)
        {
            return await _context.Personas
                .Where(x => x.JEFATURA == null)
                .Select(x => $"{x.ID_PER} {x.NOMBRES} {x.AP_PATERNO} {x.AP_MATERNO}")
                .ToListAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
