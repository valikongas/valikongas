using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    internal class ReceiptClient : Receipt
    {


        public ReceiptClient(Restorant restorant, List<Dishes> dishes, List<Drink> drink, decimal sum, DateTime orderCompleted)
        {
            Restorant = restorant;
            Dishes = dishes;
            Drinks = drink;
            Sum = sum;
            OrderCompleted = orderCompleted;
        }




    }
}
