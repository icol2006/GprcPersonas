using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("JEFATURA")]
    public class Jefaturas
    {
        [Key]
        public int ID_JEFATURA { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string TITULO { get; set; }
        public int? ID_JEFE { get; set; }
        public Personas JEFE { get; set; }
        public int? ID_SUBROGANTE { get; set; }
        public Personas SUBROGANTE { get; set; }
        public List<Personas> PERSONAS { get; set; }
    }
}
