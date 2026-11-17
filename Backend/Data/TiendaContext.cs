using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Backend.Data
{
    public class TiendaContext : DbContext
    {
        public TiendaContext()
        {
        }

        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<TipoProducto> TiposProducto { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                var cadenaConexion = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(cadenaConexion).UseSnakeCaseNamingConvention();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Paises
            modelBuilder.Entity<Pais>().HasData(
                new Pais { Id = 1, Name = "Argentina" },
                new Pais { Id = 2, Name = "Brasil" },
                new Pais { Id = 3, Name = "Chile" }
            );

            // Seed Provincias
            modelBuilder.Entity<Provincia>().HasData(
                new Provincia { Id = 1, Name = "Buenos Aires", PaisId = 1 },
                new Provincia { Id = 2, Name = "Córdoba", PaisId = 1 },
                new Provincia { Id = 3, Name = "Santa Fe", PaisId = 1 }
            );

            // Seed Localidades
            modelBuilder.Entity<Localidad>().HasData(
                new Localidad { Id = 1, Name = "Buenos Aires", ProvinciaId = 1 },
                new Localidad { Id = 2, Name = "Córdoba", ProvinciaId = 2 },
                new Localidad { Id = 3, Name = "Santa Fe", ProvinciaId = 3 },
                new Localidad { Id = 4, Name = "Rosario", ProvinciaId = 3 },
                new Localidad { Id = 5, Name = "San Justo", ProvinciaId = 3 }
            );

            // Seed Clientes
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Firstname = "Juan Pablo", Lastname = "Aguero", Dni = "29720301", Address = "Calle Falsa 123", LocalidadId = 4 },
                new Cliente { Id = 2, Firstname = "María", Lastname = "González", Dni = "87654321", Address = "Avenida Siempre Viva 456", LocalidadId = 4 },
                new Cliente { Id = 3, Firstname = "Pedro", Lastname = "López", Dni = "11223344", Address = "Callejón del Beso 789", LocalidadId = 4 }
            );

            // Seed TiposProducto
            modelBuilder.Entity<TipoProducto>().HasData(
                new TipoProducto { Id = 1, Name = "Consola" },
                new TipoProducto { Id = 2, Name = "Juego" },
                new TipoProducto { Id = 3, Name = "Suscripción" }
            );

            // created_at default
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Created_at)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Producto>()
                .Property(p => p.Created_at)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Venta>()
                .Property(v => v.Date)
                .HasDefaultValueSql("NOW()");

            // query filters isDeleted
            modelBuilder.Entity<Cliente>().HasQueryFilter(c => !c.isDeleted);
            modelBuilder.Entity<Localidad>().HasQueryFilter(l => !l.isDeleted);
            modelBuilder.Entity<Provincia>().HasQueryFilter(p => !p.isDeleted);
            modelBuilder.Entity<Pais>().HasQueryFilter(p => !p.isDeleted);
            modelBuilder.Entity<TipoProducto>().HasQueryFilter(t => !t.isDeleted);
            modelBuilder.Entity<Producto>().HasQueryFilter(p => !p.isDeleted);
            modelBuilder.Entity<Venta>().HasQueryFilter(v => !v.isDeleted);

            // restrict delete localidad-provincia
            modelBuilder.Entity<Localidad>()
                .HasOne(l => l.Provincia)
                .WithMany()
                .HasForeignKey(l => l.ProvinciaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.TipoProducto)
                .WithMany()
                .HasForeignKey(p => p.TipoProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.VentaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}