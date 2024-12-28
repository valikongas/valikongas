using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public class Receipt
    {
        public Restorant Restorant { get; set; }= new Restorant();
        public List<Dishes> Dishes { get; set; }=new List<Dishes>();
        public List<Drink> Drinks { get; set; }=new List<Drink>();

        public decimal Sum { get; set; }

        public DateTime OrderCompleted { get; set; }

        public static void PrintClientReceipt(ReceiptClient receiptClient)
        {

        }
    }
}
