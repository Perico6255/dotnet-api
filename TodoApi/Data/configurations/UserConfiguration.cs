using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Models;

namespace TodoApi.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");          // nombre tabla (opcional)

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Password)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.Nombre)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.Apellido1)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.Apellido2)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

        builder.HasMany(u => u.Roles)
                .WithMany()                 
                .UsingEntity(j => j.ToTable("UserRoles"));
    }
}
