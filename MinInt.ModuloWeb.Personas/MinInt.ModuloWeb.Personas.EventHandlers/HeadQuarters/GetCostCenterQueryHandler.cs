using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class GetCostCenterQueryHandler : IRequestHandler<GetCostCenterQuery, GetCostCenterQueryResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCostCenterQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetCostCenterQueryResponse> Handle(GetCostCenterQuery request, CancellationToken cancellationToken)
        {
            var queryFilter = _context.Personas
                .Where(x => EF.Functions.Like(x.CENTRO_COSTO.DESCRIPCION, $"%{request.CentroCosto.ToLower()}%"))
                .ProjectTo<GetCostCenterDto>(_mapper.ConfigurationProvider);

            var result = await queryFilter
                .Skip((request.NumberPage - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var totalPersonsByCostCenter = await queryFilter.CountAsync().ConfigureAwait(false);

            var totalPages = Paging.GetTotalPages(totalPersonsByCostCenter, request.PageSize);

            return new GetCostCenterQueryResponse
            {
                TotalPages = totalPages,
                Result = result
            };
        }
    }
}
