using Dinner.Domain.Common.Models;

namespace Dinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    private Rating(double value, int numRating)
    {
        Value = value;
        NumRating = numRating;
    }

    public double Value { get; set; }

    public int NumRating { get; set; }

    public override IEnumerable<object> GetEqualityComponents(){
        yield return Value;
    }
}

