using CocktailDebacleBackend.Models;
using CocktailDebacleBackend.Interfaces;
using CocktailDebacleBackend.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocktailDebacleBackend.Dtos.User;


namespace CocktailDebacleBackend.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _context;
		public UserRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<List<User>> GetAllAsync()
		{
			return await _context.Users.ToListAsync();
		}
		public async Task<User?> GetByIdAsync(int id)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
		}
		public async Task<User?> UpdateAsync(int id, UpdateUserRequestDto userModel)
		{
			var userModelExisting = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
			if (userModelExisting == null)
			{
				return null;
			}
			userModelExisting.Username = userModel.Username;
			userModelExisting.Email = userModel.Email;
			userModelExisting.PasswordHash = userModel.Password;
			userModelExisting.ConsentProfile = userModel.ConsentProfile;
			await _context.SaveChangesAsync();
			return userModelExisting ;
		}
		public async Task<User> CreateAsync(User userModel)
		{
			await _context.Users.AddAsync(userModel);
			await _context.SaveChangesAsync();
			return userModel;
		}
		public async Task<User?> DeleteAsync(int id)
		{
			var userModel = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
			if (userModel == null)
			{
				return null;
			}
			_context.Users.Remove(userModel);
			await _context.SaveChangesAsync();
			return userModel;
		}

	}
}
