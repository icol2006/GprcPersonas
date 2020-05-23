using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs.Users;

namespace MinInt.ModuloWeb.Personas.Queries.Users
{
    public class GetUserByIdQuery : IRequest<GetUserByIdResponse>
    {
        public int IdPer { get; set; }
    }
}
