namespace Psyker.Infrastructure.Hangfire;

using global::Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Psyker.Infrastructure.Hangfire.Extensions;

internal static class DependencyInjection
{
    public static IServiceCollection AddHangfire(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        HangfireServiceCollectionExtensions.AddHangfire(services, cfg =>
        {
            cfg.UseSqlServerStorage(connectionString);
            cfg.UseMediatR();
        });
        services.AddHangfireServer();

        return services;
    }
}
