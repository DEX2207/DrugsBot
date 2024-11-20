using Domain.Validators;

namespace Domain.ValueObject;

public sealed class Email:BaseValueObject
{
    public Email(string value)
    {
        Value = value;
        
        ValidateValueObject(new EmailValidator());
    }
    public string Value { get; }

    public override string ToString()
    {
        return Value;
    }
}