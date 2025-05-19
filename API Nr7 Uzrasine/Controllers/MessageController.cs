using API_Nr7_Uzrasine.BusinessLogic;
using API_Nr7_Uzrasine.Object;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API_Nr7_Uzrasine.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _messageService;
        private readonly CategoryService _categoryService;
        private readonly UserService _userService;

        public MessageController(MessageService messageService, CategoryService categoryService, UserService userService)
        {
            _messageService = messageService;
            _categoryService = categoryService;
            _userService = userService;
        }
        [HttpPost("create-message")]
        public IActionResult CreateMessage(string categoryName, string? messageContent = "", [FromForm] List<IFormFile>? pictures = null)
        {
            if ((string.IsNullOrWhiteSpace(messageContent) && (pictures == null || !pictures.Any())) || string.IsNullOrWhiteSpace(categoryName))
            {
                return BadRequest("Message content or category name cannot be empty.");
            }
            string userName = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(userName))
            {
                return Unauthorized("User not authenticated.");
            }

            List<CategoryUzrasine> categories = _categoryService.GetUserCategories(userName);
            if (categories == null || categories.Count == 0)
            {
                return BadRequest("No categories found for the user.");
            }

            if (!categories.Any(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest("Category does not exist.");
            }
            var user = _userService.FindUserName(userName);

            var result = _messageService.CreateMessage(messageContent, categoryName, user, pictures);

            if (result)
            {
                return Ok("Message create successfully.");
            }
            return StatusCode(500, "An error occurred while creating the message.");
        }
    }

    [HttpDelete("delete-message")]
        public IActionResult DeleteMessage(int messageId)
        {
            if (messageId <= 0)
            {
                return BadRequest("Invalid message ID.");
            }
            string userName = User.Identity?.Name;
            if (string.IsNullOrWhiteSpace(userName))
            {
                return Unauthorized("User not authenticated.");
            }
            var user = _userService.FindUserName(userName);
            if (user == null)
            {
                return Unauthorized("User not found.");
            }
            var result = _messageService.DeleteMessage(messageId, user);
            if (result)
            {
                return Ok("Message deleted successfully.");
            }
            return StatusCode(500, "An error occurred while deleting the message.");
        }

    }
}
