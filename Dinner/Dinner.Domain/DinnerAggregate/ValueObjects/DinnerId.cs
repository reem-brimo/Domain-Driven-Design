using Dinner.Domain.Common.Models;

namespace Dinner.Domain.DinnerAggregate.ValueObjects;


public sealed class DinnerId : AggregateRootId<string>
{

    public override string Value { get; protected set; }

    private DinnerId(string value)
    {
        Value = value;}

    public static DinnerId CreateValue(string value)
    {
        return new DinnerId(value);
    }
    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid().ToString());
    }

    public override IEnumerable<object> GetEqualityComponents(){

        yield return Value;
    }

}
