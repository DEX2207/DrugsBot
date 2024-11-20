using FluentValidation;
using Domain.Entities;
using Domain.ValueObject;

namespace Domain.Validators;

/// <summary>
/// TODO: по правилам описать валидацию всех объектов
/// TODO: тест для валицации, тесты на xUNit
/// </summary>
public sealed class DrugValidator:AbstractValidator<Drug>
{
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Length(2, 150).WithMessage(ValidatianMessage.WrongLenght);
        RuleFor(d => d.CountryCodeID)
            .NotNull().WithMessage(ValidatianMessage.WrongCountyCode)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty);
        RuleFor(d => d.Manufacturer)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidatianMessage.WrongLenght)
            .Matches(@"^[A-Za-z]\\-\\s").WithMessage(ValidatianMessage.ManufacturFormat);
    }
}

public sealed class DrugItemValidator: AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        RuleFor(d => d.Cost)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .ScalePrecision(2,15).WithMessage("У числа больше 2 знаков после запятой")
            .GreaterThan(0).WithMessage(ValidatianMessage.PositiveNumber);
        RuleFor(d => d.Count)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .LessThanOrEqualTo(10000).WithMessage("Число не должно быть больше 10 000")
            .GreaterThanOrEqualTo(0).WithMessage(ValidatianMessage.PositiveNumber);
    }
}

public sealed class DrugStoreValidator : AbstractValidator<DrugStore>
{
    public DrugStoreValidator()
    {
        RuleFor(d => d.DrugNetwork)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidatianMessage.WrongLenght);
        RuleFor(d => d.Number)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .GreaterThan(0).WithMessage(ValidatianMessage.PositiveNumber);
        RuleFor(d => d.Address.Country)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty);
        RuleFor(d => d.Address.City)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Length(2, 50).WithMessage(ValidatianMessage.WrongLenght);
        RuleFor(d => d.Address.Street)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Length(3, 100).WithMessage(ValidatianMessage.WrongLenght);
        RuleFor(d => d.Address.PostalCode)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Matches(@"^\d{5,6}$").WithMessage("Поле должно быть числовым и иметь длину 5-6 символов");
    }
}

public sealed class CountryValidator : AbstractValidator<Country>
{
    public CountryValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidatianMessage.WrongLenght)
            .Matches(@"^[A-Za-z]+$").WithMessage("Поле должно содержать только буквы и пробелы");
        RuleFor(d => d.Code)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Matches("^[A-Z]{2}$").WithMessage("Полу должно содержать только 2 заглавных латинских символа");
    }
}

public sealed class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        RuleFor(d => d.ExternalId)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Length(2, 100).WithMessage(ValidatianMessage.WrongLenght);
    }
}

public sealed class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(d => d.Value)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Length(2, 255).WithMessage(ValidatianMessage.WrongLenght)
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            .WithMessage("{PropertyName} не является электронной почтой.");
    }
}

public sealed class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(d => d.City)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Length(2, 50).WithMessage(ValidatianMessage.WrongLenght)
            .Matches(@"^[A-Za-z\s\-]+$").WithMessage(ValidatianMessage.OnlyLettersSpacesAndDashes);
        RuleFor(d => d.Country)
            .NotNull().WithMessage(ValidatianMessage.NotNull)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty);
        RuleFor(d=>d.Street)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Length(3,100).WithMessage(ValidatianMessage.WrongLenght)
            .Matches(@"^[A-Za-z0-9\s\-]+$").WithMessage(ValidatianMessage.OnlyLettersDigitsSpacesAndDashes);
        RuleFor(a => a.House)
            .NotEmpty().WithMessage(ValidatianMessage.NotEmpty)
            .Length(1, 10).WithMessage(ValidatianMessage.WrongLenght)
            .Matches(@"^[A-Za-z0-9\-]+$").WithMessage(ValidatianMessage.OnlyLettersDigitsAndDashes);
    }
}