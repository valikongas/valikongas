using Egzaminas.BusinessLogic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Egzaminas.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User, Admin")]
 public class GetInfoController : ControllerBase
    {

            private readonly GetInfoBusinessLogic _getInfoBusinessLogic;

            public GetInfoController( GetInfoBusinessLogic getInfoBusinessLogic)
            {
 
                _getInfoBusinessLogic = getInfoBusinessLogic;

            }
        
        [HttpGet("GetUserData")]
        public IActionResult GetUserData()
        {

                                  
            var username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("User is not authenticated.");
            }

            var result = _getInfoBusinessLogic.GetInfo(username);
            if (result == null)
            {
                return NotFound("User not found.");
            }
            return Ok(result);       
        }

        private string GetLoggedInUsername()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        }

    }
}
