using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MauiApp2.Models
{
    public class JournalEntry
    {
        [Key]
        public int EntryId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(50)]
        public string? PrimaryMood { get; set; }

        [StringLength(50)]
        public string? SecondaryMood1 { get; set; }

        [StringLength(50)]
        public string? SecondaryMood2 { get; set; }

        [StringLength(50)]
        public string? Category { get; set; }

        public string? Tags { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int WordCount { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
