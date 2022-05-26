using AutoMapper;
using BookService.Application.Interfaces.Services;
using BookService.Application.Mapping;
using BookService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookService.Application.DI
{
    public static class DiExtension
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthorService, AuthorService>();

            return services;
        }

        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(MappingConfiguration.GetMapper());

            return services;
        }
    }
}
