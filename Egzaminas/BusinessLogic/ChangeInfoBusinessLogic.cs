
using Egzaminas.Data;
using Egzaminas.Object;
using Microsoft.EntityFrameworkCore;

namespace Egzaminas.BusinessLogic
{
    public class ChangeInfoBusinessLogic : IChangeInfoBusinessLogic
    {
        private readonly ApiDbContext _apiDbContext;
        private readonly AuthBusinessLogic _authBusinessLogic;
        public ChangeInfoBusinessLogic(ApiDbContext  apiDbContext, AuthBusinessLogic authBusinessLogic)
        {
            _apiDbContext = apiDbContext;
            _authBusinessLogic = authBusinessLogic;
        }

        public bool ChangeUserData(string username, string firstName="", string lastName="",
            string personalNo="", string phoneNumber="", string mail="")
        {


            var user = GetUserData(username);
            if (user != null)
            {
                if(firstName != "")
                {
                    user.UserData.FirstName = firstName;
                }
                if (lastName != "")
                {
                    user.UserData.LastName = lastName;
                }
                if (personalNo != "")
                {
                    user.UserData.PersonalNo = personalNo;
                }
                if (phoneNumber != "")
                {
                    user.UserData.PhoneNumber = phoneNumber;
                }
                if (mail != "")
                {
                    user.UserData.Email = mail;
                }
                _apiDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ChangeProfilePicture(string username, IFormFile profilePicture)
        {
            var user = GetUserData(username);
            if (user != null && user.UserData != null)
            {
                var newProfilePicture = _authBusinessLogic.ConvertImageToByteArray(profilePicture);
                user.UserData.ProfilePicture = newProfilePicture;
                _apiDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ChangeResidence(string username, string city="", string street="", string houseNumber="", string apartmentNumber="")
        {
            var user = GetUserData(username);
            if (user != null)
            {
                if(city!="")
                {
                    user.UserData.UserResidence.City = city;
                }
                if (street != "")
                {
                    user.UserData.UserResidence.Street = street;
                }
                if (houseNumber != "")
                {
                    user.UserData.UserResidence.HouseNumber = houseNumber;
                }
                if (apartmentNumber != "")
                {
                    user.UserData.UserResidence.ApartmentNumber = apartmentNumber;
                }
                              
                _apiDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        private User GetUserData (string username)
        {
           return _apiDbContext.Users.Include(u => u.UserData).ThenInclude(ud => ud.UserResidence).FirstOrDefault(u => u.Username == username);
        }















    }
}
