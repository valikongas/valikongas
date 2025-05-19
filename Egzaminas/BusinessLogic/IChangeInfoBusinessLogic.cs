using Egzaminas.Object;

namespace Egzaminas.BusinessLogic
{
    public interface IChangeInfoBusinessLogic
    {
        public bool ChangeUserData(string username, string firstName = "", string lastName = "",
            string personalNo = "", string phoneNumber = "", string mail = "");

       public  bool ChangeProfilePicture(string username, IFormFile profilePicture);

       public  bool ChangeResidence(string username, string city = "", string street = "",
            string houseNumber = "", string apartmentNumber = "");
      
    }
}