using Dinner.Application.Menus.Commands.CreateMenu;
using Dinner.Contracts.Menus;
using Dinner.Domain.MenuAggregate;
using Mapster;

using MenuSection = Dinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = Dinner.Domain.MenuAggregate.Entities.MenuItem;

namespace Dinner.API.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId),CreateMenuCommand>()
        .Map(des => des.HostId, src => src.HostId)
        .Map(des => des, src => src.Request);

        config.NewConfig<Menu, CreateMenuResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
        .Map(dest => dest.HostId, src => src.HostId.Value)
        .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
        .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value));
        
        config.NewConfig<MenuSection, MenuSectionResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);
        
        config.NewConfig<MenuItem, MenuItemResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);
    }
}