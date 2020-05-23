using MediatR;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters;
using MinInt.ModuloWeb.Personas.Queries.HeadQuarters;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers.HeadQuarters
{
    public class SearchHeadquartersHandler : IRequestHandler<SearchHeadquartersQuery, List<SearchHeadquartersResponse>>
    {
        private readonly ApplicationDbContext _context;

        public SearchHeadquartersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<SearchHeadquartersResponse>> Handle(SearchHeadquartersQuery request, CancellationToken cancellationToken)
        {
            var result = _context.Jefaturas
                .AsEnumerable()
                .Where(x => x.TITULO.Contains(request.Title, System.StringComparison.OrdinalIgnoreCase))
                .Select(x => new SearchHeadquartersResponse
                {
                    Title = x.TITULO,
                    JefaturaId = x.ID_JEFATURA
                }).ToList();

            return Task.FromResult(result);
        }
    }
}
