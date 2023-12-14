using Dinner.Application.Authentication.Commands.Register;
using Dinner.Application.Authentication.Common;
using Dinner.Application.Authentication.Queries.Login;
using Dinner.Contracts.Authentication;
using Mapster;

namespace Dinner.API.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest, src => src.User);
    }
}