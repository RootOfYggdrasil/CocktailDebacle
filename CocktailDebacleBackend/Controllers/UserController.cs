using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CocktailDebacleBackend.Data;
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

    }
}
