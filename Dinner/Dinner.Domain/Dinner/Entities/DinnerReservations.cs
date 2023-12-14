using Dinner.Domain.Common.Models;
using Dinner.Domain.Dinner.ValueObjects;
using Dinner.Domain.Guest.ValueObjects;
using Dinner.Domain.Bill.ValueObjects;


namespace Dinner.Domain.Dinner.Entities;


public sealed class DinnerReservation : Entity<DinnerReservationId>
{


    public int GuestsCount { get; set; }

    public GuestId GuestID { get; set; }

    public BillId BillId { get; set; }

    public DateTime ArraivalTime { get; }

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    private DinnerReservation(
     DinnerReservationId reservationId,
     int guestsCount,
     GuestId guestId,
     BillId billId,
     DateTime arraivalTime,
     DateTime createdDateTime,
     DateTime updatedDateTime
     )
        : base(reservationId)
    {
        GuestsCount = guestsCount;
        GuestID = guestId;
        BillId = billId;
        ArraivalTime = arraivalTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static DinnerReservation Create(int guestsCount,
     GuestId guestId,
     BillId billId,
     DateTime arraivalTime,
     DateTime createdDateTime,
     DateTime updatedDateTime)
    {
        return new(
            DinnerReservationId.CreateUnique(),
            guestsCount,
            guestId,
            billId,
            arraivalTime,
            createdDateTime,
            updatedDateTime);
    }
}
