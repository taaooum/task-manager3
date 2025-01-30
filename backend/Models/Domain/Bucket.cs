using System.ComponentModel.DataAnnotations;

namespace backend.Models.Domain
{
    public class Bucket
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Title { get; set; } = String.Empty;
        
        public string? Description { get; set; }
        
        public IEnumerable<Item>? Items { get; set; }
    }
}
