using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models.Domain
{
    [Table("items")]
    public class Item
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("titel"), Required]
        public string Title { get; set; } = String.Empty;

        [Column("description")]
        public string? Description { get; set; } = String.Empty;

        [Column("bucket_id"), Required]
        public Guid BucketId { get; set; }

        [Column("reminder")]
        public DateTime? Reminder { get; set; }

        [Column("due_date")]
        public DateTime? DueDate { get; set; }

        [Column("frequency")]
        public Repetition Frequency { get; set; } = Repetition.None; // The interval/frequency of repetition for the task (e.g., Daily, Weekly)

        [Column("is_complete")]
        public bool IsComplete { get; set; } = false;
    }
}