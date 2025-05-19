using API_Nr5.Data;
using API_Nr5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Nr5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApiDbContext _db;

        public UsersController(ApiDbContext db)
        {
            _db = db;
        }


        [HttpPost]
        public async Task<ActionResult<User>> CreateTask([FromBody] UserDto user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.UserPosition))
                return BadRequest("Ne visi butini duomenys gauti");

            User userFind = await _db.Users.FirstOrDefaultAsync(t => t.UserName == user.UserName);
            if (userFind != null)
            {
                return BadRequest("Toks zmogus jau egzistuoja");
            }


            User newUser = new User(user.UserName, user.UserPosition);
            _db.Users.Add(newUser);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            List<User> users = await _db.Users.ToListAsync();

            if (users == null || users.Count == 0)
                return NotFound("Vartotojų nerasta.");

            return Ok(users);
        }

    }
}
