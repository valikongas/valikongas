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
        public string WaiterName { get; set; } = "";
        public DateTime OrderStart { get; set; }
        public int TableNumber {  get; set; }

        public ReceiptRestorant()
        {
            
        }



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

        public static string RestorantReceiptText(ReceiptRestorant receiptRestorant)
        {
            string text = "";
           TimeSpan time = (receiptRestorant.OrderCompleted - receiptRestorant.OrderStart);
            string text2 = time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString();
            text = text + $"{receiptRestorant.Restorant.Name}\n" +
            $"Im. k. {receiptRestorant.Restorant.Code}\n" +
            $"PVM moketojo kodas {receiptRestorant.Restorant.VATCode}\n" +
            $"{receiptRestorant.Restorant.Adress}\n\n" +
            $"Data: {receiptRestorant.OrderCompleted}\n\n" +

            "            Kvitas\n\n";
            foreach (var item in receiptRestorant.Dishes)
            {
                text = text + $"   {item.Name}\t\t{item.Price}\n";
            }
            foreach (var item in receiptRestorant.Drinks)
            {
                text = text + $"   {item.Name}\t{item.Price}\n";
            }
            text = text + "----------------------------------------\n" +
            $"                 Suma:  {receiptRestorant.Sum}\n\n\n"+          
            $"Praleistas laikas prie stalo: {text2}\n" +
            $"Stalo numeris: {receiptRestorant.TableNumber}\n" +
            $"Aptarnavo: {receiptRestorant.WaiterName}";
            return text;
        }

    }   
}
