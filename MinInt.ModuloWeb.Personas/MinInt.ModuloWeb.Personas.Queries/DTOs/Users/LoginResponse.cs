using static MinInt.ModuloWeb.Personas.Utilities.TechnicalResponse;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs
{
    public class LoginResponse
    {
        public string Name { get; set; }
        public int IdPer { get; set; }
        public ErrorCode ERROR { get; set; }
    }
}
