using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
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
                entity.HasKey(e => e.ProductId);   // ProductId is the PK — no separate Id

                entity.Property(e => e.Embedding)
                      .HasColumnType("vector(3)")   // 3 dims for demo; 1536 for OpenAI in production
                      .HasConversion(
                          v => new Pgvector.Vector(v),           // float[] → Vector when writing to DB
                          v => v.Memory.ToArray(),      // Vector → float[] when reading from DB
                          new ValueComparer<float[]>(
                              (a, b) => a != null && b != null && a.SequenceEqual(b),
                              v => v.Aggregate(0, (h, i) => HashCode.Combine(h, i.GetHashCode())),
                              v => v.ToArray()));        // deep copy for change tracking
            });
        }
    }
}
