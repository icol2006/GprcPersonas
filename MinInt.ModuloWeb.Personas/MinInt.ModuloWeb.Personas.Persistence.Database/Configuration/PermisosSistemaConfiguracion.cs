using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinInt.ModuloWeb.Personas.Domain;
using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Configuration
{
    public class PermisosSistemaConfiguracion
    {
        public PermisosSistemaConfiguracion(EntityTypeBuilder<PersonaSistema> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ID_PERMISOS_SISTEMA);
            entityBuilder.Property(x => x.DESCRIPCION);

            var permisosSistema = new List<PersonaSistema>();

            for (var i = 1; i <= 2; i++)
            {
                permisosSistema.Add(new PersonaSistema
                {
                    ID_PERMISOS_SISTEMA = i,
                    DESCRIPCION = $"Tipo de acceso {i}",
                }); 
            }

            entityBuilder.HasData(permisosSistema);
        }
    }
}
