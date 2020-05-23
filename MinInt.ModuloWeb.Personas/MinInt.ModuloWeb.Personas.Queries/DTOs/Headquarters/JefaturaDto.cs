using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.Queries.Common.Mapping;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters
{
    public class JefaturaDto : IMapFrom<Jefaturas>
    {
        public int ID_JEFATURA { get; set; }
        public string TITULO { get; set; }
        public PersonDto JEFE { get; set; }
        public PersonDto SUBROGANTE { get; set; }
    }
}