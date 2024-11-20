using Domain.ValueObject;
using Domain.Validators;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;
/// <summary>
/// Магазин лекарств
/// </summary>
public class DrugStore:BaseEntities<DrugStore>
{
    /// <summary>
    /// Конструктор для инициализации магазина лекарств
    /// </summary>
    /// <param name="drugNetwork">Сеть лекарств</param>
    /// <param name="number">Номер магазина</param>
    /// <param name="address">Адрес магазина</param>
    /// <param name="phoneNumber">Номер телефона магазина</param>
    public DrugStore(string drugNetwork,int number,Address address,string phoneNumber)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;
        PhoneNumber = phoneNumber;
        
        ValidateEntity(new DrugStoreValidator());
    }
    
    /// <summary>
    /// Сеть лекарств
    /// </summary>
    public string DrugNetwork { get; private set; }
    /// <summary>
    /// Номер магазина
    /// </summary>
    public int Number { get; private set; }
    /// <summary>
    /// Адрес магазина
    /// </summary>
    public Address Address { get; private set; }
    /// <summary>
    /// Телефонный номер
    /// </summary>
    public string PhoneNumber { get; private set; }
    
    //Навигационное свойство для связи с DrugItem
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
}