using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public class Order
    {

        public string WaiterName { get; set; }
        public List<Dishes> OrderedDishes { get; set; }=new List<Dishes>();
        public List<Drink> OrderedDrinks { get; set; }= new List<Drink>();
        public decimal Sum { get; set; }
        public DateTime OrderReceived { get; set; }
        public DateTime OrderCompleted { get; set; }


        public Order()

        {

        }




    }
}
