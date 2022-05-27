using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace BookService.Application.Logging
{
    public static class LogExtension
    {
        public static IServiceCollection AddLogger(this IServiceCollection services, string configName)
        {
            services.AddLogging(builder => builder.AddConsole()
                                                  .AddNLog(configName));

            return services;
        }
    }
}
