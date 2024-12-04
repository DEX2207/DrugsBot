using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Конфигурация Country для базы данных
/// </summary>

public class CountryConfiguration:IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(nameof(Country));

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(2)
            .IsFixedLength();
        
        builder.HasMany(x => x.Drugs)
            .WithOne(d => d.Country)
            .HasForeignKey(d => d.CountryCodeID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}