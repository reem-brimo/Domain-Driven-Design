using Dinner.Domain.Common.Models;

namespace Dinner.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerReservationId : ValueObject
{

    public string Value { get; set; }

    private DinnerReservationId(string value)
    {
        Value = value;}


    public static DinnerReservationId CreateValue(string value)
    {
        return new DinnerReservationId(value);
    }
    public static DinnerReservationId CreateUnique()
    {
        return new(Guid.NewGuid().ToString());
    }

    public override IEnumerable<object> GetEqualityComponents(){

        yield return Value;
    }

}
