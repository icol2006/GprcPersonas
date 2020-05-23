using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("PERMISOS_USUARIOS")]
    public class PermisosUsuario
    {
        [Key]
        public int ID_PERMISOS_USUARIOS { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string DESCRIPCION { get; set; }
    }
}
