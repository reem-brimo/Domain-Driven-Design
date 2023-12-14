using Dinner.Application.Common.interfaces.Authentication;
using Dinner.Application.Common.interfaces.Presistence;
using Dinner.Domain.Entities;
using Dinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Dinner.Application.Authentication.Common;

namespace Dinner.Application.Authentication.Queries.Login;


public class LoginQueryHandler : 
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _UserRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _UserRepository = userRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_UserRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);

    }
}