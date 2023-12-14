using Dinner.Domain.MenuReview.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Guest.ValueObjects;

namespace Dinner.Domain.Menu;


public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public GuestId GuestId { get; set; }

    public string Description { get; set; }

    public HostId HostId {get;}

    public DateTime CreatedDateTime {get;}
    
    public DateTime UpdatedDateTime {get;}

    private MenuReview(
        MenuReviewId menuReviewId,
        GuestId guestId,
        HostId hostId,
        string description,
        DateTime createdDateTime,
        DateTime updatedDateTime) 
        : base(menuReviewId)
        {
            GuestId = guestId;
            HostId = hostId;
            Description = description;            
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

    public static MenuReview Create(GuestId guestId, HostId hostId, string description)
    {
        return new(MenuReviewId.CreateUnique(),
        guestId,
        hostId,
        description,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }


}
