using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinInt.ModuloWeb.Personas.Domain;
using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Configuration
{
    public class EstadoPersonaConfiguracion
    {
        public EstadoPersonaConfiguracion(EntityTypeBuilder<EstadoPersona> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ID_ESTADO_PERSONA);
            entityBuilder.Property(x => x.DESCRIPCION);

            var estadoPersona = new List<EstadoPersona>();

            for (var i = 1; i <= 1; i++)
            {
                estadoPersona.Add(new EstadoPersona
                {
                    ID_ESTADO_PERSONA = i,
                    DESCRIPCION = $"Tipo de estado {i}"
                });
            }

            entityBuilder.HasData(estadoPersona);
        }
    }
}
