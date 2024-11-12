using System.ComponentModel.DataAnnotations;
using Domain.Validators;
using System.Net;
using System.Text.RegularExpressions;

namespace Domain.Entities;
/// <summary>
/// Лекарственные средства
/// </summary>

public class Drug:BaseEntities
{
    /// <summary>
    /// Конструктор для инициализации прапарата
    /// </summary>
    /// <param name="name">Название препарата</param>
    /// <param name="manufacturer">Страна-Производитель</param>
    /// <param name="countryCodeId">Id кода страны</param>
    
    private static WebClient wc=new WebClient();
    private string countries = wc.DownloadString("https://supply-xml.booking.com/hotels/xml/countries");
    private Match Match;
    public Drug(string name,string manufacturer,string countryCodeId,Country country)
    {
        Match = Regex.Match(countries, countryCodeId , RegexOptions.Singleline);
        
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeID = Match.ToString();
        Country = country;
        
        Validate();
    }
    
    /// <summary>
    /// Имя припарата 
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Страна-производитель
    /// </summary>
    public string Manufacturer { get; private set; }
    /// <summary>
    /// Идентификатор кода страны
    /// </summary>
    public string CountryCodeID { get; private set; }

    //Навигационное свойство для связи с Country
    public Country Country { get; private set; }
    

    //Навигационное свойство для связи с DrugItem
    public ICollection<DrugItem> DrugItems { get; private set; } = new List<DrugItem>();
    
    private void Validate()
    {
        var validator = new DrugValidator();
        var result = validator.Validate(this);
        if (!result.IsValid)
        {
            var errors = string.Join(" ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}