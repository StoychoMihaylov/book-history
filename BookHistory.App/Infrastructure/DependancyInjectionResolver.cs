namespace BookHistory.App.Infrastructure
{
    using BookHistory.Data.Context;
    using BookHistory.Data.Interfaces;
    using BookHistory.Services.Interfaces;
    using BookHistory.Services.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependancyInjectionResolver
    {
        public static IServiceCollection AddDependancyInjectionResolver(this IServiceCollection services)
        {
            services.AddTransient<IBookHistoryDbContext, BookHistoryDbContext>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            
            return services;
        }
    }
}
