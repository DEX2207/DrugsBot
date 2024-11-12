using Domain.Validators;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;
/// <summary>
/// Единица лекарства
/// </summary>
public class DrugItem:BaseEntities
{
    /// <summary>
    /// Конструктор для инициализации единицы лекарства
    /// </summary>
    /// <param name="drugId">Идентификатор лекарства</param>
    /// <param name="drugStoreId">Идентификатор магазина лекарств</param>
    /// <param name="count">Количество препарата</param>
    /// <param name="cost">Цена</param>
    public DrugItem(Guid drugId,Guid drugStoreId,int count,decimal cost)
    {
        DrugID = drugId;
        DrugStoreID = drugStoreId;
        Count = count;
        Cost = cost;
        
        Validate();
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
    public int Count { get; private set; }
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Cost { get; private set; }
    
    private void Validate()
    {
        var validator = new DrugItemValidator();
        var result = validator.Validate(this);
        if (!result.IsValid)
        {
            var errors = string.Join(" ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }

    //Навигационные свойства для связи с Drug и DrugStore
    public Drug Drug { get; private set; }
    public DrugStore DrugStore { get; private set; }
}