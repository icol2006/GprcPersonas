using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinInt.ModuloWeb.Personas.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Configuration
{
    public class RegistroEntradaSalidaConfiguracion
    {
        public RegistroEntradaSalidaConfiguracion(EntityTypeBuilder<RegistroEntradaSalida> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.COD_ENTSAL);
            entityBuilder.Property(x => x.FECHA);
            entityBuilder.Property(x => x.HORA);
        }
    }
}
