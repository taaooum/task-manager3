using backend.Models.Domain;

namespace backend.Models.Api;

public class CreateItem
{
    public string Title { get; set; } = String.Empty;

    public Guid BucketId { get; set; }
        
    public string? Description { get; set; }

    public DateTime? Reminder { get; set; }

    public DateTime? DueDate { get; set; }

    public Repetition Frequency { get; set; } = Repetition.None;

    public bool IsComplete { get; set; } = false;
}