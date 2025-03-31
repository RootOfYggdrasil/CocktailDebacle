using CocktailDebacleBackend.Models;

namespace CocktailDebacleBackend.Interfaces
{
	public interface IUserRepository
	{
		Task<List<User>> GetAllAsync();
	}
}
