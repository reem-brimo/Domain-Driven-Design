using Dinner.Domain.Common.Models;

namespace Dinner.Domain.Host.ValueObjects;


public sealed class HostId : AggregateRootId<string>
{

    public override string Value { get; protected set; }

    private HostId(string value)
    {
        Value = value;}

    public static HostId CreateValue(string value)
    {
        return new HostId(value);
    }

    public static HostId CreateUniqueValue(){
        return new(Guid.NewGuid().ToString());
    }
    public override IEnumerable<object> GetEqualityComponents(){

        yield return Value;
    }

#pragma warning disable CS8618
    private HostId(){

    }
#pragma warning restore CS8618
}
