using Dinner.Domain.DinnerAggregate.ValueObjects;
using Dinner.Domain.MenuReview.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.Guest.ValueObjects;
using Dinner.Domain.Bill.ValueObjects;
using Dinner.Domain.User.ValueObjects;
using Dinner.Domain.Guest.Entities;

namespace Dinner.Domain.Guest;
public sealed class Guest : AggregateRoot<GuestId, Guid>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();

    private readonly List<DinnerId> _pastDinnerIds = new();
    
    private readonly List<DinnerId> _pendingDinnerIds = new();
       
    private readonly List<BillId> _billIds = new();

    private readonly List<MenuReviewId> _menuReviewIds = new();

    private readonly List<GuestRating> _ratings = new();


    public string FirstName { get; set; }

    public string LastName { get; set; }

        
    public UserId UserId {get;}
    
    public DateTime CreatedDateTime {get;}
    
    public DateTime UpdatedDateTime {get;}


    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();

    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();

    public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) 
        : base(guestId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

    public static Guest Create(GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId)
    {
        return new(GuestId.CreateUnique(),
        firstName,
        lastName,
        userId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private Guest(){

    }
#pragma warning restore CS8618
}
