using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("REGISTRO_ENTRADA_SALIDA")]
    public class RegistroEntradaSalida
    {
        [Key]
        public int COD_ENTSAL { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FECHA{ get; set; }

        [Column(TypeName = "datetime")]
        public DateTime HORA { get; set; }

        public Personas PERSONA { get; set; }

        public Orientacion ORIENTACION { get; set; }
    }
}