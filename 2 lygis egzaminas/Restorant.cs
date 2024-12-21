using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public class Restorant
    {
        public static Restorant restoranas1 { get; private set; } = new Restorant();
        public string Name { get; set; }
        public string Code { get; set; }
        public string VATCode {  get; set; }
        public string Adress {  get; set; }

        public Restorant() 
        {
            Name = "Geriausias restoranas";
            Code = "123123123";
            VATCode = "LT123123123";
            Adress = "Pilies g. 54, Vilnius";
        }
    }
}
