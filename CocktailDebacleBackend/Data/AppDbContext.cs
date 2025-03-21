using Microsoft.EntityFrameworkCore;
using CocktailDebacleBackend.Models;

namespace CocktailDebacleBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CocktailIngredient> CocktailIngredients { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<UserCocktail> UserCocktails { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CocktailIngredient>()
                .HasKey(ci => new { ci.CocktailId, ci.IngredientId });

            modelBuilder.Entity<Favorite>()
                .HasKey(f => new { f.UserId, f.CocktailId });

            modelBuilder.Entity<UserCocktail>()
                .HasKey(uc => new { uc.UserId, uc.CocktailId });
        }
    }
}
