using Dinner.Application.Common.interfaces.Authentication;
using Dinner.Application.Common.interfaces.Services;
using Dinner.Infrastructure.Authentication;
using Dinner.Infrastructure.Servicecs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Dinner.Application.Common.interfaces.Presistence;
using Dinner.Infrastructure.Presistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using Dinner.Infrastructure.Presistence.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Dinner.Infrastructure;

public static class DependenceyInjection{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
  
    services
    .AddAuth(configuration)
    .AddPresistance(configuration);

    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    

    return services;
    }

    
 public static IServiceCollection AddPresistance(
     this IServiceCollection services,
     ConfigurationManager configuration)
    {
    services.AddDbContext<DinnerDbContext>(options => options.UseSqlServer("Server=RB;Database=Dinner;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;Integrated Security=True"));
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IMenuRepository, MenuRepository>();

    return services;
    }


    public static IServiceCollection AddAuth(
       this IServiceCollection services,
       ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer( options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

        return services;
    }
}
