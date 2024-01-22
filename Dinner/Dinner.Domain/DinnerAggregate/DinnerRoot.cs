using Dinner.Domain.MenuAggregate.ValueObjects;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.DinnerAggregate.Entities;
using Dinner.Domain.DinnerAggregate.Enums;
using Dinner.Domain.Common.Models;

namespace Dinner.Domain.DinnerAggregate;


public sealed class DinnerRoot : AggregateRoot<DinnerId, string>
{
    private readonly List<DinnerReservation> _Reservations = new();
    public string Name { get; set; }

    public string Description { get; set; }
    public DateTime StartDate {get;}
    
    public DateTime EndDate {get;}

    public DinnerStatus DinnerStatus {get;}
    public bool IsPublic { get;}
    
    public int MaxGuests {get;}

    public Price Price {get;}
    public HostId HostId {get;}
    public MenuId MenuId {get;}
    public string ImageUrl {get;}

    public Location Location {get;}

    public IReadOnlyList<DinnerReservation> Reservations => _Reservations.AsReadOnly();

    public DateTime CreatedDateTime {get;}
    
    public DateTime UpdatedDateTime {get;}

    private DinnerRoot(
        DinnerId dinnerId,
        MenuId menuId,
        string name,
        string description,
        HostId hostId,
        DateTime startDate,
        DateTime endDate,
        DinnerStatus dinnerStatus,
        bool isPublic,
        int maxGuests,
        Price price,
        string imageUrl,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime) 
        : base(dinnerId)
        {
            MenuId = menuId;
            Name = name;
            Description = description;
            HostId = hostId;
            StartDate = startDate;
            EndDate = endDate;
            DinnerStatus = dinnerStatus;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            ImageUrl = imageUrl;
            Location = location;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

    public static DinnerRoot Create(string name,
        MenuId menuId,
        string description,
        HostId hostId,
        DateTime startDate,
        DateTime endDate,
        DinnerStatus dinnerStatus,
        bool isPublic,
        int maxGuests,
        Price price,
        string imageUrl,
        Location location
        )
    {
        return new(DinnerId.CreateUnique(),
        menuId,
        name,
        description,
        hostId,
        startDate,
        endDate,
        dinnerStatus,
        isPublic,
        maxGuests,
        price,
        imageUrl,
        location,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private DinnerRoot()
    {

    }
#pragma warning restore CS8618

}
