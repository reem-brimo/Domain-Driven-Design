using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Guest.ValueObjects;

namespace Dinner.Domain.Guest.Entities;


public sealed class GuestRating :  Entity<GuestRatingId>
{

    public DinnerId DinnerId { get; set; }
        
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
            DinnerId = dinnerID;
            Rate = rate;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

    public static GuestRating Create(
        DinnerId DinnerId,
        int rate,
        HostId hostId)
    {
        return new(GuestRatingId.CreateUnique(),
        DinnerId,
        rate,
        hostId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private GuestRating(){

    }
#pragma warning restore CS8618

}
