namespace API_Nr7_Uzrasine.Object
{
    public class UserUzrasine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<CategoryUzrasine> Category { get; set; }

        // Constructor
        public UserUzrasine()
        {
        }
    }
}
