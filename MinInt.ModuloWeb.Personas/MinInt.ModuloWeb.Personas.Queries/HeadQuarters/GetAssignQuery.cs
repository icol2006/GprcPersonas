using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters;

namespace MinInt.ModuloWeb.Personas.Queries.HeadQuarters
{
    public class GetAssignQuery : IRequest<GetAssignQueryResponse>
    {
        public int IdJefatura { get; set; }
        public int NumberPage { get; set; }
        public int PageSize { get; set; }
    }
}
