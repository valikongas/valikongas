using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace _2_lygis_egzaminas
{
    public class Waiter
    {

        public string Path = @"C:\Users\gedasvalikonis\Documents\GitHub\valikongas\2 lygis egzaminas\padavejai.txt";
        public string Name { get; set; } = "";

        public string Password { get; set; } = "";

        public Waiter()
        {
            
        }

        public Waiter WaiterLogin()
        {
            
            var waiter= DataOperation.DataLoad<Waiter>(Path);
            bool isLoginTrue = false;
            while (!isLoginTrue)
            {
                string password = "";
                string name = WaiterInput(out password);

                foreach (var waiter1 in waiter)
                {
                    if (waiter1.Name == name && waiter1.Password == password)
                    {
                        return waiter1;
                    }
                }
                if (!isLoginTrue)
                {
                    Console.WriteLine("Neteisingai ivestas vardas arba slaptazodis");
                    Console.WriteLine("");
                    Console.WriteLine("Spausk bet koki mygtuka ir bandyk is naujo   arba   spausk '1' ir grizk i meniu");
                    if (Console.ReadKey().KeyChar == '1')
                    {
                        RestaurantProgramStartMenu.StartProgram();
                    }
                }
                Console.Clear();
            }
          return new Waiter(); 
        }


      
        public string WaiterInput(out string password )
        {
            Console.Clear();
            Console.Write("Iveskite vardą: ");

            string name = "";
            while (true)
            {
                name = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                    Console.WriteLine("Neivedei vardo! Ivesk is naujo");
                else
                    break;
            }
                name = name[0].ToString().ToUpper() + name.Substring(1);

            while (true)
            {
                Console.Write("Iveskite slaptazodi: ");
                password = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                    Console.WriteLine("Neivedei slaptazodzio! Ivesk is naujo");
                else
                    break;
            }
                return name;
        }


    }
}
