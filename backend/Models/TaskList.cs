using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class TaskList
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
