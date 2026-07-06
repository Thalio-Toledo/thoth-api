using Microsoft.EntityFrameworkCore;
using thoth_api.Infrastructure;

namespace thoth_api.Extensions
{
    public static class ContextExtension
    {
        public static IServiceCollection AddDBConnection(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<Context>(options =>
            {
                options.UseSqlite($"Data Source=Infrastructure/thoth.db");
            });

            return services;
        }
    }
}
