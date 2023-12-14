
using Dinner.Domain.MenuAggregate.ValueObjects;
using Dinner.Domain.Common.Models;
namespace Dinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{

    private readonly List<MenuItem> _items = new();
    
    public string Name { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public DateTime CreatedDateTime {get; private set;}
    
    public DateTime UpdatedDateTime {get; private set;}

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        :base(menuSectionId)
    {
        Name = name;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }



    public static MenuSection Create(string name, string description, List<MenuItem> items)
    {
        var section = new MenuSection(
            MenuSectionId.CreateUnique(),
            name,
            description,
            DateTime.UtcNow,
            DateTime.UtcNow);
            
        section._items.AddRange(items);
        return section;
    }

#pragma warning disable CS8618
    private MenuSection(){

    }
#pragma warning restore CS8618

}