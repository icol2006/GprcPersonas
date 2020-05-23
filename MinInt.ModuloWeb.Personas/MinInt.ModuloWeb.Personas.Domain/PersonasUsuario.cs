using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("PERSONAS_USUARIOS")]
    public class PersonasUsuario
    {
        public int ID_PER { get; set; } 
        public int ID_PERMISOS_USUARIOS { get; set; }

        public Personas PERSONA { get; set; }
        public PermisosUsuario PERMISOSUSUARIO { get; set; }
    }
}
