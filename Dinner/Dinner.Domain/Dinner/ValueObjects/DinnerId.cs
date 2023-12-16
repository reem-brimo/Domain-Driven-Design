using Dinner.Domain.Common.Models;

namespace Dinner.Domain.Dinner.ValueObjects;


public sealed class DinnerId : AggregateRootId<Guid>
{

    public override Guid Value { get; protected set; }

    private DinnerId(Guid value)
    {
        Value = value;}

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents(){

        yield return Value;
    }

}
