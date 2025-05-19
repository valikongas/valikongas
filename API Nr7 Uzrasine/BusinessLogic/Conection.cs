using API_Nr7_Uzrasine.Data;
using API_Nr7_Uzrasine.Object;
using System.Security.Cryptography;

namespace API_Nr7_Uzrasine.BusinessLogic
{
    public class Conection
    {
        
            private readonly ApiDbContext _apiDbContext;

            public Conection(ApiDbContext apiDbContext)
            {
                _apiDbContext = apiDbContext;
            }

            // Method to create a new account

            public UserUzrasine SignupNewAccount(string name, string username, string password)
            {
                var account = CreateAccount(name, username, password);
                _apiDbContext.UsersUzrasine.Add(account);
                _apiDbContext.SaveChanges();
                return account;
            }

            private UserUzrasine CreateAccount(string name, string username, string password)
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                var account = new UserUzrasine
                {
                    Name = name,
                    Username = username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                return account;
            }

            private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            {
                using var hmac = new HMACSHA512();
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            // Method to login an account

            public bool Login(string username, string password)
            {
                var account = GetAccount(username);
                if (account == null)
                    return false;

                if (VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
                    return true;

                return false;
            }

            private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
            {
                using var hmac = new HMACSHA512(passwordSalt);
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }

            public UserUzrasine GetAccount(string username)
            {
                return _apiDbContext.UsersUzrasine.FirstOrDefault(x => x.Username == username);
            }

        public bool CheckIfUsernameExists(string username)
        {
            return _apiDbContext.UsersUzrasine.Any(x => x.Username == username);
        }








    }
}
