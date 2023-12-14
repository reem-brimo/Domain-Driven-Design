using Dinner.Application.Common.interfaces.Presistence;
using Dinner.Domain.Host;
using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.MenuAggregate;
using Dinner.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace Dinner.Application.Menus.Commands.CreateMenu;


public class CreateMenuCommandHandler : 
    IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{

    private readonly IMenuRepository _MenuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _MenuRepository = menuRepository;
    }
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
            hostId: HostId.CreateValue(request.HostId),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(section =>MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description
                )))));   
      
        _MenuRepository.Add(menu);
        return menu;
    }
}