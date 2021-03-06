using BookService.Application.Interfaces.Configuration;
using BookService.Application.Interfaces.Repositories;
using BookService.Domain.Parameters;
using BookService.Infrastructure.Configuration;
using BookService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookService.Infrastructure.DI
{
    public static class DiExtension
    {
        public static IServiceCollection AddBookDataSources(this IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookDataRepository, BookDataRepository>();

            return services;
        }

        public static IServiceCollection AddCartDataSources(this IServiceCollection services)
        {
            services.AddTransient<ICartRepository, CartRepository>();

            return services;
        }

        public static IServiceCollection AddConfigProvider(this IServiceCollection services,
            IConfiguration configuration, ConfigParameter configParameter)
        {
            services.AddSingleton<IConfigProvider>(new ConfigProvider(configuration, configParameter));

            return services;
        }
    }
}
