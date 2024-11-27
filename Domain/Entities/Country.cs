using Domain.Validators;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;
/// <summary>
/// Страна производитель
/// </summary>

public class Country:BaseEntities<Country>
{
    /// <summary>
    /// Инициализация страны с ее названием и кодом
    /// </summary>
    /// <param name="name">Название страны</param>
    /// <param name="code">Код страны</param>
    public Country(string name,string code)
    {
        Name = name;
        Code = code;
        
        ValidateEntity(new CountryValidator());
    }
    
    /// <summary>
    /// Название страны
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Код страны
    /// </summary>
    public string Code { get; private set; }
    
    public void Update(string name, string code)
    {
        Name = name;
        Code = code;
        
        ValidateEntity(new CountryValidator());
    }
    
    //Навигационное свойство для связи с препаратами
    public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();
}