using Domain.Interface;
using FluentValidation;

namespace Domain.Entities;
/// <summary>
/// Основные сущности
/// </summary>
public abstract class BaseEntities<T> where T:BaseEntities<T>
{
    private readonly List<IDomainEvent> _domainEvents=[];
    
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Guid Id { get; protected init; }

    /// <summary>
    /// Конструктор, инициализирующий Id
    /// </summary>
    protected BaseEntities()
    {
        Id = Guid.NewGuid();
    }
    
    protected void ValidateEntity(AbstractValidator<T> validator)
    {
        var validationResult = validator.Validate((T)this);
        if (validationResult.IsValid)
        {
            return;
        }

        var errorMessages = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
        throw new ValidationException(errorMessages);
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.AsReadOnly();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    /// <summary>
    /// Переопределение метода Equals для сравнения сущностей по Id
    /// </summary>
    /// <param name="obj">Объект сравнения</param>
    /// <returns>True,если Id совпадает, иначе False</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this,obj))
        {
            return true;
        }

        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }
        return Id.Equals(((BaseEntities<T>)obj).Id);
    }
    /// <summary>
    /// Переопределение GetHashCode, возвращающего хеш-код Id
    /// </summary>
    /// <returns>хеш код Id</returns>
    public override int GetHashCode()=>Id.GetHashCode();

    /// <summary>
    /// Сравнение на равенство Id
    /// </summary>
    /// <param name="left">Левая сущность</param>
    /// <param name="right">Правая сущность</param>
    /// <returns>True if left==right,else false</returns>
    public static bool operator==(BaseEntities<T>? left,BaseEntities<T>? right)
    {
        if (left is null)
        {
            return right is null;
        }

        return left.Equals(right);
    }
    
    /// <summary>
    /// Сравнение на неравенство
    /// </summary>
    /// <param name="left">Левая сущность</param>
    /// <param name="right">Правая сущность</param>
    /// <returns>True if left!=right,else false</returns>
    public static bool operator !=(BaseEntities<T>? left, BaseEntities<T>? right)
    {
        return !(left == right);
    }
}