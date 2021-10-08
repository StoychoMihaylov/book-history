namespace BookHistory.App.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using BookHistory.Data.Context;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class PosgreSQLWithEntityFrameworkExtesion
    {
        public static IServiceCollection AddPosgreSQLWithEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<BookHistoryDbContext>((sp, opt) =>
                {   
                    opt.UseNpgsql(configuration.GetConnectionString("BookHistoryDB"))
                        .UseInternalServiceProvider(sp);
                });

            return services;
        }
    }
}
