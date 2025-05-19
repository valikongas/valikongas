using API_Nr7_Uzrasine.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Nr7_Uzrasine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UzrasineController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly UserService _userService;

        public UzrasineController(CategoryService categoryService, UserService userService)
        {
            _categoryService = categoryService;
            _userService = userService;
        }

        [HttpPost("create-category")]
        public IActionResult CreateCategory([FromBody] string categoryName)


        {

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                return BadRequest("Category name cannot be empty.");
            }

            string user = User.Identity?.Name;

            if (string.IsNullOrWhiteSpace(user))
            {
                return Unauthorized("User not authenticated.");
            }

            var foundUser = _userService.FindUserName(user);
            if (foundUser == null)
            {
                return Unauthorized("User not found.");
            }

            if (_categoryService.CategoryExists(categoryName, foundUser))
            {
                return BadRequest("Category already exists.");
            }


            var result = _categoryService.CreateCategory(categoryName, foundUser);

            if (result)
            {
                return Ok("Category created successfully.");
            }

            return StatusCode(500, "An error occurred while creating the category.");
        }

        [HttpDelete("delete-category/{categoryName}")]
        public IActionResult DeleteCategory(string categoryName)
        {
            string user = User.Identity?.Name;

            if (string.IsNullOrWhiteSpace(user))
            {
                return Unauthorized("User not authenticated.");
            }

            var foundUser = _userService.FindUserName(user);
            if (foundUser == null)
            {
                return Unauthorized("User not found.");
            }

            var categoryExists = _categoryService.CategoryExists(categoryName, foundUser);
            if (!categoryExists)
            {
                return NotFound("Category not found.");
            }


            if (_categoryService.DeleteCategory(categoryName, foundUser))
                return Ok("Category deleted successfully.");
            else
                return StatusCode(500, "An error occurred while deleting the category.");

        }

        [HttpPut("update-category-name/{oldCategoryName}")]
        public IActionResult UpdateCategoryName(string oldCategoryName, [FromBody] string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                return BadRequest("New category name cannot be empty.");
            }


            string user = User.Identity?.Name;

            if (string.IsNullOrWhiteSpace(user))
            {
                return Unauthorized("User not authenticated.");
            }

            var foundUser = _userService.FindUserName(user);
            if (foundUser == null)
            {
                return Unauthorized("User not found.");
            }

            var categoryExists = _categoryService.CategoryExists(newName, foundUser);
            if (categoryExists)
            {
                return BadRequest("A category with the new name already exists.");
            }

            if (_categoryService.UpdateCategoryName(oldCategoryName, newName, foundUser))
                return Ok("Category name update successfully.");
            else
                return StatusCode(500, "An error occurred while updating the category name.");

        }
    }




}

