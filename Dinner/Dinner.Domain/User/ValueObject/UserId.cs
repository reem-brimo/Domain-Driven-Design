using Dinner.Domain.Common.Models;


namespace Dinner.Domain.User.ValueObjects;


public sealed class UserId : ValueObject
{

    public Guid Value { get; set; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
