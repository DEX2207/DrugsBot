using Domain.Validators;
using System.ComponentModel.DataAnnotations;
using Domain.DomainEvents;

namespace Domain.Entities;
/// <summary>
/// Единица лекарства
/// </summary>
public class DrugItem:BaseEntities<DrugItem>
{
    /// <summary>
    /// Конструктор для инициализации единицы лекарства
    /// </summary>
    /// <param name="drugId">Идентификатор лекарства</param>
    /// <param name="drugStoreId">Идентификатор магазина лекарств</param>
    /// <param name="count">Количество препарата</param>
    /// <param name="cost">Цена</param>
    public DrugItem(Guid drugId,Guid drugStoreId,double count,decimal cost,Drug drug, DrugStore drugStore)
    {
        DrugID = drugId;
        DrugStoreID = drugStoreId;
        Count = count;
        Cost = cost;
        Drug = drug;
        DrugStore = drugStore;
        
        ValidateEntity(new DrugItemValidator());
    }
    
    /// <summary>
    /// ID лекарства
    /// </summary>
    public Guid DrugID { get; private set; }
    /// <summary>
    /// ID магазина
    /// </summary>
    public Guid DrugStoreID { get; private set; }
    /// <summary>
    /// Количество препарата на складе
    /// </summary>
    public double Count { get; private set; }
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Cost { get; private set; }

    //Навигационные свойства для связи с Drug и DrugStore
    public Drug Drug { get; private set; }
    public DrugStore DrugStore { get; private set; }

    public void UpdateDrugCount(double count)
    {
        Count = count;
        
        ValidateEntity(new DrugItemValidator());
        
        AddDomainEvent(new DrugItemUpdatedEvent());
    }

    public void Update(Guid drugId, Guid drugStoreId, double count, decimal cost, Drug drug, DrugStore drugStore)
    {
        DrugID = drugId;
        DrugStoreID = drugStoreId;
        Count = count;
        Drug = drug;
        DrugStore = drugStore;
        
        UpdateDrugCount(count);
    }
}