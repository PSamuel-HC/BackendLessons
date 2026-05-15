using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MyStore.Infrastructure.Vector
{
    public class VectorDbInitializer(NpgsqlDataSource dataSource, IConfiguration configuration)
    {
        public async Task InitializeAsync()
        {
            await EnsureDatabaseExistsAsync();
            await EnsureSchemaAsync();
        }

        private async Task EnsureDatabaseExistsAsync()
        {
            // Parse the target database name out of the VectorConnection string
            var csb = new NpgsqlConnectionStringBuilder(
                configuration.GetConnectionString("VectorConnection"));

            var targetDb = csb.Database!;

            // Connect to the 'postgres' maintenance database — it always exists
            csb.Database = "postgres";

            await using var adminSource = new NpgsqlDataSourceBuilder(csb.ConnectionString).Build();
            await using var conn = await adminSource.OpenConnectionAsync();

            await using var checkCmd = conn.CreateCommand();
            checkCmd.CommandText = "SELECT 1 FROM pg_database WHERE datname = $1";
            checkCmd.Parameters.AddWithValue(targetDb);
            var exists = await checkCmd.ExecuteScalarAsync();

            if (exists is null)
            {
                // CREATE DATABASE cannot run inside a transaction and cannot use $1 parameters.
                // The name comes from our own config (not user input) so quoting it is safe.
                await using var createCmd = conn.CreateCommand();
                createCmd.CommandText = $"CREATE DATABASE \"{targetDb}\"";
                await createCmd.ExecuteNonQueryAsync();
            }
        }

        private async Task EnsureSchemaAsync()
        {
            await using var conn = await dataSource.OpenConnectionAsync();

            // Enable the pgvector extension (safe to run every startup)
            await using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "CREATE EXTENSION IF NOT EXISTS vector;";
                await cmd.ExecuteNonQueryAsync();
            }

            // Create the table if it does not exist
            await using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = """
                    CREATE TABLE IF NOT EXISTS product_embeddings (
                        id          SERIAL  PRIMARY KEY,
                        product_id  INT     NOT NULL,
                        description TEXT    NOT NULL,
                        embedding   vector(3) NOT NULL
                    );
                    """;
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
