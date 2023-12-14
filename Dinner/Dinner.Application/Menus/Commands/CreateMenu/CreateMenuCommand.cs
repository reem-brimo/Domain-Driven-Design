using Dinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string Name,
    string Description,
    List<MenuSectionCommand> Sections,
    string HostId) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items
);

public record MenuItemCommand(
    string Name,
    string Description
);