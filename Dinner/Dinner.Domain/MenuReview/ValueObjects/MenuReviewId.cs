using Dinner.Domain.Common.Models;

namespace Dinner.Domain.MenuReview.ValueObjects;


public sealed class MenuReviewId : AggregateRootId<Guid>
{

    public override Guid Value { get; protected set; }

    private MenuReviewId(Guid value)
    {
        Value = value;}

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

        public static MenuReviewId CreateValue(Guid value)
    {
        return new MenuReviewId(value);
    }
    public override IEnumerable<object> GetEqualityComponents(){

        yield return Value;
    }

}
