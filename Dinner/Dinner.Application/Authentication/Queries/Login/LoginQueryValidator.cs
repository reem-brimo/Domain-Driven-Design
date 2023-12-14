using Dinner.Application.Authentication.Queries.Login;
using FluentValidation;

namespace Dinner.Application.Authentication.Commands.Register;


public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator () {
        
        RuleFor(x => x.Email).NotEmpty().NotNull();
        RuleFor(x => x.Password).NotEmpty();
        // RuleFor(x => x.FirstName).NotEmpty();

        // RuleFor(x => x.FirstName).NotEmpty();

        
    }
}