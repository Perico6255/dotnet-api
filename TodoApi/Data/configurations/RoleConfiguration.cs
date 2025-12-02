
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Models;

namespace TodoApi.Data.Configurations;

public class RoleConfiguration: IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");       

        builder.HasKey(t => t.Id);


        builder.Property(t => t.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.HasMany(u => u.Permisos)
                .WithMany()                 
                .UsingEntity(j => j.ToTable("RolePermisos"));
    }
}
