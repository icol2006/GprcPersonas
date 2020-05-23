using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    class SearchUsersHandler : IRequestHandler<SearchUsersQuery, SearchUsersResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SearchUsersHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SearchUsersResponse> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
        {
            var result = new SearchUsersResponse();

            result.List = await _context.Personas
                    .Where(x => EF.Functions.Like(x.RUT.ToString().ToLower(), $"%{request.ToSearch.ToLower()}%") ||
                    EF.Functions.Like(x.NOMBRES.ToLower(), $"%{request.ToSearch.ToLower()}%") ||
                    EF.Functions.Like(x.AP_PATERNO.ToLower(), $"%{request.ToSearch.ToLower()}%") ||
                    EF.Functions.Like(x.AP_MATERNO.ToLower(), $"%{request.ToSearch.ToLower()}%"))
                    .ProjectTo<SearchUsersListDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return result;
        }
    }
}
