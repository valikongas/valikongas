using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public class Drink:MenuItem
    {
        public static string Path = @"C:\Users\gedasvalikonis\Documents\GitHub\valikongas\2 lygis egzaminas\drink.json";

        public static void DrinkControlMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("    Gerimu valdymo MENIU");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1 - Prideti gerima");
                Console.WriteLine("2 - Istrinti gerima");
                Console.WriteLine("3 - Perziureti gerimu sarasa");
                Console.WriteLine("4 - Grizti atgal");
                ConsoleKeyInfo clickkey = Console.ReadKey();

                switch (clickkey.KeyChar)
                {
                    case '1':
                        MenuItemAdd<Drink>(Drink.Path);
                        break;
                    case '2':
                        MenuItemRemove<Drink>(Drink.Path);
                        break;

                    case '3':
                        DataOperation.ListView<Drink>(Drink.Path, "gerimu");
                        break;

                    case '4':
                        RestaurantProgramStartMenu.StartProgram();
                        break;

                }
            }
        }
    }
}
