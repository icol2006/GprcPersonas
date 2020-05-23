using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters;

namespace MinInt.ModuloWeb.Personas.Queries.HeadQuarters
{
    public class GetCostCenterQuery : IRequest<GetCostCenterQueryResponse>
    {
        public string CentroCosto { get; set; }
        public int NumberPage { get; set; }
        public int PageSize { get; set; }
    }
}
