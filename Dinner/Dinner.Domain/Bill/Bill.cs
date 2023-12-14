using Dinner.Domain.Bill.ValueObjects;
using Dinner.Domain.Dinner.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Guest.ValueObjects;

namespace Dinner.Domain.Bill;


public sealed class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId {get;}

    public HostId HostId {get;}

    public GuestId GuestId {get;}

    public DateTime CreatedDateTime {get;}
    
    public DateTime UpdatedDateTime {get;}

    private Bill(
        BillId billId,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime) 
        : base(billId)
        {
        
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

    public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId)
    {
        return new(BillId.CreateUnique(),
        dinnerId,
        guestId,
        hostId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }


}
