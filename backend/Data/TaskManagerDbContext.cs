using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
        : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; } = null!;
        public DbSet<TaskList> TaskLists { get; set; } = null!;
    }
}
