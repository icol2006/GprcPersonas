using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.Api.Controllers
{
    public class GetAllHeadQuartersResponse
    {
        public int TotalPages { get; set; }

        public IList<HeadQuartersDto> List { get; set; }
    }
}