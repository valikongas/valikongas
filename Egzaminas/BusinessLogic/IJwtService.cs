namespace Egzaminas.BusinessLogic
{
    
        public interface IJwtService
        {
            string GetJwtToken(string username, string role);
        }
   
}
