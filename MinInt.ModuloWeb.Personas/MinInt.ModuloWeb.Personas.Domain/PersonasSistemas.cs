using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("PERSONAS_SISTEMAS")]
    public class PersonasSistemas
    {
        public int ID_PER { get; set; }
        public int ID_PERMISOS_SISTEMA { get; set; }
        public int ID_SISTEMA { get; set; }

        public Sistemas SISTEMAS { get; set; }
        public Personas PERSONA { get; set; }
        public PersonaSistema PERMISOSSISTEMA { get; set; }
    }
}
