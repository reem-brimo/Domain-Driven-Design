using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.API.Controllers;

[Route("[controller]")]
[Authorize]
public class DinnerController: ApiController
{
  
    // private readonly ISender _mediator;
    // private readonly IMapper _mapper;

    // public DinnerController(ISender mediator, IMapper mapper)
    // {
    //     _mediator = mediator;
    //     _mapper = mapper;
    // }

    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());  
    }
   
}