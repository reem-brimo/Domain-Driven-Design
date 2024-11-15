using Dinner.Domain.Entities;

namespace Dinner.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);