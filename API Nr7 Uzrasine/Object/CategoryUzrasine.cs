namespace API_Nr7_Uzrasine.Object
{
    public class CategoryUzrasine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserUzrasine User { get; set; }
        public List<MessageUzrasine> Message { get; set; }
      
        public CategoryUzrasine()
        {
        }
    }
}
