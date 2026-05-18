using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyStore.Domain.Model;
using Pgvector;

namespace MyStore.Infrastructure
{
    public class VectorDbContext(DbContextOptions<VectorDbContext> options) : DbContext(options)
    {
        public DbSet<ProductEmbeddingDocument> ProductEmbeddings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("vector");

            modelBuilder.Entity<ProductEmbeddingDocument>(entity =>
            {
                entity.ToTable("product_embeddings_alternative");
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.Embedding)
                      .HasColumnType("vector(3)")
                      .HasConversion(
                          v => new Vector(v),
                          v => v.Memory.ToArray(),
                          new ValueComparer<float[]>(
                              (a, b) => a != null && b != null && a.SequenceEqual(b),
                              v => v.Aggregate(0, (h, i) => HashCode.Combine(h, i.GetHashCode())),
                              v => v.ToArray()));
            });
        }
    }
}
