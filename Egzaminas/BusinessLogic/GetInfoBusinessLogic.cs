using Egzaminas.Data;
using Egzaminas.Object;
using Microsoft.EntityFrameworkCore;

namespace Egzaminas.BusinessLogic
{
    public class GetInfoBusinessLogic
    {
        private readonly ApiDbContext _apiDbContext;
        public GetInfoBusinessLogic( ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public GetUserDataRequest GetInfo(string username)
        {
            var user = _apiDbContext.Users.Include(u => u.UserData).ThenInclude(ud => ud.UserResidence).FirstOrDefault(u => u.Username == username);
            GetUserDataRequest getUserDataRequest = new GetUserDataRequest();
            if (user != null)
            {

                getUserDataRequest.FirstName = user.UserData.FirstName;
                getUserDataRequest.LastName = user.UserData.LastName;
                getUserDataRequest.PersonalNo = user.UserData.PersonalNo;
                getUserDataRequest.PhoneNumber = user.UserData.PhoneNumber;
                getUserDataRequest.Email = user.UserData.Email;
                getUserDataRequest.City = user.UserData.UserResidence.City;
                getUserDataRequest.Street = user.UserData.UserResidence.Street;
                getUserDataRequest.HouseNumber = user.UserData.UserResidence.HouseNumber;
                getUserDataRequest.ApartmentNumber = user.UserData.UserResidence.ApartmentNumber;
                getUserDataRequest.Picture = user.UserData.ProfilePicture;
                return getUserDataRequest ;
            }
            return null;

        }
    }
}
