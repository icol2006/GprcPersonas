using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MinInt.ModuloWeb.Personas.Persistence.Database
{
    public class PersonaConfiguracion
    {
        public PersonaConfiguracion(EntityTypeBuilder<Domain.Personas> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ID_PER);
            entityBuilder.Property(x => x.NOMBRES);
            entityBuilder.Property(x => x.AP_PATERNO);
            entityBuilder.Property(x => x.AP_MATERNO);
            entityBuilder.Property(x => x.ESTADO);
            entityBuilder.Property(x => x.RUT);
            entityBuilder.Property(x => x.DIG_VER);
            entityBuilder.Property(x => x.PASSWORD);
            entityBuilder.Property(x => x.CORREO_ELECTRONICO);
            entityBuilder.Property(x => x.USUARIO_WINDOWS);
        }
    }
}
