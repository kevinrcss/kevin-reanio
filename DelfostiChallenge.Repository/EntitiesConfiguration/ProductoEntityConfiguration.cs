using DelfostiChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static DelfostiChallenge.Common.Enums;

namespace DelfostiChallenge.Repository.EntitiesConfiguration
{
    public class ProductoEntityConfiguration : IEntityTypeConfiguration<ProductoEntity>
    {
        public void Configure(EntityTypeBuilder<ProductoEntity> builder)
        {
            builder.ToTable(name: "Producto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Sku)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(50);

            builder.Property(x => x.Nombre)
                .IsRequired()
                .IsUnicode(false)
            .HasMaxLength(100);

            builder.Property(x => x.Precio)
                .IsRequired()
                .HasPrecision(9, 2);

            builder.Property(x => x.Etiquetas)
                .HasConversion(
                    v => string.Join(",", v.Select(e => (int)e)),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                          .Select(e => (EtiquetaProducto)int.Parse(e))
                          .ToList()
                );

            builder.Property(x => x.Tipo)
                .HasConversion<int>();

            builder.Property(x => x.UnidadMedida)
                .HasConversion<int>();
        }
    }
}
