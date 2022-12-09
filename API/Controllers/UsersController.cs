using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/users

    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            // var users = _context.Users.ToList(); // if we are not making a query than we can specify ToList() method which will get a list of users from the databse.
            var users = await _context.Users.ToListAsync(); // async version

            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) 
        {
            // var user = _context.Users.Find(id); // to use Find() method primary key id has to be passed to the method. Alternatively if you want to find data by let's say name than different method will be used.
            var user = await _context.Users.FindAsync(id); //async version
            return user;
        }
    }
}