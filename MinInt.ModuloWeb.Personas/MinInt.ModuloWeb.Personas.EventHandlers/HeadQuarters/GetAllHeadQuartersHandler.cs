using MediatR;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.Api.Controllers;
using MinInt.ModuloWeb.Personas.EventHandlers.Commons.Helpers;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class GetAllHeadQuartersHandler : IRequestHandler<GetAllHeadQuartersQuery, GetAllHeadQuartersResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetAllHeadQuartersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllHeadQuartersResponse> Handle(GetAllHeadQuartersQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllHeadQuartersResponse();

            response.List = await (from jefatura in _context.Jefaturas
                                   join jefe in _context.Personas
                                   on jefatura.ID_JEFE equals jefe.ID_PER
                                   select new HeadQuartersDto
                                   {
                                       ID_JEFATURA = jefatura.ID_JEFATURA,
                                       TITULO = jefatura.TITULO,
                                       NOMBRE_DEL_JEFE = jefe.NOMBRES,
                                       RUT_DEL_JEFE = jefe.RUT
                                   })
                         .Skip((request.NumberPage - 1) * request.PageSize)
                         .Take(request.PageSize)
                         .ToListAsync(cancellationToken);

            var total = await _context.Jefaturas
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);

            response.TotalPages = Paging.GetTotalPages(total, request.PageSize);

            return response;
        }
    }
}
