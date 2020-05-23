using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinInt.ModuloWeb.Personas.Domain;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Configuration
{
    public class CambiosConfiguracion
    {
        public CambiosConfiguracion(EntityTypeBuilder<Cambios> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ID_CAMBIO);
            entityBuilder.Property(x => x.FECHA);
            entityBuilder.Property(x => x.DESCRIPCION); 
        }
    }
}
