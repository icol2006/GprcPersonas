using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class GetAccessSystemHandler : IRequestHandler<GetAccessSystemQuery, GetAccessSystemResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccessSystemHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAccessSystemResponse> Handle(GetAccessSystemQuery request, CancellationToken cancellationToken)
        {
            var systemData = await _context.Sistemas
                .ProjectTo<SistemaDto>(_mapper.ConfigurationProvider)
                .ToListAsync().ConfigureAwait(false);

            var personSystemAccess = await _context.PersonasSistemas
                .Include(x => x.SISTEMAS)
                .Where(x => x.ID_PER == request.ID_PER)
                .ToListAsync()
                .ConfigureAwait(false);

            var permissionsNotAssigned = _context.PermisosSistema
                .ProjectTo<PermisosSistemaDto>(_mapper.ConfigurationProvider)
                .AsEnumerable()
                .Where(x => !personSystemAccess.Any(y => y.ID_PERMISOS_SISTEMA == x.ID_PERMISOS_SISTEMA))
                .ToList();

            var systemAccess = personSystemAccess
                .Select(x => x.SISTEMAS);

            var systemAccessDto = _mapper.Map<IList<SistemaDto>>(systemAccess);

            return new GetAccessSystemResponse
            {
                Systems = systemData,
                SystemAccessAssigned = systemAccessDto,
                PermissionsNotAssigned = permissionsNotAssigned
            };
        }
    }
}
