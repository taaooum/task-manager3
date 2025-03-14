namespace backend.Models.Api;

public class CreateBucket
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }
}