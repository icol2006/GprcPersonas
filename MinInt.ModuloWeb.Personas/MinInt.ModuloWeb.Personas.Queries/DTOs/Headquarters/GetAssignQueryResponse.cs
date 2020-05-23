using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters
{
    public class GetAssignQueryResponse
    {
        public int TotalPages { get; set; }
        public IList<Domain.Personas> Personas { get; set; }
    }
}
