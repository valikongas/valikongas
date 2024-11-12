using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_1_pamoka_OOP
{
    internal class Adress
    {
        public string  City { get; set; }
        public string Street { get; set; }
        public int HouseNo { get; set; }
public Adress(string city, string street, int houseNo)
        {
        City = city;
        Street = street;
        HouseNo = houseNo;
        }
public Adress() { } 
    }
}
