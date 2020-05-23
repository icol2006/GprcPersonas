using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinInt.ModuloWeb.Personas.Domain;
using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Configuration
{
    public class JefaturaConfiguracion
    {
        public JefaturaConfiguracion(EntityTypeBuilder<Jefaturas> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ID_JEFATURA);
            entityBuilder.Property(x => x.TITULO);
            entityBuilder.Property(x => x.ID_JEFE);
            entityBuilder.Property(x => x.ID_SUBROGANTE);

            var jefatura = new List<Jefaturas>();

            for (var i = 1; i <= 1; i++)
            {
                jefatura.Add(new Jefaturas
                {
                    ID_JEFATURA = i,
                    TITULO = $"Tipo de Jefatura {i}",
                    ID_JEFE = i,
                    ID_SUBROGANTE = i,
                }); 
            }
            entityBuilder.HasData(jefatura);
        }
    }
}
