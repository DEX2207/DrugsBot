using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class FavoriteDrugConfiguration: IEntityTypeConfiguration<FavoriteDrug>
{
    public void Configure(EntityTypeBuilder<FavoriteDrug> builder)
    {
        builder.ToTable(nameof(FavoriteDrug));

        builder.HasKey(x => new { x.DrugId, x.ProfileId });
        
        builder.Property(f => f.ProfileId)
            .IsRequired();

        builder.Property(f => f.DrugId)
            .IsRequired();
        
        builder.Property(f => f.DrugStoreId)
            .IsRequired(false);
    }
}