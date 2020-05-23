using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters;
using MinInt.ModuloWeb.Personas.Queries.HeadQuarters;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.EventHandlers.HeadQuarters
{
    public class GetIdQueryHandler : IRequestHandler<GetIdQuery, GetIdResponse>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetIdResponse> Handle(GetIdQuery request, CancellationToken cancellationToken)
        {
            var jefatura = await _context.Jefaturas
                .ProjectTo<JefaturaDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(x => x.ID_JEFATURA == request.IdJefatura)
                .ConfigureAwait(false);

            var persons = await _context.Personas
                .Where(x => x.JEFATURA.ID_JEFATURA == request.IdJefatura)
                .ProjectTo<GetIdDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            var personsNoChief = await _context.Personas
                .Where(x => x.JEFATURA == null)
                .ProjectTo<GetIdDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return new GetIdResponse
            {
                Persons = persons,
                PersonsNoChief = personsNoChief,
                Jefatura = jefatura
            };
        }
    }
}
