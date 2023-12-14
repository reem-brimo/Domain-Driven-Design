using System.Reflection;
using Dinner.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Dinner.Application.Authentication.Commands.Register;
using ErrorOr;
using Dinner.Application.Authentication.Common;
using FluentValidation;

namespace Dinner.Application;

public static class DependenceyInjection{
    public static IServiceCollection AddApplication(this IServiceCollection services){

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    
    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
   
        return services;
    }
}
