using MediatR;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.EventHandlers.Commons.Helpers;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters;
using MinInt.ModuloWeb.Personas.Queries.HeadQuarters;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers.HeadQuarters
{
    public class GetAssignQueryHandler : IRequestHandler<GetAssignQuery, GetAssignQueryResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAssignQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetAssignQueryResponse> Handle(GetAssignQuery request, CancellationToken cancellationToken)
        {
            var persons = await _context.Personas
                .Where(x => x.JEFATURA.ID_JEFATURA == request.IdJefatura)
                .Skip((request.NumberPage - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var totalPages = Paging.GetTotalPages(persons.Count(), request.PageSize);

            return new GetAssignQueryResponse 
            {
                Personas = persons,
                TotalPages = totalPages
            };
        }
    }
}
