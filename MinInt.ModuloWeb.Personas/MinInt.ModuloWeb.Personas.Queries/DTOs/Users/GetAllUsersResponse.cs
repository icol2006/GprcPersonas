using System.Collections.Generic;
using static MinInt.ModuloWeb.Personas.Utilities.TechnicalResponse;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs
{
    public class GetAllUsersResponse
    {
        public int TotalPages { get; set; }
        public List<Usuarios> usuarios { get; set; }
        public ErrorCode ERROR { get; set; }
    }

    public class Usuarios
    {
        public int ID_PER { get; set; }
        public string NOMBRES { get; set; }
        public string AP_PATERNO { get; set; }
        public string AP_MATERNO { get; set; }
        public int? RUT { get; set; }
        public string DIG_VER { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public string ESTADO { get; set; }
    }
}
