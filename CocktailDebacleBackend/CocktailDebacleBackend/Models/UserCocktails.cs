using System.ComponentModel.DataAnnotations;

namespace CocktailDebacleBackend.Models
{
    public class UserCocktail
    {
        [Key]
        public int UserCocktailId { get; set; }

        public int UserId { get; set; }
        [Required]
        public User User { get; set; }

        public int CocktailId { get; set; }
        [Required]
        public Cocktail Cocktail { get; set; }
    }
}