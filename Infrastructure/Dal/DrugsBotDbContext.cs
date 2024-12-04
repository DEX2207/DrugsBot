using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Dal.Configurations;

namespace Infrastructure.Dal;

public class DrugsBotDbContext:DbContext
{
    public DrugsBotDbContext(DbContextOptions<DrugsBotDbContext> options) : base(options)
    {
        
    }

    /// <summary>
    /// Таблица препаратов
    /// </summary>
    public DbSet<Drug> Drugs { get; set; }

    /// <summary>
    /// Таблица стран
    /// </summary>
    public DbSet<Country> Countries { get; set; }

    /// <summary>
    /// Таблица связей препаратов с аптеками
    /// </summary>
    public DbSet<DrugItem> DrugItems { get; set; }

    /// <summary>
    /// Таблица аптек
    /// </summary>
    public DbSet<DrugStore> DrugStores { get; set; }

    /// <summary>
    /// Таблица избранных препаратов
    /// </summary>
    public DbSet<FavoriteDrug> FavoriteDrugs { get; set; }

    /// <summary>
    /// Таблица профилей пользователей
    /// </summary>
    public DbSet<Profile> Profiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DrugConfiguration());
        modelBuilder.ApplyConfiguration(new DrugStoreConfiguration());
        modelBuilder.ApplyConfiguration(new DrugItemConfiguration());
        modelBuilder.ApplyConfiguration(new FavoriteDrugConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
    }
}