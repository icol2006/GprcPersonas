using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries.DTOs.Users;
using MinInt.ModuloWeb.Personas.Queries.Users;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Personas
                .Include(x => x.JEFATURA)
                .Include(x => x.CENTRO_COSTO)
                .SingleOrDefaultAsync(x => x.ID_PER == request.IdPer, cancellationToken)
                .ConfigureAwait(false);

            var result = _mapper.Map<GetUserByIdDto>(entity);

            return new GetUserByIdResponse
            {
                Data = result
            };
        }
    }
}
