using System.Reflection;
using static DelfostiChallenge.Common.Enums;
using Microsoft.EntityFrameworkCore;
using DelfostiChallenge.Core.Entities;

namespace DelfostiChallenge.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<PedidoEntity> Pedidos { get; set; }
        public DbSet<PedidoDetalleEntity> PedidoDetalles { get; set; }
        public DbSet<ProductoEntity> Productos { get; set; }
        public DbSet<RolEntity> Roles { get; set; }
        public DbSet<SecuenciaEntity> Secuencias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region Data Seeding
            SeedData(modelBuilder);
            #endregion

        }

        #region Private Methods
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolEntity>().HasData(
                new RolEntity { Id = 1, Descripcion = "Encargado" },
                new RolEntity { Id = 2, Descripcion = "Vendedor" },
                new RolEntity { Id = 3, Descripcion = "Delivery" },
                new RolEntity { Id = 4, Descripcion = "Repartidor" }
            );

            modelBuilder.Entity<UsuarioEntity>().HasData(
                new UsuarioEntity
                {
                    Id = 1,
                    Codigo = "KEVINRC",
                    Nombre = "Kevin Wilson Reaño Cisneros",
                    Correo = "kevin.rc@hotmail.com",
                    Password = "BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413",
                    Puesto = "Ventas",
                    Telefono = "941573117",
                    IdRol = 1
                },
                new UsuarioEntity
                {
                    Id = 2,
                    Codigo = "CUEVA10",
                    Nombre = "Christian Cueva",
                    Correo = "repartidor@gmail.com",
                    Password = "BA3253876AED6BC22D4A6FF53D8406C6AD864195ED144AB5C87621B6C233B548BAEAE6956DF346EC8C17F5EA10F35EE3CBC514797ED7DDD3145464E2A0BAB413",
                    Puesto = "Repartidor",
                    Telefono = "987654321",
                    IdRol = 4 // Rol de Repartidor
                }
            );

            modelBuilder.Entity<ProductoEntity>().HasData(
                new ProductoEntity
                {
                    Id = 1,
                    Sku = "LAP001",
                    Nombre = "Laptop Pro X1",
                    Tipo = TipoProducto.Laptops,
                    Etiquetas = new List<EtiquetaProducto> { EtiquetaProducto.Gaming, EtiquetaProducto.Profesional },
                    Precio = 1299.99m,
                    UnidadMedida = UnidadMedidaProducto.Unidad
                },
                new ProductoEntity
                {
                    Id = 2,
                    Sku = "MON002",
                    Nombre = "Monitor UltraWide 34\"",
                    Tipo = TipoProducto.Monitores,
                    Etiquetas = new List<EtiquetaProducto> { EtiquetaProducto.Profesional, EtiquetaProducto.Oficina },
                    Precio = 499.99m,
                    UnidadMedida = UnidadMedidaProducto.Unidad
                },
                new ProductoEntity
                {
                    Id = 3,
                    Sku = "TEC003",
                    Nombre = "Teclado Mecánico RGB",
                    Tipo = TipoProducto.Teclados,
                    Etiquetas = new List<EtiquetaProducto> { EtiquetaProducto.Gaming, EtiquetaProducto.Tendencia },
                    Precio = 129.99m,
                    UnidadMedida = UnidadMedidaProducto.Unidad
                },
                new ProductoEntity
                {
                    Id = 4,
                    Sku = "SMA004",
                    Nombre = "Smartphone 5G",
                    Tipo = TipoProducto.Smartphones,
                    Etiquetas = new List<EtiquetaProducto> { EtiquetaProducto.Tendencia, EtiquetaProducto.Profesional },
                    Precio = 799.99m,
                    UnidadMedida = UnidadMedidaProducto.Unidad
                },
                new ProductoEntity
                {
                    Id = 5,
                    Sku = "LAP005",
                    Nombre = "Laptop Económica",
                    Tipo = TipoProducto.Laptops,
                    Etiquetas = new List<EtiquetaProducto> { EtiquetaProducto.Economico, EtiquetaProducto.Hogar },
                    Precio = 449.99m,
                    UnidadMedida = UnidadMedidaProducto.Unidad
                },
                new ProductoEntity
                {
                    Id = 6,
                    Sku = "TEC006",
                    Nombre = "Pack Teclado y Mouse Inalámbricos",
                    Tipo = TipoProducto.Teclados,
                    Etiquetas = new List<EtiquetaProducto> { EtiquetaProducto.Oficina, EtiquetaProducto.Economico },
                    Precio = 39.99m,
                    UnidadMedida = UnidadMedidaProducto.Pack
                }
            );
        }
        #endregion
    }
}
