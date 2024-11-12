using System.Reflection;

namespace Domain.ValueObject;
/// <summary>
/// Базоывый класс, обеспечивающий сравнение и вычисление хеш-кода на основе всех полей и свойств
/// </summary>
public abstract class BaseValueObject:IEquatable<BaseValueObject>
{
    /// <summary>
    /// Определяет, равен ли текущий объект значению другого объекта.
    /// </summary>
    /// <param name="other">Другой объект для сравнения</param>
    /// <returns>true if this==other,else false</returns>
    public bool Equals(BaseValueObject? other)
    {
        if (other == null || other.GetType() !=GetType())
        {
            return false;
        }

        //Сравнение свойств
        foreach (var property in GetProperties())
        {
            var value1 = property.GetValue(this);
            var value2 = property.GetValue(other);
            if (!Equals(value1, value2))
            {
                return false;
            }
        }
        
        //Сравнение полей
        foreach (var field in GetFields())
        {
            var value1 = field.GetValue(this);
            var value2 = field.GetValue(other);
            if (!Equals(value1, value2))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Переопределение метода Equals для сравнения объекта
    /// </summary>
    /// <param name="obj">Объект для сравнения</param>
    /// <returns>True, если равны, иначе false</returns>
    public override bool Equals(object? obj)
    {
        return Equals(obj as BaseValueObject);
    }

    /// <summary>
    /// Переопределение метода GetHashCode для вычисления хеш-кода на основе всех полей и свойств
    /// </summary>
    /// <returns>Хеш-код объекта</returns>
    
    //TODO:Объяснить почему GetHashCode такой
    public override int GetHashCode()
    {
        int hash = 17;
        foreach (var property in GetProperties())
        {
            var value = property.GetValue(this);
            hash = hash * 31 + (value?.GetHashCode() ?? 0);
        }
        return hash;
    }

    /// <summary>
    /// Получает список всех доступных свойств для сравнения
    /// </summary>
    /// <returns>Коллекция свойств объекта</returns>
    private IEnumerable<PropertyInfo> GetProperties()
    {
        return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => !p.GetGetMethod()!.IsVirtual);
    }
    
    /// <summary>
    /// Получает список всех доступных полей для сравнения
    /// </summary>
    /// <returns>Коллекция полей объекта</returns>
    public IEnumerable<FieldInfo> GetFields()
    {
        return GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
    }
    
    /// <summary>
    /// Оператор для сравнения объектов на равенство значений
    /// </summary>
    /// <param name="left">Левая сущность</param>
    /// <param name="right">Правая сущность</param>
    /// <returns>True if left==right,else false</returns>
    public static bool operator ==(BaseValueObject? left, BaseValueObject? right)
    {
        return left?.Equals(right) ?? ReferenceEquals(right, null);
    }
    
    /// <summary>
    /// Оператор для сравнения объектов на неравенство значений
    /// </summary>
    /// <param name="left">Левая сущность</param>
    /// <param name="right">Правая сущность</param>
    /// <returns>True if left !=right,else false</returns>
    public static bool operator !=(BaseValueObject? left, BaseValueObject? right)
    {
        return !(left == right);
    }
}