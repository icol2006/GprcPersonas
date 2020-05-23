using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters;

namespace MinInt.ModuloWeb.Personas.Queries.HeadQuarters
{
    public class GetIdQuery : IRequest<GetIdResponse>
    {
        public int IdJefatura { get; set; }
    }
}
