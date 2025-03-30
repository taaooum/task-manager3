using Microsoft.Build.Framework;

namespace backend.Models.Api
{
    public class ApiBucketWithItems
    {
        [Required]
        public ApiBucket Bucket { get; set; }
        public List<ApiItem>? Items { get; set; }
    }
}