using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("SISTEMAS")]
    public class Sistemas
    {
        [Key]
        public int ID_SISTEMA { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string DESCRIPCION { get; set; }
    }
}
