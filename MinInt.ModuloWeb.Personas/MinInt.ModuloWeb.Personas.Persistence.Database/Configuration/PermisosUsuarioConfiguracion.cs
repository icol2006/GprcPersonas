using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinInt.ModuloWeb.Personas.Domain;
using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.Persistence.Database.Configuration
{
    public class PermisosUsuarioConfiguracion
    {
        public PermisosUsuarioConfiguracion(EntityTypeBuilder<PermisosUsuario> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ID_PERMISOS_USUARIOS);
            entityBuilder.Property(x => x.DESCRIPCION);

            var permisosUsuario = new List<PermisosUsuario>();

            for (var i = 1; i <= 2; i++)
            {
                permisosUsuario.Add(new PermisosUsuario
                {
                    ID_PERMISOS_USUARIOS = i,
                    DESCRIPCION = $"Tipo de acceso {i}",
                }); 
            }

            entityBuilder.HasData(permisosUsuario);
        }
    }
}
