using System.ComponentModel.DataAnnotations;

namespace CocktailDebacleBackend.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public bool ConsentProfile { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Favorite>? Favorites { get; set; }
        public ICollection<SearchHistory>? SearchHistories { get; set; }
        public ICollection<UserCocktail>? UserCocktails { get; set; }
    }

}