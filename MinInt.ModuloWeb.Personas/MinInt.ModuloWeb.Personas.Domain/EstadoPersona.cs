using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("ESTADO_PERSONA")]
    public class EstadoPersona
    {
        [Key]
        public int ID_ESTADO_PERSONA { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string DESCRIPCION { get; set; }

        public List<Personas> PERSONAS { get; set; }
    }
}
