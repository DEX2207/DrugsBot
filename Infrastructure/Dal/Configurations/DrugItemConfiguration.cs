using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class DrugItemConfiguration : IEntityTypeConfiguration<DrugItem>
{
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        builder.ToTable(nameof(DrugItem));

        builder.HasKey(di => di.Id);

        builder.Property(di => di.Cost)
            .IsRequired()
            .HasColumnType("decimal(18,2)")
            .HasDefaultValue(0);

        builder.Property(di => di.Count)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(di => di.DrugID)
            .IsRequired();

        builder.Property(di => di.DrugStoreID)
            .IsRequired();

        builder.HasOne(di => di.DrugStore)
            .WithMany(ds => ds.DrugItems)
            .HasForeignKey(di => di.DrugStore)
            .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(di => di.Drug)
            .WithMany()
            .HasForeignKey(di => di.DrugStore)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}