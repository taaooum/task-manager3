using backend.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Seeds
{
    public static class SeedTask
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // Create a new instance of TaskManagerDbContext using the provided service provider
            using var context = new RepositoryDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<RepositoryDbContext>>());

            // Check if any tasks already exist, if so, return early.
            if (context.TaskItems.Any()) return;

            // Add a range of sample tasks to the TaskItems table in the database
            context.TaskItems.AddRange(
                new Item
                {
                    Name = "Complete Project Report",
                    Description = "Write the final report for the client project.",
                    DueDate = DateTime.Parse("2024-12-10"),
                    Frequency = Item.RepetitionCategory.Monthly,
                    IsComplete = false
                },
                new Item
                {
                    Name = "Prepare Presentation",
                    Description = "Prepare slides for the team presentation next week.",
                    DueDate = DateTime.Parse("2024-12-12"),
                    Frequency = Item.RepetitionCategory.Monthly,
                    IsComplete = false
                },
                new Item
                {
                    Name = "Fix Bugs in Code",
                    Description = "Address the top priority bugs in the codebase.",
                    DueDate = DateTime.Parse("2024-12-15"),
                    Frequency = Item.RepetitionCategory.Weekly,
                    IsComplete = false
                },
                new Item
                {
                    Name = "Client Meeting",
                    Description = "Attend the client meeting to discuss project milestones.",
                    DueDate = DateTime.Parse("2024-12-18"),
                    Frequency = Item.RepetitionCategory.Monthly,
                    IsComplete = false
                },
                new Item
                {
                    Name = "Backup Database",
                    Description = "Perform the routine database backup to ensure data safety.",
                    DueDate = DateTime.Parse("2024-12-20"),
                    Frequency = Item.RepetitionCategory.Yearly,
                    IsComplete = false
                }
            );

            // Save the changes to the database to persist the new TaskItems
            context.SaveChanges();
        }
    }
}
