using Dinner.Domain.Common.Models;

namespace Dinner.Domain.Guest.ValueObjects;

public sealed class GuestRatingId : ValueObject
{

    public Guid Value { get; set; }

    private GuestRatingId(Guid value)
    {
        Value = value;
    }

    public static GuestRatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
