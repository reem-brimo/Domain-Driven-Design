using Dinner.Domain.Common.Models;


namespace Dinner.Domain.User.ValueObjects;


public sealed class UserId : AggregateRootId<Guid>
{

    public override Guid Value { get; protected set; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static UserId CreateValue(Guid value)
    {
        return new UserId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
