
using Moq;
using Egzaminas.BusinessLogic;
using Egzaminas.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    public class TestProject1
    {
        [Fact]
        public void AdminControlerIsBadRequestWhileIdNeogation()
        {
                // Arrange
                int invalidId = -5;
                var mockLogic = new Mock<AdminBusinessLogic>(null); 
                var controller = new AdminController(mockLogic.Object);
                // Act
                var result = controller.DeleteUser(invalidId);
                // Assert
                var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal("Invalid user ID.", badRequestResult.Value);
        }

        [Fact]
        public void DeleteUser_UserIdDoesNotExist_ReturnsBadRequest()
        {
            // Arrange  
            int userId = 5;
            var mockAdminBusinessLogic = new Mock<IAdminBusinessLogic>();
            mockAdminBusinessLogic.Setup(x => x.IsIdInDatabase(It.IsAny<int>())).Returns(false);
            var controller = new AdminController(mockAdminBusinessLogic.Object);

            // Act  
            var result = controller.DeleteUser(userId);

            // Assert  
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("User ID does not exist.", badRequestResult.Value);
        }

        [Fact]
        public void DeleteUser_UserIdIsAdmin_ReturnsBadRequest()
        {
            // Arrange  
            int userId = 5;
            var mockAdminBusinessLogic = new Mock<IAdminBusinessLogic>();
            mockAdminBusinessLogic.Setup(x => x.IsIdInDatabase(It.IsAny<int>())).Returns(true);
            mockAdminBusinessLogic.Setup(x => x.IsAdmin(It.IsAny<int>())).Returns(true);
            var controller = new AdminController(mockAdminBusinessLogic.Object);

            // Act  
            var result = controller.DeleteUser(userId);

            // Assert  
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Administrator account cannot be deleted.", badRequestResult.Value);
        }

        [Fact]
        public void DeleteUser_IsNotOk()
        {
            // Arrange  
            int userId = 5;
            var mockAdminBusinessLogic = new Mock<IAdminBusinessLogic>();
            mockAdminBusinessLogic.Setup(x => x.IsIdInDatabase(It.IsAny<int>())).Returns(true);
            mockAdminBusinessLogic.Setup(x => x.IsAdmin(It.IsAny<int>())).Returns(false);
            mockAdminBusinessLogic.Setup(x => x.DeleteUser(It.IsAny<int>())).Returns(false);
            var controller = new AdminController(mockAdminBusinessLogic.Object);

            // Act  
            var result = controller.DeleteUser(userId);

            // Assert  
          
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Failed to delete user." ,badRequestResult.Value );
        }

        [Fact]
        public void DeleteUser_IsOk()
        {
            // Arrange  
            int userId = 5;
            var mockAdminBusinessLogic = new Mock<IAdminBusinessLogic>();
            mockAdminBusinessLogic.Setup(x => x.IsIdInDatabase(It.IsAny<int>())).Returns(true);
            mockAdminBusinessLogic.Setup(x => x.IsAdmin(It.IsAny<int>())).Returns(false);
            mockAdminBusinessLogic.Setup(x => x.DeleteUser(It.IsAny<int>())).Returns(true);
            var controller = new AdminController(mockAdminBusinessLogic.Object);

            // Act  
            var result = controller.DeleteUser(userId);

            // Assert  

            var okRequestResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("User deleted successfully.", okRequestResult.Value);
        }





    }
}
