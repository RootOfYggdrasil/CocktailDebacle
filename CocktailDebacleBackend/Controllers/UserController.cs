using CocktailDebacleBackend.Data;
using CocktailDebacleBackend.Dtos.User;
using CocktailDebacleBackend.Mappers;
using Microsoft.AspNetCore.Mvc;


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
        public IActionResult GetAll()
        {
            // we need to convert the objecct to List, to do a Deferred Execution
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user= _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
		public IActionResult Create([FromBody] CreateUserRequestDto userDto)
		{
			var userModel = userDto.ToUserFromCreateDTO();
			_context.Users.Add(userModel);
			_context.SaveChanges();
			return CreatedAtAction(nameof(GetById), new { id = userModel.UserId }, userModel);
		}


	}
}
