namespace API_Nr._1.Kodas
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public Book(int id, string name, string title)
        {
            Id = id;
            Name = name;
            Title = title;
            
        }
    }
}
