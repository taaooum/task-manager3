using backend.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext() { }

        public RepositoryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Bucket> Buckets { get; set; }
    }
}
