using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs;

namespace MinInt.ModuloWeb.Personas.Queries
{
    public class GetAccesUserQuery : IRequest<GetAccessUserResponse>
    {
        public int PersonId { get; set; }
    }
}
