using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public static class WaiterControl
    {
        public static void WaiterControlMenu()
        {
            Waiter waiterx = new Waiter();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("    Padaveju valdymo MENIU");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1 - Prideti padaveja");
                Console.WriteLine("2 - Istrinti padaveja");
                Console.WriteLine("3 - Perziureti padaveju sarasa");
                Console.WriteLine("4 - Grizti atgal");
                ConsoleKeyInfo clickkey = Console.ReadKey();

                switch (clickkey.KeyChar)
                {
                    case '1':
                        WaiterAdd(waiterx);
                        break;
                    case '2':
                        WaiterRemove(waiterx);
                        break;

                    case '3':
                        DataOperation.ListView<Waiter>(waiterx.Path, "Padaveju");
                        break;

                    case '4':
                        RestaurantProgramStartMenu.StartProgram();
                        break;

                }
            }
        }
        public static void WaiterAdd(Waiter waiterx)
        {
            var waiters = DataOperation.DataLoad<Waiter>(waiterx.Path);
            string name = waiterx.WaiterInput(out string password);
            waiterx.Name = name;
            waiterx.Password = password;
            waiters.Add(waiterx);
            DataOperation.DataSave<Waiter>(waiters, waiterx.Path);
            Console.WriteLine("");
            Console.WriteLine("Padavejas pridetas");
            Console.WriteLine("");
            Console.WriteLine("Spausk bet koki mygtuka");
            Console.ReadKey();
        }

        public static void WaiterRemove(Waiter waiterx)
        {
            var waiters = DataOperation.DataLoad<Waiter>(waiterx.Path);
            string name = waiterx.WaiterInput(out string password);
            bool waiterfind = false;
            foreach (var waiter in waiters)
            {
                if (waiter.Name == name)
                {
                    waiters.Remove(waiter);
                    waiterfind = true;
                    DataOperation.DataSave<Waiter>(waiters,waiterx.Path);
                    Console.WriteLine("");
                    Console.WriteLine("Padavejas istrintas");
                    Console.WriteLine("");
                    Console.WriteLine("Spausk bet koki mygtuka");
                    Console.ReadKey();
                    break;
                }
            }
            if (!waiterfind)
            {
                Console.WriteLine("Toks padavejas nerastas !");
            }
        }
       

    }
}
