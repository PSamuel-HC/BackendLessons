using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyStore.Infrastructure.PostgreExtension
{
    public static class PostgresExtensions
    {
        public static IServiceCollection AddPostgresVectorDb(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<VectorDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("VectorConnection"),
                    o => o.UseVector()));

            return services;
        }
    }
}
