

namespace Mongo_DB
{
    public class robot
    {
        public int Id { get; set; }
        public List<Arm> Arms {get;set; }
        public List<Leg> Legs { get; set; }
        public Torso Torsas { get; set; }
        public Head Head { get; set; }

    }
}
