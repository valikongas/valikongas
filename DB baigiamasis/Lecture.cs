

namespace DB_baigiamasis
{
    public class Lecture
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Departament>? Departaments { get; set; }=new List<Departament>();
        public List<Student>? Students { get; set; }=new List<Student>();

        
        public Lecture()
        {
            
        }
    }
}
