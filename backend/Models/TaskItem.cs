using System.ComponentModel.DataAnnotations;
using backend.Data;

namespace backend.Models
{
    public class TaskItem
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? Reminder {  get; set; }
        public DateTime? DueDate { get; set; }
        public RepetitionCategory Frequency { get; set; } = RepetitionCategory.None; // The interval/frequency of repetition for the task (e.g., Daily, Weekly)
        public bool IsComplete { get; set; } = false;
        
    }
}