using System.ComponentModel.DataAnnotations;

namespace CocktailDebacleBackend.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<CocktailIngredient>? CocktailIngredients { get; set; }
    }
}