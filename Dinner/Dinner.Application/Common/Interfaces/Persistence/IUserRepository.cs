using Dinner.Domain.Entities;

namespace Dinner.Application.Common.interfaces.Presistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void Add(User user);
}