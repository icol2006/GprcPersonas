using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinInt.ModuloWeb.Personas.Domain;
using System;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Configuration
{
    public class PersonasSistemaConfiguration
    {
        public PersonasSistemaConfiguration(EntityTypeBuilder<PersonasSistemas> builder)
        {
            builder.HasKey(x => new { x.ID_PERMISOS_SISTEMA, x.ID_PER, x.ID_SISTEMA });

            builder.HasOne(x => x.SISTEMAS)
                .WithMany()
                .HasForeignKey(x => x.ID_SISTEMA);

            builder.HasOne(x => x.PERSONA)
                .WithMany()
                .HasForeignKey(x => x.ID_PER);


            builder.HasOne(x => x.PERMISOSSISTEMA)
                .WithMany()
                .HasForeignKey(x => x.ID_PERMISOS_SISTEMA);
        }
    }
}
