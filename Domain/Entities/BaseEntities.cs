namespace Domain.Entities;
/// <summary>
/// Основные сущности
/// </summary>
public abstract class BaseEntities
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Конструктор, инициализирующий Id
    /// </summary>
    public BaseEntities()
    {
        Id = Guid.NewGuid();
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

        var other = (BaseEntities)obj;
        return Id.Equals(other.Id);
    }
    /// <summary>
    /// Переопределение GetHashCode, возвращающего хеш-код Id
    /// </summary>
    /// <returns>хеш код Id</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// Сравнение на равенство Id
    /// </summary>
    /// <param name="left">Левая сущность</param>
    /// <param name="right">Правая сущность</param>
    /// <returns>True if left==right,else false</returns>
    public static bool operator==(BaseEntities? left,BaseEntities? right)
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
    public static bool operator !=(BaseEntities? left, BaseEntities? right)
    {
        return !(left == right);
    }
}