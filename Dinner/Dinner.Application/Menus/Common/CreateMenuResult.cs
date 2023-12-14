using Dinner.Domain.Entities;

namespace Dinner.Application.Menus.Common;

public record CreateMenuResult(
    User User,
    string Token
);