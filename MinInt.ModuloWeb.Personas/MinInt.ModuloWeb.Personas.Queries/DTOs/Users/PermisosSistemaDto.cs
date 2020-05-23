using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.Queries.Common.Mapping;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs
{
    public class PermisosSistemaDto : IMapFrom<PersonaSistema>
    {
        public int ID_PERMISOS_SISTEMA { get; set; }

        public string DESCRIPCION { get; set; }
    }
}
