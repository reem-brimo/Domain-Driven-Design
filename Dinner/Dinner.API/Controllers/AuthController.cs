using Dinner.Application.Authentication.Commands.Register;
using Dinner.Application.Authentication.Common;
using Dinner.Application.Authentication.Queries.Login;
using Dinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.API.Controllers;

[Route("[controller]")]
public class AuthController: ApiController
{
  
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
     public async Task<IActionResult> Register(RegisterRequest request)
    {

        var command = _mapper.Map<RegisterCommand>(request);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
       
    }

 
    [HttpPost("login")]
     public async Task<IActionResult> Login(LoginRequest request)
    {
          var query = _mapper.Map<LoginQuery>(request);

         ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

         return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }

}