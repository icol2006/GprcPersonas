using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinInt.ModuloWeb.Personas.Domain;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Configuration
{
    public class EstadoCambiosConfiguracion
    {
        public EstadoCambiosConfiguracion(EntityTypeBuilder<EstadoCambios> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ID_ESTADO_CAMBIO);
            entityBuilder.Property(x => x.DESCRIPCION); 
        }
    }
}
