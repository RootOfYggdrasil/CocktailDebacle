namespace CocktailDebacleBackend.Dtos.User
{
	public class UpdateUserRequestDto
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public bool ConsentProfile { get; set; } = false;
	}
}
