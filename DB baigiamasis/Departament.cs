

namespace DB_baigiamasis
{
    public class Departament
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Student>? Students { get; set; }=new List<Student>();
        public List<Lecture>? Lectures { get; set; } = new List<Lecture>();


        public Departament()
        {
            
        }


    }
}
