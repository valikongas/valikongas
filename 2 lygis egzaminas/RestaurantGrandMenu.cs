using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public static class RestaurantGrandMenu
    {
        public static void Menu ()
        {
            
            Waiter waiter1 = new Waiter();
            waiter1=waiter1.WaiterLogin();
            if (waiter1 == null)
            {
                RestaurantProgramStartMenu.StartProgram();
                
            }

            while (true)
            {
                Console.Clear();

         //      var name = waiter1.Name ?? string.Empty; 
         //     var name = waiter1.Name == null ? string.Empty : waiter1.Name; 
                Console.WriteLine($"        MENIU          padavejas: {waiter1.Name}");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("1 - Pasodinti zmones prie staliuko ir priimati uzsakyma");
                Console.WriteLine("2 - Papildyti uzsakyma");
                Console.WriteLine("3 - Perziureti staliukus");
                Console.WriteLine("4 - Uzbaigti uzsakyma");
                Console.WriteLine("5 - Grizti atgal");
                ConsoleKeyInfo clickkey = Console.ReadKey();

                switch (clickkey.KeyChar)
                {
                    case '1':
                        OrderOperations.NewOrder(waiter1.Name);
                        break;
                    case '2':
                        OrderOperations.AddOrder(waiter1.Name);
                        break;

                    case '3':
                        TableOperation.TableView();
                        break;

                    case '4':
                        OrderOperations.OrderEnd(waiter1.Name);
                        break;
                    case '5':
                        RestaurantProgramStartMenu.StartProgram();
                        break;

                }

            }
        }
    }
}
