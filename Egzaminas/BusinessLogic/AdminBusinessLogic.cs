using Egzaminas.Data;

namespace Egzaminas.BusinessLogic
{
    public class AdminBusinessLogic : IAdminBusinessLogic
    {

        private readonly ApiDbContext _apiDbContext;
     
        public AdminBusinessLogic(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }



        public bool DeleteUser(int id)
        {
            var user = _apiDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _apiDbContext.Users.Remove(user);
                _apiDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool IsIdInDatabase(int id)
        {
            var user = _apiDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public bool IsAdmin(int id)
        {
            var user = _apiDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user.Role == "Admin")
            {
                return true;
            }
            return false;
        }
    }
}
