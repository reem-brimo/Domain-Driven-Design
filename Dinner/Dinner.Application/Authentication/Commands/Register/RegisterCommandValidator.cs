using FluentValidation;

namespace Dinner.Application.Authentication.Commands.Register;


public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator () {
        
        RuleFor(x => x.FirstName).NotEmpty().NotNull();
        RuleFor(x => x.LastName).NotEmpty();

        // RuleFor(x => x.FirstName).NotEmpty();

        // RuleFor(x => x.FirstName).NotEmpty();

        
    }
}