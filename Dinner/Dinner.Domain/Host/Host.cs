using Dinner.Domain.MenuAggregate.ValueObjects;
using Dinner.Domain.MenuAggregate.Entities;
using Dinner.Domain.Dinner.ValueObjects;
using Dinner.Domain.MenuReview.ValueObjects;
using Dinner.Domain.Common.Models;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.User.ValueObjects;

namespace Dinner.Domain.Host;


public sealed class Host : AggregateRoot<HostId, string>
{
   
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuId> _menuIds = new();

    public UserId UserId {get; private set;}

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();

    public DateTime CreatedDateTime {get; private set;}
    
    public DateTime UpdatedDateTime {get; private set;}

    private Host(
        HostId hostId,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) 
        : base(hostId)
        {
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

    public static Host Create(UserId userId)
    {
        return new(HostId.CreateUniqueValue(),
        userId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private Host(){

    }
#pragma warning restore CS8618


}
