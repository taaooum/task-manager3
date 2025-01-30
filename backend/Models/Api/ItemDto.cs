using backend.Models.Domain;

namespace backend.Models.Api
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; } = string.Empty;

        public Guid BucketId { get; set; }
        
        public string? Description { get; set; }

        public DateTime? Reminder { get; set; }

        public DateTime? DueDate { get; set; }

        public RepetitionCategory Frequency { get; set; } = RepetitionCategory.None;

        public bool IsComplete { get; set; } = false;
    }
}
