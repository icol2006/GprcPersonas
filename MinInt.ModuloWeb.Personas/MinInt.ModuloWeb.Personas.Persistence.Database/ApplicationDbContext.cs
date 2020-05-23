using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.Persistence.Database.Configuration;

namespace MinInt.ModuloWeb.Personas.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<CentroCosto> CentroCostos { get; set; }
        public DbSet<Domain.Personas> Personas { get; set; }
        public DbSet<RegistroEntradaSalida> EntradasSalidas { get; set; }
        public DbSet<Orientacion> Orientacion { get; set; }
        public DbSet<Jefaturas> Jefaturas { get; set; }
        public DbSet<Cambios> Cambios { get; set; }
        public DbSet<EstadoCambios> EstadoCambios { get; set; }
        public DbSet<EstadoPersona> EstadoPersonas { get; set; }
        public DbSet<PersonasUsuario> PersonasUsuario { get; set; }
        public DbSet<PermisosUsuario> PermisosUsuario { get; set; }
        public DbSet<PersonaSistema> PermisosSistema { get; set; }
        public DbSet<Sistemas> Sistemas { get; set; }
        public DbSet<PersonasSistemas> PersonasSistemas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PersonasUsuario>()
              .HasKey(x => new { x.ID_PER, x.ID_PERMISOS_USUARIOS });

            builder.Entity<PersonasSistemas>()
             .HasKey(x => new { x.ID_PER, x.ID_PERMISOS_SISTEMA });

            builder.Entity<CentroCosto>()
                .HasMany(p => p.PERSONAS)
                .WithOne(b => b.CENTRO_COSTO)
                .HasForeignKey(x => x.ID_CENTRO_COSTO);

            builder.Entity<RegistroEntradaSalida>()
             .Property<int>("ID_PER");

            builder.Entity<RegistroEntradaSalida>()
              .HasOne(p => p.PERSONA)
              .WithMany(b => b.REGISTROS)
              .HasForeignKey("ID_PER");

            builder.Entity<RegistroEntradaSalida>()
             .Property<int>("ID_PER");

            builder.Entity<RegistroEntradaSalida>()
              .HasOne(p => p.PERSONA)
              .WithMany(b => b.REGISTROS)
              .HasForeignKey("ID_PER");

            builder.Entity<RegistroEntradaSalida>()
             .Property<int>("COD_ORIENTACION");

            builder.Entity<RegistroEntradaSalida>()
              .HasOne(p => p.ORIENTACION)
              .WithMany(b => b.REGISTROS)
              .HasForeignKey("COD_ORIENTACION");

            builder.Entity<Cambios>()
               .Property<int>("ID_PER");

            builder.Entity<Cambios>()
                .HasOne(p => p.PERSONA)
                .WithMany(b => b.CAMBIOS)
                .HasForeignKey("ID_PER");

            builder.Entity<Cambios>()
              .Property<int>("ID_ESTADO_CAMBIO");

            builder.Entity<Cambios>()
                .HasOne(p => p.ESTADOCAMBIO)
                .WithMany(b => b.CAMBIOS)
                .HasForeignKey("ID_ESTADO_CAMBIO");

            builder.Entity<Domain.Personas>()
              .Property<int>("ID_ESTADO_PERSONA");

            builder.Entity<Domain.Personas>()
                .HasOne(p => p.ESTADOPERSONA)
                .WithMany(b => b.PERSONAS)
                .HasForeignKey("ID_ESTADO_PERSONA");

            builder.Entity<Domain.Personas>()
                .Property<int?>("ID_JEFATURA");

            builder.Entity<Domain.Personas>()
                .HasOne(p => p.JEFATURA)
                .WithMany(b => b.PERSONAS)
                .HasForeignKey("ID_JEFATURA")
                .IsRequired(false);

            builder.Entity<Jefaturas>()
                .HasOne(x => x.JEFE)
                .WithOne()
                .HasForeignKey<Jefaturas>(x => x.ID_JEFE)
                .IsRequired(false);

            builder.Entity<Jefaturas>()
                .HasOne(x => x.SUBROGANTE)
                .WithOne()
                .HasForeignKey<Jefaturas>(x => x.ID_SUBROGANTE)
                .IsRequired(false);

            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new PersonaConfiguracion(modelBuilder.Entity<Domain.Personas>());
            new RegistroEntradaSalidaConfiguracion(modelBuilder.Entity<RegistroEntradaSalida>());
            new OrientacionConfiguracion(modelBuilder.Entity<Orientacion>());
            new JefaturaConfiguracion(modelBuilder.Entity<Jefaturas>());
            new CambiosConfiguracion(modelBuilder.Entity<Cambios>());
            new EstadoCambiosConfiguracion(modelBuilder.Entity<EstadoCambios>());
            new EstadoPersonaConfiguracion(modelBuilder.Entity<EstadoPersona>());
            new PermisosSistemaConfiguracion(modelBuilder.Entity<PersonaSistema>());
            new PermisosUsuarioConfiguracion(modelBuilder.Entity<PermisosUsuario>());
            new PersonasSistemaConfiguration(modelBuilder.Entity<PersonasSistemas>());
        }
    }
}
