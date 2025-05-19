using Egzaminas.BusinessLogic;
using Egzaminas.Object;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Egzaminas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class AdminController : ControllerBase
    {
    
        private readonly IAdminBusinessLogic _adminBusinessLogic;
        public AdminController( IAdminBusinessLogic adminBusinessLogic)
        {
    
            _adminBusinessLogic = adminBusinessLogic;
        }

        [HttpDelete("deleteUser")]
        public IActionResult DeleteUser(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Invalid user ID.");
            }
            if(!_adminBusinessLogic.IsIdInDatabase(id))
            {
                return BadRequest("User ID does not exist.");
            }
           
            if (_adminBusinessLogic.IsAdmin(id))
            {
                return BadRequest("Administrator account cannot be deleted.");
            }

            var result = _adminBusinessLogic.DeleteUser(id);
            if (result)
            {
                return Ok("User deleted successfully.");
            }
            else
            {
                return BadRequest( "Failed to delete user.");
            }
        }
    }
}
