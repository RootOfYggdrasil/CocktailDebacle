using CocktailDebacleBackend.Data;
using CocktailDebacleBackend.Dtos.User;
using CocktailDebacleBackend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CocktailDebacleBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        //Get is a Read
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // we need to convert the objecct to List, to do a Deferred Execution
            var users = await _context.Users.ToListAsync();

            var userDtos = users.Select(u => u.ToUserDto());

			return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDTO();
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = userModel.UserId }, userModel);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (userModel == null)
            {
                return NotFound();
            }

            userModel.Username = updateDto.Username;
            userModel.Email = updateDto.Email;
            userModel.ConsentProfile = updateDto.ConsentProfile;
            _context.Users.Update(userModel);
			await _context.SaveChangesAsync();
            return Ok(userModel);
        }
        

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var userModel = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
			if (userModel == null)
			{
				return NotFound();
			}
			_context.Users.Remove(userModel);
			await _context.SaveChangesAsync();
			return NoContent();
		}

	}
}
