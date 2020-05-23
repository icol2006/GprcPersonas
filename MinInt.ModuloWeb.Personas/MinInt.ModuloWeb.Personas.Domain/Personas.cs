using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinInt.ModuloWeb.Personas.Domain
{
    [Table("PERSONAS")]
    public class Personas
    {
        [Key]
        public int ID_PER { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string NOMBRES { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string AP_PATERNO { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string AP_MATERNO { get; set; }

        public int ESTADO { get; set; }

        public int? RUT { get; set; }

        [Column(TypeName = "varchar(1)")]
        public string DIG_VER { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string CORREO_ELECTRONICO { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string PASSWORD { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string USUARIO_WINDOWS { get; set; }

        public int ID_CENTRO_COSTO { get; set; }

        public CentroCosto CENTRO_COSTO { get; set; }

        public List<RegistroEntradaSalida> REGISTROS { get; set; }

        public Jefaturas JEFATURA { get; set; }

        public List<Sistemas> SISTEMAS { get; set; }

        public List<Cambios> CAMBIOS { get; set; }

        public EstadoPersona ESTADOPERSONA { get; set; }
    }
}