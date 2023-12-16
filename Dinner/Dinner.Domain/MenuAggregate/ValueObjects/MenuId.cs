using Dinner.Domain.Common.Models;

namespace Dinner.Domain.MenuAggregate.ValueObjects;


public sealed class MenuId : AggregateRootId<Guid>
{

    public override Guid Value { get; protected set; }

    private MenuId(Guid value)
    {
        Value = value;
    }

    private MenuId()
    {
        
    }
    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }

    public override IEnumerable<object> GetEqualityComponents(){

        yield return Value;
    }

}
