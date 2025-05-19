using Egzaminas.Data;
using Egzaminas.Object;
using System.Security.Cryptography;



namespace Egzaminas.BusinessLogic
{
    public class AuthBusinessLogic
    {
        private readonly ApiDbContext _apiDbContext;

        public AuthBusinessLogic(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

       

        public User SignupNewAccount(CreateAccountRequest request)
        {
            var account = CreateAccount(request.Username, request.Password);

            var userData = new UserData
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PersonalNo = request.PersonalNo,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                ProfilePicture = ConvertImageToByteArray(request.Picture.Image),
                User = account
            };

            var userResidence = new UserResidence
            {
                City = request.City,
                Street = request.Street,
                HouseNumber = request.HouseNumber,
                ApartmentNumber = request.ApartmentNumber,
                UserData = userData
            };

            userData.UserResidence = userResidence;
            account.UserData = userData;

            _apiDbContext.Users.Add(account);
            _apiDbContext.SaveChanges();

            return account;
        }

        public byte[] ConvertImageToByteArray(IFormFile image)
        {
            using var memoryStream = new MemoryStream();
            var resizedImage = ResizeImage(image);
            resizedImage.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        private IFormFile ResizeImage(IFormFile image)
        {
            using var imageStream = new MemoryStream();
            image.CopyTo(imageStream);
            imageStream.Position = 0; 
            using var originalImage = System.Drawing.Image.FromStream(imageStream);
            using var resizedImage = new System.Drawing.Bitmap(originalImage, new System.Drawing.Size(200, 200));
            var resizedStream = new MemoryStream();
            resizedImage.Save(resizedStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            resizedStream.Position = 0;
            return new FormFile(resizedStream, 0, resizedStream.Length, image.Name, image.FileName);
        }

        private User CreateAccount(string username, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var account = new User
            {
               
                Username = username,
                Password = passwordHash,
                Salt = passwordSalt,
                Role="User"
            };
            return account;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

       //Method to login an account

        public bool Login(string username, string password, out string role)
        {
            role = "";
            var account = GetAccount(username);
          
            if (account == null)
                return false;

            if (VerifyPasswordHash(password, account.Password, account.Salt))
            {
                role = account.Role;
                return true;
            }
            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        public User GetAccount(string username)
        {
            return _apiDbContext.Users.FirstOrDefault(x => x.Username == username);
        }

        public bool CheckIfUsernameExists(string username)
        {
            return _apiDbContext.Users.Any(x => x.Username == username);
        }



      
    }
}
