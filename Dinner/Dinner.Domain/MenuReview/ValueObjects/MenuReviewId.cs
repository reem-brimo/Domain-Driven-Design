using Dinner.Domain.Common.Models;

namespace Dinner.Domain.MenuReview.ValueObjects;


public sealed class MenuReviewId : ValueObject
{

    public Guid Value { get; set; }

    private MenuReviewId(Guid value)
    {
        Value = value;}

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents(){

        yield return Value;
    }

}
