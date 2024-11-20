using System.Net;
using System.Text.RegularExpressions;
using Domain.Validators;

namespace Domain.ValueObject;
/// <summary>
/// Адрес магазина
/// </summary>

public class Address:BaseValueObject
{
    /// <summary>
    /// Заполнение адреса из трех его составляющих
    /// </summary>
    /// <param name="city">Город</param>
    /// <param name="street">Улица</param>
    /// <param name="house">Дом</param>
    
    private static WebClient wc=new WebClient();
    private string countries = wc.DownloadString("https://supply-xml.booking.com/hotels/xml/countries");
    private Match Match;
    public Address(string country, string city,string street, string house, string postalCode)
    {
        Match = Regex.Match(countries, country , RegexOptions.Singleline);
        
        Country = Match.ToString();
        City = city;
        Street = street;
        House = house;
        PostalCode = postalCode;
        
        ValidateValueObject(new AddressValidator());
    }

    public string Country { get; private set; }

    /// <summary>
    /// Город
    /// </summary>
    public string City { get; private set; }
    /// <summary>
    /// Улица
    /// </summary>
    public string Street { get; private set; }
    /// <summary>
    /// Дом
    /// </summary>
    public string House { get; private set; }
    
    public string PostalCode { get; private set; }

    /// <summary>
    /// Возвращает строковое значение адреса
    /// </summary>
    /// <returns>Строка адреса</returns>
    public override string ToString()
    {
        return $"{Country},{City},{Street},{House},{PostalCode}";
    }
}