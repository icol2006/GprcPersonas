using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.Queries.Common.Mapping;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs
{
    public class SistemaDto : IMapFrom<Sistemas>
    {
        public int ID_SISTEMA { get; set; }

        public string DESCRIPCION { get; set; }
    }
}