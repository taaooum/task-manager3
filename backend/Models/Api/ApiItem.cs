using backend.Enums;

namespace backend.Models.Api
{
    public class ApiItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = String.Empty;

        public Guid BucketId { get; set; }
        
        public string? Description { get; set; }

        public DateTime? Reminder { get; set; }

        public DateTime? DueDate { get; set; }

        public Repetition Frequency { get; set; } = Repetition.None;

        public bool IsComplete { get; set; }
    }
}
