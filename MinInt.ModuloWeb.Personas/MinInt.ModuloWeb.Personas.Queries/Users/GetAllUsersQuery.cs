using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs;

namespace MinInt.ModuloWeb.Personas.Queries
{
    public class GetAllUsersQuery : IRequest<GetAllUsersResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
