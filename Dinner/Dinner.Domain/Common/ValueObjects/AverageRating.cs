using Dinner.Domain.Common.Models;
using Dinner.Domain.Common.ValueObjects;
namespace Dinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{


private AverageRating(double value, int numRating)
{
    Value = value;
    NumRating = numRating;
}

public double Value { get; set; }

public int NumRating { get; set; }

public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
{
    return new AverageRating(rating, numRatings);
}

public void AddNewRating(Rating rating)
{

}
public void RemoveRating(Rating rating)
{

}

public override IEnumerable<object> GetEqualityComponents(){
    yield return Value;
}

#pragma warning disable CS8618
    private AverageRating(){

    }
#pragma warning restore CS8618
}