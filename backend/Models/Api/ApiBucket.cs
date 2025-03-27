using System.ComponentModel.DataAnnotations;

namespace backend.Models.Api
{
    public class ApiBucket
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
