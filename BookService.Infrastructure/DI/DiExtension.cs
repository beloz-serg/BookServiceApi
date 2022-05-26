using BookService.Application.Interfaces.Repositories;
using BookService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookService.Infrastructure.DI
{
    public static class DiExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();

            return services;
        }
    }
}
