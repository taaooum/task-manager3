using System.ComponentModel.DataAnnotations;

namespace backend.Models.Domain
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public Guid BuckedId { get; set; }
        public string? Description { get; set; }
        public DateTime? Reminder { get; set; }
        public DateTime? DueDate { get; set; }
        public RepetitionCategory Frequency { get; set; } = RepetitionCategory.None; // The interval/frequency of repetition for the task (e.g., Daily, Weekly)
        public bool IsComplete { get; set; } = false;
        public enum RepetitionCategory
        {
            None,
            Dail1y,
            Weekly,
            Monthly,
            Yearly
        }
    }
}