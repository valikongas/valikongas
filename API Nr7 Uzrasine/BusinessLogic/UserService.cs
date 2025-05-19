using API_Nr7_Uzrasine.Data;
using API_Nr7_Uzrasine.Object;

namespace API_Nr7_Uzrasine.BusinessLogic
{
    public class UserService
    {
        private readonly ApiDbContext _apiDbContext;
        public UserService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        public UserUzrasine FindUserName(string username)
        {
            var user = _apiDbContext.UsersUzrasine.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
       
    }
}
