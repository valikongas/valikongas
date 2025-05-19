using API_Nr7_Uzrasine.Object;
using API_Nr7_Uzrasine.BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace API_Nr7_Uzrasine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Conection _connection;
        private readonly IJwtService _jwtService;

        public AuthController(Conection connection, IJwtService jwtServic )
        {
            _connection = connection;
            _jwtService = jwtServic;
        }


        [HttpPost("createaccount")]
        public IActionResult CreateAccount([FromBody] CreateAccountRequest request)
        {
            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Name, username and password are required.");
            }

            if(_connection.CheckIfUsernameExists(request.Username))
            {
                return BadRequest("Username already exists.");
            }
            var newAccount =_connection.SignupNewAccount(request.Name, request.Username, request.Password);
                      
            var result = new
            {
                Success = true,
                Message = "Account created successfully.",
                Name = request.Name
            };

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            bool isAuthenticated = _connection.Login(request.Username, request.Password);

            if (!isAuthenticated)
            {
                return Unauthorized("Invalid username or password.");
            }
            string token = _jwtService.GetJwtToken(request.Username);
            var result = new
            {
                Success = true,
                Message = "Login successful.",
                Username = request.Username,
                Token = token
            };

            return Ok(result);
        }

      
        
    }

   
}
