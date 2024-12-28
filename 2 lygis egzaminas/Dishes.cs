using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public class Dishes:MenuItem
    {
        public static string Path = @"C:\Users\gedasvalikonis\Documents\GitHub\valikongas\2 lygis egzaminas\dishes.json";


        public static void DishesControlMenu()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("    Patiekalu valdymo MENIU");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1 - Prideti patiekala");
                Console.WriteLine("2 - Istrinti Patiekala");
                Console.WriteLine("3 - Perziureti patiekalu sarasa");
                Console.WriteLine("4 - Grizti atgal");
                ConsoleKeyInfo clickkey = Console.ReadKey();

                switch (clickkey.KeyChar)
                {
                    case '1':
                        MenuItemAdd<Dishes>(Dishes.Path);
                        break;
                    case '2':
                        MenuItemRemove<Dishes>(Dishes.Path);
                        break;

                    case '3':
                        DataOperation.ListView<Dishes>(Dishes.Path, "Patiekalu");
                        break;

                    case '4':
                        RestaurantProgramStartMenu.StartProgram();
                        break;

                }
            }
        }


    }
}
