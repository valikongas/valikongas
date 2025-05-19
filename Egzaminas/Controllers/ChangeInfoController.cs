using Egzaminas.BusinessLogic;
using Egzaminas.Object;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Egzaminas.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
   
    public class ChangeInfoController : ControllerBase
    {
      
        private readonly ChangeInfoBusinessLogic _changeInfoBusinessLogic;
        public ChangeInfoController( ChangeInfoBusinessLogic changeInfoBusinessLogic)
        {
            _changeInfoBusinessLogic = changeInfoBusinessLogic;
        }

        [HttpPut("changeFirstName")]
        public IActionResult ChangeFirstName(string firstName )
        {
           
            if (string.IsNullOrEmpty(firstName))
            {
                return BadRequest("New username is required.");
            }
            var username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("User is not authenticated.");
            }
            var result = _changeInfoBusinessLogic.ChangeUserData(username, firstName);
            if (result)
            {
                return Ok( "Username changed successfully." );
            }
            else
            {
                return BadRequest( "Failed to change username." );
            }
        }

              
        [HttpPut("changeLastName")]
        public IActionResult ChangeLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return BadRequest("New last name is required.");
            }
            var username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("User is not authenticated.");
            }
            var result = _changeInfoBusinessLogic.ChangeUserData(username,"", lastName);
            if (result)
            {
                return Ok( "Last name changed successfully." );
            }
            else
            {
                return BadRequest("Failed to change last name.");
            }
        }

        [HttpPut("changeEmail")]
        public IActionResult ChangeEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("New email is required.");
            }
            var username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("User is not authenticated.");
            }
            var result = _changeInfoBusinessLogic.ChangeUserData(username,"","","","", email);
            if (result)
            {
                return Ok("Email changed successfully." );
            }
            else
            {
                return BadRequest( "Failed to change email.");
            }
        }

        [HttpPut("changePhoneNumber")]
        public IActionResult ChangePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return BadRequest("New phone number is required.");
            }
            var username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("User is not authenticated.");
            }
            var result = _changeInfoBusinessLogic.ChangeUserData(username,"","","", phoneNumber);
            if (result)
            {
                return Ok("Phone number changed successfully." );
            }
            else
            {
                return BadRequest("Failed to change phone number." );
            }
        }

        [HttpPut("changePersonalNo")]
        public IActionResult ChangePersonalNo(string personalNo)
        {
            if (string.IsNullOrEmpty(personalNo))
            {
                return BadRequest("New personal number is required.");
            }
            var username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("User is not authenticated.");
            }
            var result = _changeInfoBusinessLogic.ChangeUserData(username,"","", personalNo);
            if (result)
            {
                return Ok( "Personal number changed successfully." );
            }
            else
            {
                return BadRequest("Failed to change personal number.");
            }
        }


        [HttpPut("changeProfilePicture")]
        public IActionResult ChangeProfilePicture([FromForm] ImageLoadRequest request)
        {
            if (request == null || request.Image == null)
            {
                return BadRequest("New profile picture is required.");
            }
            var username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("User is not authenticated.");
            }
            var result = _changeInfoBusinessLogic.ChangeProfilePicture(username, request.Image);
            if (result)
            {
                return Ok("Profile picture changed successfully." );
            }
            else
            {
                return BadRequest("Failed to change profile picture." );
            }


        }




        [HttpPut("changeCity")]
        public IActionResult ChangeCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest("New city is required.");
            }
            var username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("User is not authenticated.");
            }
            var result = _changeInfoBusinessLogic.ChangeResidence(username, city);
            if (result)
            {
                return Ok("City changed successfully." );
            }
            else
            {
                return BadRequest( "Failed to change city.");
            }
        }
        [HttpPut("changeStreet")]
        public IActionResult ChangeStreet(string street)
        {
            if (string.IsNullOrEmpty(street))
            {
                return BadRequest("New street is required.");
            }
            var username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("User is not authenticated.");
            }
            var result = _changeInfoBusinessLogic.ChangeResidence(username, "" , street);
            if (result)
            {
                return Ok( "Street changed successfully." );
            }
            else
            {
                return BadRequest( "Failed to change street." );
            }
        }

        [HttpPut("changeHouseNumber")]
        public IActionResult ChangeHouseNumber(string houseNumber)
        {
            if (string.IsNullOrEmpty(houseNumber))
            {
                return BadRequest("New house number is required.");
            }
            var username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("User is not authenticated.");
            }
            var result = _changeInfoBusinessLogic.ChangeResidence(username, "","", houseNumber);
            if (result)
            {
                return Ok( "House number changed successfully." );
            }
            else
            {
                return BadRequest("Failed to change house number." );
            }
        }

        [HttpPut("changeApartmentNumber")]
        public IActionResult ChangeApartmentNumber(string apartmentNumber)
        {
            if (string.IsNullOrEmpty(apartmentNumber))
            {
                return BadRequest("New apartment number is required.");
            }
            var username = GetLoggedInUsername();
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("User is not authenticated.");
            }
            var result = _changeInfoBusinessLogic.ChangeResidence(username, "", "", "", apartmentNumber);
            if (result)
            {
                return Ok( "Apartment number changed successfully." );
            }
            else
            {
                return BadRequest("Failed to change apartment number.");
            }
        }





        private string GetLoggedInUsername()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        }


    }
}
