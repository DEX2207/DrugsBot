namespace Domain.Validators;

public class ValidatianMessage
{
    public const string NotNull = "{PropertyName} не может быть null";
    public const string NotEmpty = "{PropertyName} не может быть пустым";
    public const string WrongLenght = "{PropertyName} должен быть от {min} до {max} символов";
    public const string WrongCountyCode = "{PropertyName} является некорректным кодом страны";
    public const string ManufacturFormat = "{PropertyName} имеет неверный формат. Поле должно содержать только буквы, дефисы и пробелы";
    public const string PositiveNumber = "Число должно быть положительным";
    // TODO: проверить конструкцию на работоспособность
}