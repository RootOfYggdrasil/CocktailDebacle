using CocktailDebacleBackend.Models;
using CocktailDebacleBackend.Interfaces;
using CocktailDebacleBackend.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CocktailDebacleBackend.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _context;
		public UserRepository(AppDbContext context)
		{
			_context = context;
		}
		public Task<List<User>> GetAllAsync()
		{
			return _context.Users.ToListAsync();
		}
	}
}
