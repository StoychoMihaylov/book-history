namespace BookHistory.App.Infrastructure
{
    using BookHistory.Data.Context;
    using BookHistory.Data.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependancyInjectionResolver
    {
        public static IServiceCollection AddDependancyInjectionResolver(this IServiceCollection services)
        {
            services.AddTransient<IBookHistoryDbContext, BookHistoryDbContext>();
            
            return services;
        }
    }
}
