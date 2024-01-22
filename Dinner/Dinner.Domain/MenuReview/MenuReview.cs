using Dinner.Domain.MenuReview.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Guest.ValueObjects;

namespace Dinner.Domain.MenuReview;


public sealed class MenuReview : AggregateRoot<MenuReviewId,Guid>
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

#pragma warning disable CS8618
    private MenuReview()
    {

    } 
#pragma warning restore CS8618


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
