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
        public DbSet<TipoProducto> TiposProducto { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Formato> Formatos { get; set; }
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
            // Fecha fija para todos los datos semilla (evita diffs aleatorios en las migraciones)
            var fechaSeed = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);

            // Seed Clientes (localidad, provincia y país como texto)
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Firstname = "Juan Pablo", Lastname = "Aguero", Dni = "29720301", Address = "Calle Falsa 123", Localidad = "Rosario", Provincia = "Santa Fe", Pais = "Argentina", Created_at = fechaSeed },
                new Cliente { Id = 2, Firstname = "María", Lastname = "González", Dni = "87654321", Address = "Avenida Siempre Viva 456", Localidad = "Rosario", Provincia = "Santa Fe", Pais = "Argentina", Created_at = fechaSeed },
                new Cliente { Id = 3, Firstname = "Pedro", Lastname = "López", Dni = "11223344", Address = "Callejón del Beso 789", Localidad = "Rosario", Provincia = "Santa Fe", Pais = "Argentina", Created_at = fechaSeed }
            );

            // Seed TiposProducto
            modelBuilder.Entity<TipoProducto>().HasData(
                new TipoProducto { Id = 1, Name = "Consola" },
                new TipoProducto { Id = 2, Name = "Juego" },
                new TipoProducto { Id = 3, Name = "Suscripción" }
            );

            string StorageUrl(string archivo) => $"https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/{archivo}";

            // Seed Plataformas y Formatos
            modelBuilder.Entity<Plataforma>().HasData(
                new Plataforma { Id = 1, Name = "PlayStation" },
                new Plataforma { Id = 2, Name = "Xbox" },
                new Plataforma { Id = 3, Name = "Nintendo" },
                new Plataforma { Id = 4, Name = "PC" }
            );

            modelBuilder.Entity<Formato>().HasData(
                new Formato { Id = 1, Name = "Físico" },
                new Formato { Id = 2, Name = "Digital" }
            );

            // Seed Productos (consolas, juegos y suscripciones)
            modelBuilder.Entity<Producto>().HasData(
                new Producto { Id = 1, Name = "PlayStation 5 Slim", Description = "Consola PlayStation 5 Slim 1TB", Price = 1250000, Stock = 8, ImageUrl = StorageUrl("ps5.png"), TipoProductoId = 1, PlataformaId = 1, FormatoId = 1, Created_at = fechaSeed },
                new Producto { Id = 2, Name = "Xbox Series X", Description = "Consola Xbox Series X 1TB", Price = 1150000, Stock = 6, ImageUrl = StorageUrl("xbox.png"), TipoProductoId = 1, PlataformaId = 2, FormatoId = 1, Created_at = fechaSeed },
                new Producto { Id = 3, Name = "Nintendo Switch OLED", Description = "Consola Nintendo Switch OLED 64GB", Price = 780000, Stock = 10, ImageUrl = StorageUrl("switch.png"), TipoProductoId = 1, PlataformaId = 3, FormatoId = 1, Created_at = fechaSeed },
                new Producto { Id = 4, Name = "EA Sports FC 25", Description = "Juego de fútbol para PlayStation 5", Price = 95000, Stock = 25, ImageUrl = StorageUrl("fc25.png"), TipoProductoId = 2, PlataformaId = 1, FormatoId = 1, Created_at = fechaSeed },
                new Producto { Id = 5, Name = "Call of Duty: Black Ops 6", Description = "Shooter para Xbox Series X", Price = 105000, Stock = 20, ImageUrl = StorageUrl("cod.png"), TipoProductoId = 2, PlataformaId = 2, FormatoId = 1, Created_at = fechaSeed },
                new Producto { Id = 6, Name = "Zelda: Tears of the Kingdom", Description = "Aventura para Nintendo Switch", Price = 88000, Stock = 15, ImageUrl = StorageUrl("zelda.png"), TipoProductoId = 2, PlataformaId = 3, FormatoId = 1, Created_at = fechaSeed },
                new Producto { Id = 7, Name = "Minecraft Java Edition", Description = "Juego digital para PC", Price = 25000, Stock = 999, ImageUrl = StorageUrl("minecraft.png"), TipoProductoId = 2, PlataformaId = 4, FormatoId = 2, Created_at = fechaSeed },
                new Producto { Id = 8, Name = "PlayStation Plus Essential", Description = "Suscripción PlayStation Plus 3 meses", Price = 45000, Stock = 100, ImageUrl = StorageUrl("psplus.png"), TipoProductoId = 3, PlataformaId = 1, FormatoId = 2, Created_at = fechaSeed },
                new Producto { Id = 9, Name = "Xbox Game Pass Ultimate", Description = "Suscripción Game Pass Ultimate 1 mes", Price = 30000, Stock = 100, ImageUrl = StorageUrl("gamepass.png"), TipoProductoId = 3, PlataformaId = 2, FormatoId = 2, Created_at = fechaSeed },
                new Producto { Id = 10, Name = "Nintendo Switch Online", Description = "Suscripción Switch Online 12 meses", Price = 35000, Stock = 100, ImageUrl = StorageUrl("nso.png"), TipoProductoId = 3, PlataformaId = 3, FormatoId = 2, Created_at = fechaSeed }
            );

            // Seed Ventas de ejemplo (facturación local)
            modelBuilder.Entity<Venta>().HasData(
                new Venta { Id = 1, Number = "FAC-00001", Date = fechaSeed.AddDays(1), ClienteId = 1, Total = 1345000 },
                new Venta { Id = 2, Number = "FAC-00002", Date = fechaSeed.AddDays(2), ClienteId = 2, Total = 1255000 },
                new Venta { Id = 3, Number = "FAC-00003", Date = fechaSeed.AddDays(3), ClienteId = 3, Total = 913000 }
            );

            // Seed Detalles de venta
            modelBuilder.Entity<DetalleVenta>().HasData(
                new DetalleVenta { Id = 1, VentaId = 1, ProductoId = 1, Quantity = 1, UnitPrice = 1250000, Subtotal = 1250000 },
                new DetalleVenta { Id = 2, VentaId = 1, ProductoId = 4, Quantity = 1, UnitPrice = 95000, Subtotal = 95000 },
                new DetalleVenta { Id = 3, VentaId = 2, ProductoId = 2, Quantity = 1, UnitPrice = 1150000, Subtotal = 1150000 },
                new DetalleVenta { Id = 4, VentaId = 2, ProductoId = 5, Quantity = 1, UnitPrice = 105000, Subtotal = 105000 },
                new DetalleVenta { Id = 5, VentaId = 3, ProductoId = 3, Quantity = 1, UnitPrice = 780000, Subtotal = 780000 },
                new DetalleVenta { Id = 6, VentaId = 3, ProductoId = 6, Quantity = 1, UnitPrice = 88000, Subtotal = 88000 },
                new DetalleVenta { Id = 7, VentaId = 3, ProductoId = 8, Quantity = 1, UnitPrice = 45000, Subtotal = 45000 }
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
            modelBuilder.Entity<TipoProducto>().HasQueryFilter(t => !t.isDeleted);
            modelBuilder.Entity<Plataforma>().HasQueryFilter(p => !p.isDeleted);
            modelBuilder.Entity<Formato>().HasQueryFilter(f => !f.isDeleted);
            modelBuilder.Entity<Producto>().HasQueryFilter(p => !p.isDeleted);
            modelBuilder.Entity<Venta>().HasQueryFilter(v => !v.isDeleted);

            // restrict delete producto-tipo producto
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.TipoProducto)
                .WithMany()
                .HasForeignKey(p => p.TipoProductoId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Plataforma)
                .WithMany()
                .HasForeignKey(p => p.PlataformaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Formato)
                .WithMany()
                .HasForeignKey(p => p.FormatoId)
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
