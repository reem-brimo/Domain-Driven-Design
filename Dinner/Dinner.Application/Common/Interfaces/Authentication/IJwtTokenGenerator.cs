using Dinner.Domain.Entities;

namespace Dinner.Application.Common.interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}