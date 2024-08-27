using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DelfostiChallenge.Core.Entities;

namespace DelfostiChallenge.Repository.EntitiesConfiguration
{
    public class PedidoEntityConfiguration : IEntityTypeConfiguration<PedidoEntity>
    {
        public void Configure(EntityTypeBuilder<PedidoEntity> builder)
        {
            builder.ToTable(name: "Pedido");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NumeroPedido)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.FechaPedido)
                .IsRequired();

            builder.Property(x => x.Estado)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(p => p.Vendedor)
                .WithMany()
                .HasForeignKey(p => p.VendedorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Repartidor)
                .WithMany()
                .HasForeignKey(p => p.RepartidorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PedidoDetalles)
                .WithOne()
                .HasForeignKey("PedidoId")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
