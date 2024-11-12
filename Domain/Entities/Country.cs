using Domain.Validators;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;
/// <summary>
/// Страна производитель
/// </summary>

public class Country:BaseEntities
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
        
        Validate();
    }
    
    /// <summary>
    /// Название страны
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Код страны
    /// </summary>
    public string Code { get; private set; }

    //Навигационное свойство для связи с препаратами
    public ICollection<Drug> Drugs { get; private set; } = new List<Drug>();
    
    private void Validate()
    {
        var validator = new CountryValidator();
        var result = validator.Validate(this);
        if (!result.IsValid)
        {
            var errors = string.Join(" ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}