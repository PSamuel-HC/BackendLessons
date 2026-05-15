using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyStore.Infrastructure.Vector;
using Npgsql;

namespace MyStore.Infrastructure.PostgreExtension
{
    public static class PostgresExtensions
    {
        public static IServiceCollection AddPostgresVectorDb(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddSingleton<NpgsqlDataSource>(sp =>
            //{
            //    var connectionString = configuration
            //        .GetConnectionString("VectorConnection");

            //    var builder = new NpgsqlDataSourceBuilder(connectionString);
            //    builder.UseVector();   // tells Npgsql how to map the Vector type
            //    return builder.Build();
            //});

            //services.AddSingleton<VectorDbInitializer>();

            //return services;

            services.AddDbContext<VectorDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("VectorConnection"),
                    o => o.UseVector()));   // registers pgvector type mappings

            return services;

        }
    }
}
