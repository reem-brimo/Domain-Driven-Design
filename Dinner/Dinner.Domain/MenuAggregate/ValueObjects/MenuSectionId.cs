using Dinner.Domain.Common.Models;

namespace Dinner.Domain.MenuAggregate.ValueObjects;


public sealed class MenuSectionId : ValueObject
{

    public Guid Value { get; set; }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }
    
    private MenuSectionId()
    {
    }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

        public static MenuSectionId Create(Guid value)
    {
        return new MenuSectionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}
