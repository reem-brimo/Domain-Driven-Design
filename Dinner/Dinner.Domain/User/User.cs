using Dinner.Domain.Common.Models;
using Dinner.Domain.User.ValueObjects;


namespace Dinner.Domain.User;


public sealed class User : AggregateRoot<UserId, Guid>
{
   
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Password { get; set; }

    public DateTime CreatedDateTime {get;}
    
    public DateTime UpdatedDateTime {get;}

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime) 
        : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

    public static User Create(string firstName,
        string lastName,
        string password)
    {
        return new(UserId.CreateUnique(),
        firstName,
        lastName,
        password,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private User(){

    }
#pragma warning restore CS8618

}
