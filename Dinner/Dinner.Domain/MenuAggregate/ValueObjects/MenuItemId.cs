using Dinner.Domain.Common.Models;

namespace Dinner.Domain.MenuAggregate.ValueObjects;


public sealed class MenuItemId : ValueObject
{

    public Guid Value { get; set; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }
    private MenuItemId()
    {
    }
    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        return new MenuItemId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
