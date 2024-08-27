using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DelfostiChallenge.Core.Entities;

namespace DelfostiChallenge.Repository.EntitiesConfiguration
{
    public class PedidoDetalleEntityConfiguration : IEntityTypeConfiguration<PedidoDetalleEntity>
    {
        public void Configure(EntityTypeBuilder<PedidoDetalleEntity> builder)
        {
            builder.ToTable("PedidoDetalles");

            builder.HasKey(pd => pd.Id);

            builder.HasOne(pd => pd.Producto)
                .WithMany()
                .HasForeignKey(pd => pd.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(pd => pd.Cantidad)
                .IsRequired();
        }
    }
}
