using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        builder.ToTable(nameof(DrugStore));
        
        builder.HasKey(ds => ds.Id);
        
        builder.Property(ds => ds.DrugNetwork)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ds => ds.Number)
            .IsRequired()
            .HasDefaultValue(0);

        builder.OwnsOne(ds => ds.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("char(2)"); 
            
            addressBuilder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            addressBuilder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            addressBuilder.Property(a => a.House)
                .IsRequired()
                .HasMaxLength(10);

            addressBuilder.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnType("char(6)");
        });
        
        builder.Property(ds => ds.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);
        
        builder.HasMany(ds => ds.DrugItems)
            .WithOne(di => di.DrugStore)
            .HasForeignKey(di => di.DrugStoreID)
            .OnDelete(DeleteBehavior.Cascade);
     
    }
}