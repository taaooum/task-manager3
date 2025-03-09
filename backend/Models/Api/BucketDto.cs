using Microsoft.EntityFrameworkCore;

namespace backend.Models.Api
{
    public class BucketDto
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
