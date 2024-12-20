using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Configuration;

namespace backend.Data
{
    public class TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : DbContext(options)
    {
        public DbSet<TaskItem> TaskItems { get; set; } = null!;
        public DbSet<TaskList> TaskLists { get; set; } = null!;
    }
}
