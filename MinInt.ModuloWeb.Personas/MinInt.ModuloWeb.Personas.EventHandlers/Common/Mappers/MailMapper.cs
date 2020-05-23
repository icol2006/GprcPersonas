using MinInt.ModuloWeb.Personas.Queries.DTOs;
using static MinInt.ModuloWeb.Personas.Utilities.TechnicalResponse;

namespace MinInt.ModuloWeb.Personas.EventHandlers.Mappers
{
    public class MailMapper
    {
        public static NewPassResponse Map(Domain.Personas persona)
        {
            return new NewPassResponse()
            {
                NOMBRE_COMPLETO = persona.NOMBRES + " " + persona.AP_PATERNO + " " + persona.AP_MATERNO,
                CORREO_ELECTRONICO = persona.CORREO_ELECTRONICO,
                ID_PER = persona.ID_PER,
                ERROR = ErrorCode.None
            };
        }
    }
}
