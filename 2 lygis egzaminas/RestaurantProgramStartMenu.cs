using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public class RestaurantProgramStartMenu
    {
      
       


        public static void StartProgram()
        {
           while (true)
            { 
            Console.Clear();
            Console.WriteLine("    Startinis MENIU");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.WriteLine("1 - Prisijungti padavejui");
            Console.WriteLine("2 - Valdyti padavejus");
            Console.WriteLine("3 - Valdyti patiekalus");
            Console.WriteLine("4 - Valdyti gerimus");
            Console.WriteLine("5 - Iseiti");
          
            
                ConsoleKeyInfo clickkey = Console.ReadKey();

                switch (clickkey.KeyChar)
                {
                    case '1':
                        RestaurantGrandMenu.Menu();
                        break;
                    case '2':
                        WaiterControl.WaiterControlMenu();
                        break;

                    case '3':
                        Dishes.DishesControlMenu();
                        break;

                    case '4':
                        Drink.DrinkControlMenu();
                        break;

                    case '5':
                        Environment.Exit(0);
                        break;
                }
                Console.Clear();
            }


            
        

        }
        

    }
}
