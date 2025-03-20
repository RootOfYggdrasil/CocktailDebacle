using System.ComponentModel.DataAnnotations;

namespace CocktailDebacleBackend.Models
{
    public enum SourceType
    {
        Api,
        Custom
    }

    public class Cocktail
    {
        [Key]
        public int CocktailId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Category { get; set; }
        public bool Alcoholic { get; set; }
        public string? GlassType { get; set; }
        public string? Instructions { get; set; }
        public string? ImageUrl { get; set; }
        public string Source { get; set; } = SourceType.Api.ToString();

        public ICollection<CocktailIngredient>? CocktailIngredients { get; set; }
        public ICollection<Favorite>? Favorites { get; set; }
        public ICollection<UserCocktail>? UserCocktails { get; set; }
    }
}