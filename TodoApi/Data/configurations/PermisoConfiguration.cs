
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Models;

namespace TodoApi.Data.Configurations;

public class PermisoConfiguration: IEntityTypeConfiguration<Permiso>
{
    public void Configure(EntityTypeBuilder<Permiso> builder)
    {
        builder.ToTable("Permisos");       

        builder.HasKey(t => t.Id);


        builder.Property(t => t.Name)
               .IsRequired()
               .HasMaxLength(200);
    }
}
