using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("ORIENTACION")]
    public class Orientacion
    {
        [Key]
        public int COD_ORIENTACION { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string ORIENTACION { get; set; }

        public List<RegistroEntradaSalida> REGISTROS { get; set; }
    }
}