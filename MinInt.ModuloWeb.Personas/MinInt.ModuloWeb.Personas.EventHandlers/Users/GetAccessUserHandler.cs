using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries;
using MinInt.ModuloWeb.Personas.Queries.DTOs;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class GetAccessUserHandler : IRequestHandler<GetAccesUserQuery, GetAccessUserResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccessUserHandler(ApplicationDbContext context, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetAccessUserResponse> Handle(GetAccesUserQuery request, CancellationToken cancellationToken)
        {
            var permissionsAssigned = await _context.PersonasUsuario
                .Where(x => x.ID_PER == request.PersonId)
                .Select(x => x.PERMISOSUSUARIO)
                .ProjectTo<UserPermissionDto>(_mapper.ConfigurationProvider)
                .ToListAsync()
                .ConfigureAwait(false);

            var permissionsNotAssigned = _context.PermisosUsuario
                .ProjectTo<UserPermissionDto>(_mapper.ConfigurationProvider)
                .AsEnumerable()
                .Where(x => !permissionsAssigned.Any(y => y.ID_PERMISOS_USUARIOS == x.ID_PERMISOS_USUARIOS))
                .ToList();

            return new GetAccessUserResponse
            {
                PermissionsAssigned = permissionsAssigned,
                PermissionsNotAssigned = permissionsNotAssigned
            };
        }
    }
}
