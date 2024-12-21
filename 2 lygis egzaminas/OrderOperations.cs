using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public static class OrderOperations
    {
        public static void OrderSum(Order order)
        {
            decimal sum = 0;
            foreach (Dishes dishes in order.OrderedDishes)
            {
                sum = sum + dishes.Price;
            }
            foreach (Drink drink in order.OrderedDrinks)
            {
                sum = sum + drink.Price;
            }
            order.Sum = sum;
        }

        
        public static void NewOrder(string waiterName)
        {
            bool isAllTableOccupied = true;
            for (int i = 0; i < 10; i++)
            {
                if (!Table.Tables[i].IsOccupied)
                {
                    isAllTableOccupied = false;
                    break;
                }
            }
            if (isAllTableOccupied)
            {
                Console.WriteLine("Visi staliukai uzimti. Klientu nera kur pasodinti.");
            }
            else
            {
                TableOperation.TableView(false);
                Console.WriteLine();
                Console.Write("Pasirinkite prie kurio staliuko sodinsite zmones: ");
                int tableNumber = 0;
                while (!(int.TryParse(Console.ReadLine(), out tableNumber) && tableNumber > 0 && tableNumber < 11 && !Table.Tables[tableNumber-1].IsOccupied));

                Order order = new Order();
                order.WaiterName= waiterName;
                order.OrderReceived=DateTime.Now;
                

                
                DataOperation.ListView<Dishes>(Dishes.Path, "patiekalu", true);
                Console.WriteLine();
                bool isEndOrder = false;
                int numberDishes = 0;
                List<Dishes> dishes = DataOperation.DataLoad<Dishes>(Dishes.Path);
                while(!isEndOrder)
                {
                    Console.WriteLine("Pasirinkite uzsakomo patiekalo numeri,  jei uzsakymas baigtas spausk '0'");
                    while (!(int.TryParse(Console.ReadLine(), out numberDishes) && numberDishes >= 0 && numberDishes <= dishes.Count));
                    if (numberDishes == 0)
                    {
                        isEndOrder=true;
                    }
                    else
                    {
                        order.OrderedDishes.Add(dishes[numberDishes - 1]);
                    }

                }
                
                DataOperation.ListView<Drink>(Drink.Path, "gerimu", true);
                Console.WriteLine();
                isEndOrder = false;
                int numberDrink = 0;
                List<Drink> drink = DataOperation.DataLoad<Drink>(Drink.Path);
                while (!isEndOrder)
                {
                    Console.WriteLine("Pasirinkite uzsakomo gerimo numeri,  jei uzsakymas baigtas spausk '0'");
                    while (!(int.TryParse(Console.ReadLine(), out numberDrink) && numberDrink >= 0 && numberDrink <= drink.Count)) ;
                    if (numberDrink == 0)
                    {
                        isEndOrder = true;
                    }
                    else
                    {
                        order.OrderedDrinks.Add(drink[numberDrink - 1]);
                    }
                }
                OrderSum(order);
                    Table.Tables[tableNumber-1].TableOrder= order;
                    Table.Tables[tableNumber-1].IsOccupied= true;
            }


        }

        public static void AddOrder(string waiterName)
        {

            TableOperation.TableView(false, true);
            Console.WriteLine();
            Console.Write("Pasirinkite prie kurio staliuko nori zmones uzsisakyti papildomai: ");
            int tableNumber = 0;
            while (!(int.TryParse(Console.ReadLine(), out tableNumber) && tableNumber > 0 && tableNumber < 11 && Table.Tables[tableNumber - 1].IsOccupied)) ;

            Order order = Table.Tables[tableNumber-1].TableOrder;

            DataOperation.ListView<Dishes>(Dishes.Path, "patiekalu", true);
            Console.WriteLine();
            bool isEndOrder = false;
            int numberDishes = 0;
            List<Dishes> dishes = DataOperation.DataLoad<Dishes>(Dishes.Path);
            while (!isEndOrder)
            {
                Console.WriteLine("Pasirinkite uzsakomo patiekalo numeri,  jei uzsakymas baigtas spausk '0'");
                while (!(int.TryParse(Console.ReadLine(), out numberDishes) && numberDishes >= 0 && numberDishes <= dishes.Count)) ;
                if (numberDishes == 0)
                {
                    isEndOrder = true;
                }
                else
                {
                    order.OrderedDishes.Add(dishes[numberDishes - 1]);
                }

            }

            DataOperation.ListView<Drink>(Drink.Path, "gerimu", true);
            Console.WriteLine();
            isEndOrder = false;
            int numberDrink = 0;
            List<Drink> drink = DataOperation.DataLoad<Drink>(Drink.Path);
            while (!isEndOrder)
            {
                Console.WriteLine("Pasirinkite uzsakomo gerimo numeri,  jei uzsakymas baigtas spausk '0'");
                while (!(int.TryParse(Console.ReadLine(), out numberDrink) && numberDrink >= 0 && numberDrink <= drink.Count)) ;
                if (numberDrink == 0)
                {
                    isEndOrder = true;
                }
                else
                {
                    order.OrderedDrinks.Add(drink[numberDrink - 1]);
                }
            }
            OrderSum(order);
            Table.Tables[tableNumber - 1].TableOrder = order;
  
        }

        internal static void OrderEnd(string waiterName)
        {
            TableOperation.TableView(false, true);
            Console.WriteLine();
            Console.Write("Pasirinkite kuris staliukas nori atsiskaityti: ");
            int tableNumber = 0;
            while (!(int.TryParse(Console.ReadLine(), out tableNumber) && tableNumber > 0 && tableNumber < 11 && Table.Tables[tableNumber - 1].IsOccupied)) ;

            Order order = Table.Tables[tableNumber - 1].TableOrder;
            order.OrderCompleted=DateTime.Now;

            ReceiptClient receiptClient = new ReceiptClient(Restorant.restoranas1, order.OrderedDishes, order.OrderedDrinks, order.Sum, order.OrderCompleted);
            ReceiptRestorant receiptRestorant = new ReceiptRestorant(Restorant.restoranas1, order.OrderedDishes, order.OrderedDrinks, order.Sum, order.OrderCompleted, order.OrderReceived, order.WaiterName, tableNumber);

            Console.WriteLine();
            Console.WriteLine("Ar klientui reikalingas cekis Y/N");
            char key;
            bool isYOrN=false;
            do
            {
                key = Console.ReadKey().KeyChar;
                if (key =='y' || key=='N')
                {
                    isYOrN = true;
                }
            }
            while (!isYOrN);

            if(key=='y')
            {
                Console.Clear();
                Console.WriteLine($"{receiptClient.Restorant.Name}");
                Console.WriteLine($"Im. k. {receiptClient.Restorant.Code}");
                Console.WriteLine($"PVM moketojo kodas {receiptClient.Restorant.VATCode}");
                Console.WriteLine($"{receiptClient.Restorant.Adress}");
                Console.WriteLine();
                Console.WriteLine($"Data: {receiptClient.OrderCompleted}");
                Console.WriteLine();
                Console.WriteLine( "            Kvitas");
                Console.WriteLine();
                foreach(var item in receiptClient.Dishes)
                {
                    Console.WriteLine($"   {item.Name}\t\t{item.Price}");
                }
                foreach(var item in receiptClient.Drinks)
                {
                    Console.WriteLine($"   {item.Name}\t{item.Price}");
                }
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"                 Suma:  {receiptClient.Sum}");
            }

            List<ReceiptRestorant> receiptRestorants = DataOperation.DataLoad<ReceiptRestorant>(ReceiptRestorant.Path);
            receiptRestorants.Add( receiptRestorant );
            DataOperation.DataSave<ReceiptRestorant>(receiptRestorants, ReceiptRestorant.Path);

           

            //cekiu siuntimas mailu








            Table.Tables[tableNumber - 1].TableOrder = new Order();
            Table.Tables[tableNumber - 1].IsOccupied=false;

        }
    }

    
}
