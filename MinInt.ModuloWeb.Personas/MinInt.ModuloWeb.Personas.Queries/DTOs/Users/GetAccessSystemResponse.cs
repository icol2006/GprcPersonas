using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs
{
    public class GetAccessSystemResponse
    {
        public IList<SistemaDto> Systems { get; set; }

        public IList<SistemaDto> SystemAccessAssigned { get; set; }

        public IList<PermisosSistemaDto> PermissionsNotAssigned { get; set; }
    }
}