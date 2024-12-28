using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public class ReceiptClient : Receipt
    {

        public ReceiptClient()
        {
            
        }
        public ReceiptClient(Restorant restorant, List<Dishes> dishes, List<Drink> drink, decimal sum, DateTime orderCompleted)
        {
            Restorant = restorant;
            Dishes = dishes;
            Drinks = drink;
            Sum = sum;
            OrderCompleted = orderCompleted;
        }

        public static string ClientReceiptText (ReceiptClient receiptClient)
        {
            string text = "";

            text = text + $"{receiptClient.Restorant.Name}\n" +
            $"Im. k. {receiptClient.Restorant.Code}\n" +
            $"PVM moketojo kodas {receiptClient.Restorant.VATCode}\n" +
            $"{receiptClient.Restorant.Adress}\n\n" +
            $"Data: {receiptClient.OrderCompleted}\n\n" +
            "            Kvitas\n\n";
            foreach (var item in receiptClient.Dishes)
            {
                text=text+$"   {item.Name}\t\t{item.Price}\n";
            }
            foreach (var item in receiptClient.Drinks)
            {
                text=text+$"   {item.Name}\t{item.Price}\n";
            }
            text=text+"----------------------------------------\n"+
            $"                 Suma:  {receiptClient.Sum}\n\n";

            return text;
        }


    }
}
