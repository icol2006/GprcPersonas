using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("PERMISOS_SISTEMAS")]
    public class PersonaSistema
    {
        [Key]
        public int ID_PERMISOS_SISTEMA { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string DESCRIPCION { get; set; }
    }
}
