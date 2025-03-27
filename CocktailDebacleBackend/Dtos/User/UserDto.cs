using System.ComponentModel.DataAnnotations;

namespace CocktailDebacleBackend.Dtos.User
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool ConsentProfile { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
