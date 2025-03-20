using System.ComponentModel.DataAnnotations;

namespace CocktailDebacleBackend.Models
{
    public class CocktailIngredient
    {
        public int CocktailId { get; set; }
        [Required]
        public Cocktail Cocktail { get; set; }
        public int IngredientId { get; set; }
        [Required]
        public Ingredient Ingredient { get; set; }
        [Required]
        public string Measure { get; set; }
    }
}