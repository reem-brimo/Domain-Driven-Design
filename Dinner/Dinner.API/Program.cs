using Dinner.API;
using Dinner.Application;
using Dinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


{
    builder.Services
        .AddPresentation()
        
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseAuthentication();
    app.UseAuthorization();
    
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}

