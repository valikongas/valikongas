namespace API_Nr7_Uzrasine.Object
{
    public class MessageUzrasine
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Picture> Picture { get; set; }

        public CategoryUzrasine Category { get; set; }
        // Constructor
        public MessageUzrasine()
        {
        }
    }
}
