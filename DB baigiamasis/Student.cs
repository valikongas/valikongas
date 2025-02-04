

namespace DB_baigiamasis
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birdday { get; set; }
        public List<Lecture>? Lectures { get; set; }=new List<Lecture>();   
        public int? DepartamentId { get; set; }
        public Departament? Departament { get; set; }

        public Student()
        {
            
        }
    }
}
