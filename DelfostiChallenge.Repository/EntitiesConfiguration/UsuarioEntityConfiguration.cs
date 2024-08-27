using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DelfostiChallenge.Core.Entities;

namespace DelfostiChallenge.Repository.EntitiesConfiguration
{
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable(name: "Usuario");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Codigo)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(20);

            builder.Property(x => x.Nombre)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(100);

            builder.Property(x => x.Correo)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(100);

            builder.Property(x => x.Password)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(200);

            builder.Property(x => x.Telefono)
                .IsUnicode(false)
                .HasMaxLength(9);

            builder.Property(x => x.Puesto)
                .IsUnicode(false)
                .HasMaxLength(50);


            builder.HasIndex(x => x.Codigo).IsUnique();
            builder.HasIndex(x => x.Correo).IsUnique();

            builder.HasOne(x => x.Rol)
                   .WithMany(r => r.Usuarios)
                   .HasForeignKey(x => x.IdRol)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
