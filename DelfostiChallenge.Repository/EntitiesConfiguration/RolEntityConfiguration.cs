using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DelfostiChallenge.Core.Entities;

namespace DelfostiChallenge.Repository.EntitiesConfiguration
{
    public class RolEntityConfiguration : IEntityTypeConfiguration<RolEntity>
    {
        public void Configure(EntityTypeBuilder<RolEntity> builder)
        {
            builder.ToTable(name: "Rol");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descripcion)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(100);

            builder.HasIndex(x => x.Descripcion).IsUnique();

            builder.HasMany(r => r.Usuarios)
                   .WithOne(u => u.Rol)
                   .HasForeignKey(u => u.IdRol)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
