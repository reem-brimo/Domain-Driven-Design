using Dinner.Domain.Dinner.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Guest.ValueObjects;

namespace Dinner.Domain.Guest.Entities;


public sealed class GuestRating : AggregateRoot<GuestRatingId>
{

    public DinnerId DinnerID { get; set; }
        
    public HostId HostId {get;}

    public int Rate {get;}

    public DateTime CreatedDateTime {get;}
    
    public DateTime UpdatedDateTime {get;}

    private GuestRating(
        GuestRatingId guestRatingId,
        DinnerId dinnerID,
        int rate,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime) 
        : base(guestRatingId)
        {
            DinnerID = dinnerID;
            Rate = rate;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

    public static GuestRating Create(
        DinnerId dinnerID,
        int rate,
        HostId hostId)
    {
        return new(GuestRatingId.CreateUnique(),
        dinnerID,
        rate,
        hostId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }


}
