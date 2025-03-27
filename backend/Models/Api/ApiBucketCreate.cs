using System.ComponentModel.DataAnnotations;
namespace backend.Models.Api
{
    public class ApiBucketCreate
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}