using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class TaskItem
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Reminder {  get; set; }
        public DateTime? DueDate { get; set; }
        public enum Repetition
        {
            None = 0,
            Daily = 1,
            Weekly = 2,
            Monthly = 3,
            Yearly = 4
        }
        [Required]
        public bool IsComplete { get; set; } 
    }
}