using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("CAMBIOS")]
    public class Cambios
    {
        [Key]
        public int ID_CAMBIO { get; set; }

        [Column(TypeName = "date")]
        public DateTime FECHA { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string DESCRIPCION { get; set; }

        public Personas PERSONA { get; set; }

        public EstadoCambios ESTADOCAMBIO { get; set; }
    }
}
