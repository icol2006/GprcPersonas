namespace MinInt.ModuloWeb.Personas.Queries.DTOs
{
    public class PersonaDto
    {
        public int ID_PER { get; set; }
        public string NOMBRES { get; set; }
        public string AP_PATERNO { get; set; }
        public string AP_MATERNO { get; set; }
        public int ESTADO { get; set; }
        public int? RUT { get; set; }
        public string DIG_VER { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public string PASSWORD { get; set; }
        public int ID_JEFE { get; set; }
        public int ID_ESTADO_PERSONA { get; set; }
    }
}