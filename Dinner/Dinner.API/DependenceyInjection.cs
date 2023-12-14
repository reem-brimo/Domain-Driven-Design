using Dinner.API.Common.Errors;
using Dinner.API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Dinner.API;

public static class DependenceyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddSingleton<ProblemDetailsFactory, DinnerProblemDetailsFactory>();

        services.AddMappings();
        return services;
    }
}
