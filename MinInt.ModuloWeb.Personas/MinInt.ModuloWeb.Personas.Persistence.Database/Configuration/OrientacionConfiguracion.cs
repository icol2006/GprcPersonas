using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinInt.ModuloWeb.Personas.Domain;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Configuration
{
    public class OrientacionConfiguracion
    {
        public OrientacionConfiguracion(EntityTypeBuilder<Orientacion> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.COD_ORIENTACION);
            entityBuilder.Property(x => x.ORIENTACION);
        }
    }
}