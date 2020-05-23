using MinInt.ModuloWeb.Personas.Queries.Common.Mapping;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters
{
    public class PersonDto : IMapFrom<Domain.Personas>
    {
        public int ID_PER { get; set; }

        public string NOMBRES { get; set; }
    }
}