using Dinner.Domain.MenuAggregate.ValueObjects;
using Dinner.Domain.MenuAggregate.Entities;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.MenuReview.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Common.ValueObjects;
using Dinner.Domain.MenuAggregate.Events;

namespace Dinner.Domain.MenuAggregate;


public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = new();

    private readonly List<DinnerId> _dinnerIds = new();
    
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set; }

    public string Description { get; private set; }

    public AverageRating AverageRating { get; private set; }
        
    public HostId HostId {get; private set;}

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime {get; private set;}
    
    public DateTime UpdatedDateTime {get; private set;}

    private Menu(
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        AverageRating averageRating,
        DateTime createdDateTime,
        DateTime updatedDateTime) 
        : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            AverageRating = averageRating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }


    public static Menu Create(string name,
        string description,
        HostId hostId,
        List<MenuSection> sections)
    {
        var menu = new Menu(MenuId.CreateUnique(),
            name,
            description,
            hostId,
            AverageRating.CreateNew(),
            DateTime.UtcNow,
            DateTime.UtcNow);

        menu._sections.AddRange(sections);

        menu.AddDomainEvent(new MenuCreated(menu));
        return menu;
    }

#pragma warning disable CS8618
    private Menu(){

    }
#pragma warning restore CS8618
}
