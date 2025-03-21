using System.ComponentModel.DataAnnotations;

namespace CocktailDebacleBackend.Models
{
    public class SearchHistory
    {
        [Key]
        public int SearchId { get; set; }

        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public string SearchTerm { get; set; }
        public DateTime SearchDate { get; set; } = DateTime.UtcNow;
    }
}