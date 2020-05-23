using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("ESTADO_CAMBIOS")]
    public class EstadoCambios
    {
        [Key]
        public int ID_ESTADO_CAMBIO { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string DESCRIPCION { get; set; }

        public List<Cambios> CAMBIOS { get; set; }
    }
}
