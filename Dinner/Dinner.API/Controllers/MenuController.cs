using Dinner.Application.Menus.Commands.CreateMenu;
using Dinner.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.API.Controllers;

[Route("hosts/{hostId}/menus")]
[Authorize]
public class MenuController: ApiController
{
  
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public MenuController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));

        var createMenuResult = await _mediator.Send(command); 

        return createMenuResult.Match(
            menu => Ok(_mapper.Map<CreateMenuResponse>(menu)),
            errors => Problem(errors)
        );
    }
   
}