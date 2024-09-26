namespace Psyker.Infrastructure;

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Psyker.Infrastructure.Hangfire;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddHangfire(configuration);

        services.AddLocalization(options => options.ResourcesPath = "Resources");

        return services;
    }

    public static void UseInfrastructure(this IApplicationBuilder app)
    {
        var supportedCultures = new[] { "en", "en-US", "en-GB", };
        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        app.UseRequestLocalization(localizationOptions);
    }
}
