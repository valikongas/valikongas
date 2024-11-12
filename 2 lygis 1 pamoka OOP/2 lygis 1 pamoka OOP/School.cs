using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_1_pamoka_OOP
{
    internal class School
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int MokiniuSkaicius { get; set; }
        public School(string name, int mokiniuskaicius):this( mokiniuskaicius)
        {
            Name = name;
        }

        public School(int mokiniuskaicius) 
        {
            MokiniuSkaicius = mokiniuskaicius;
        }
       
        public School(string name)
        {
            Name = name;
        }

    }

}
