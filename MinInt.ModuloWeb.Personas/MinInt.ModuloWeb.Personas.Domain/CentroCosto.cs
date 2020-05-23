using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("CENTRO_COSTO")]
    public class CentroCosto
    {
        [Key]
        public int ID_CENTRO_COSTO { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string DESCRIPCION { get; set; }

        public IList<Personas> PERSONAS { get; private set; } = new List<Personas>();
    }
}
