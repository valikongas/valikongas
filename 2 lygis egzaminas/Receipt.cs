using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public class Receipt
    {   
        public Restorant Restorant { get; set; }
        public List<Dishes> Dishes { get; set; }
        public List<Drink> Drinks { get; set; }

        public decimal Sum { get; set; }

        public DateTime OrderCompleted { get; set; }
       
    }
}
