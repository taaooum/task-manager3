using backend.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class DataContextService : DbContext
    {
        public DataContextService() { }

        public DataContextService(DbContextOptions options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Bucket> Buckets { get; set; }
    }
}