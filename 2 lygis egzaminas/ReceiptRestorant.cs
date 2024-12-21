using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public class ReceiptRestorant:Receipt
    {
        public static string Path = @"C:\Users\gedasvalikonis\Documents\GitHub\valikongas\2 lygis egzaminas\ReceiptRestorant.json";
        public string WaiterName { get; set; }
        public DateTime OrderStart { get; set; }
        public int TableNumber {  get; set; }

    
        
        public ReceiptRestorant(Restorant restorant, List<Dishes> dishes, List<Drink> drink, decimal sum, DateTime orderCompleted, DateTime orderStart, string waiterName, int tablenumber)
        { 
            Restorant = restorant;
            Dishes = dishes;
            Drinks = drink;
            Sum = sum;
            OrderCompleted = orderCompleted;
            OrderStart = orderStart;
            WaiterName = waiterName;
            TableNumber = tablenumber;
        }
    }   
}
