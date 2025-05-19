using Egzaminas.BusinessLogic;
using Egzaminas.Object;
using Microsoft.AspNetCore.Mvc;


namespace Egzaminas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthBusinessLogic _authBusinessLogic;
        private readonly IJwtService _jwtService;

        public AuthController(AuthBusinessLogic authBusinessLogic, IJwtService jwtServic)
        {
            _authBusinessLogic = authBusinessLogic;
            _jwtService = jwtServic;
        }

        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount([FromForm] CreateAccountRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) ||
                string.IsNullOrEmpty(request.Password) ||
                string.IsNullOrEmpty(request.FirstName) ||
                string.IsNullOrEmpty(request.LastName) ||
                string.IsNullOrEmpty(request.PersonalNo) ||
                string.IsNullOrEmpty(request.PhoneNumber) ||
                string.IsNullOrEmpty(request.Email) ||
                string.IsNullOrEmpty(request.City) ||
                string.IsNullOrEmpty(request.Street) ||
                string.IsNullOrEmpty(request.HouseNumber) ||
                request.Picture == null)
            {
                return BadRequest("All fields are required.");
            }

            if (_authBusinessLogic.CheckIfUsernameExists(request.Username))
            {
                return BadRequest("Username already exists.");
            }

            var newAccount = _authBusinessLogic.SignupNewAccount(request);

            return Ok("Account created successfully.");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AccountRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            bool isAuthenticated = _authBusinessLogic.Login(request.Username, request.Password, out string role);

            if (!isAuthenticated)
            {
                return Unauthorized("Invalid username or password.");
            }
            string token = _jwtService.GetJwtToken(request.Username, role);
            return Ok(token);
        }

       

    }
}
