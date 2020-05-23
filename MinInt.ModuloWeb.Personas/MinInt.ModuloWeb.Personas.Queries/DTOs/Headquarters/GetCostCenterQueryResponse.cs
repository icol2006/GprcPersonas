using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters
{
    public class GetCostCenterQueryResponse
    {
        public List<GetCostCenterDto> Result { get; set; }
        public int TotalPages { get; set; }
    }
}
