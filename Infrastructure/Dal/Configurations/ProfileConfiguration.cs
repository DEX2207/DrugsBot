using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable(nameof(Profile));
        
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.ExternalId)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsOne(s => s.Email, email =>
        {
            email.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("email");
        });


        builder.HasMany(p => p.FavoriteDrugs)
            .WithOne(f => f.Profile)
            .HasForeignKey(f => f.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}