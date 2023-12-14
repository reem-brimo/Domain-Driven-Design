using Dinner.Application.Common.interfaces.Authentication;
using Dinner.Application.Common.interfaces.Presistence;
using Dinner.Domain.Entities;
using Dinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Dinner.Application.Authentication.Common;

namespace Dinner.Application.Authentication.Commands.Register;


public class RegisterCommandHandler : 
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _UserRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _UserRepository = userRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_UserRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _UserRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}