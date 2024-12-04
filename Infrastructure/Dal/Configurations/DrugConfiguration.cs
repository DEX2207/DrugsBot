using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация Drug для базы данных
/// </summary>
public class DrugConfiguration:IEntityTypeConfiguration<Drug>
{
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        builder.ToTable(nameof(Drug));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.CountryCodeID)
            .IsRequired();
        builder.HasMany(x => x.DrugItems)
            .WithOne(d => d.Drug)
            .HasForeignKey(d => d.DrugID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}