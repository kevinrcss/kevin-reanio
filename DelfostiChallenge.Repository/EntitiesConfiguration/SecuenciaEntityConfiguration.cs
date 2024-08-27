using DelfostiChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DelfostiChallenge.Repository.EntitiesConfiguration
{
    public class SecuenciaEntityConfiguration : IEntityTypeConfiguration<SecuenciaEntity>
    {
        public void Configure(EntityTypeBuilder<SecuenciaEntity> builder)
        {
            builder.ToTable("Secuencias");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.UltimoValor)
                .IsRequired();

            builder.HasIndex(s => s.Nombre).IsUnique();
        }
    }
}
