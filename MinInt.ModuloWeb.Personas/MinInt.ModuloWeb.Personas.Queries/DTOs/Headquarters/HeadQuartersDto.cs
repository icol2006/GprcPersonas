using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.Queries.Common.Mapping;

namespace MinInt.ModuloWeb.Personas.Api.Controllers
{
    public class HeadQuartersDto
    {
        public int ID_JEFATURA { get; set; }

        public string TITULO { get; set; }

        public string NOMBRE_DEL_JEFE { get; set; }

        public int? RUT_DEL_JEFE { get; set; }
    }
}