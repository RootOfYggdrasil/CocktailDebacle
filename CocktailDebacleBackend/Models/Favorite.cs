using System.ComponentModel.DataAnnotations;

namespace CocktailDebacleBackend.Models
{
    public class Favorite
    {
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }

        public int CocktailId { get; set; }
        [Required]
        public Cocktail Cocktail { get; set; }
    }
}