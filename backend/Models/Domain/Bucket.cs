using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models.Domain
{
    [Table("buckets")]
    public class Bucket
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("titel"), Required]
        public string Title { get; set; } = String.Empty;
        
        [Column("description")]
        public string? Description { get; set; }

        public IEnumerable<Item>? Items { get; set; }
    }
}
