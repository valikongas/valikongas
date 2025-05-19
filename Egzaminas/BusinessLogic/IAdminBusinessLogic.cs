namespace Egzaminas.BusinessLogic
{
    public interface IAdminBusinessLogic
    {
        public bool DeleteUser(int id);

        public bool IsIdInDatabase(int id);
        public bool IsAdmin(int id);

    }
}
