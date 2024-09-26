namespace Psyker.WebUI.Extensions;

using Hangfire;
using Newtonsoft.Json;

public static class HangfireConfigurationExtensions
{
    public static void UseMediatR(this IGlobalConfiguration configuration)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        configuration.UseSerializerSettings(settings);
    }
}
