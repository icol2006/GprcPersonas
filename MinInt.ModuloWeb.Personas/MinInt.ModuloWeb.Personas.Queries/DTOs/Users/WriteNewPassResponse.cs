using static MinInt.ModuloWeb.Personas.Utilities.TechnicalResponse;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs
{
    public class WriteNewPassResponse
    {
        public int ID_PER { get; set; }
        
        public string CORREO_ELECTRONICO { get; set; }

        public string NOMBRE_COMPLETO { get; set; }

        public ErrorCode ERROR { get; set; }
    }
}
