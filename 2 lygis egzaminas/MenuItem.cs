using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public MenuItem()
        {
                
        }

        public static void MenuItemAdd<T>(string path) where T : MenuItem, new()
        {
            T item = new T();
            var items = DataOperation.DataLoad<T>(path);
            string name = MenuItemInput(out decimal price);
            item.Name = name;
            item.Price = price;
            items.Add(item);
            DataOperation.DataSave<T>(items, path);
            Console.WriteLine("");
            Console.WriteLine($"{item.Name} pridetas");
            Console.WriteLine("");
            Console.WriteLine("Spausk bet koki mygtuka");
            Console.ReadKey();
        }

        public static void MenuItemRemove<T>(string path) where T: MenuItem, new()
        {
            T item =new T();
            var items = DataOperation.DataLoad<T>(path);
            string name = MenuItemInput(out decimal price);
            bool isItemFind = false;
            foreach (var i in items)
            {
                if (i.Name == name)
                {
                    items.Remove(i);
                    isItemFind = true;
                    DataOperation.DataSave<T>(items, path);
                    Console.WriteLine("");
                    Console.WriteLine($"{item.Name} istrintas");
                    Console.WriteLine("");
                    Console.WriteLine("Spausk bet koki mygtuka");
                    Console.ReadKey();
                    break;
                }
            }
            if (!isItemFind)
            {
                Console.WriteLine("Toks objektas nerastas !");
            }
        }

        public static string MenuItemInput(out decimal price)
        {
            Console.Clear();
            Console.Write("Iveskite pavadinima: ");

            string name = "";
            while (true)
            {
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                    Console.WriteLine("Neivedei pavadinimo! Ivesk is naujo");
                else
                    break;
            }
            name = name[0].ToString().ToUpper() + name.Substring(1);

            bool isDecimal = false;
            price = 0;
            while (!isDecimal)
            {
                Console.Write("Iveskite kaina: ");
                isDecimal =decimal.TryParse(Console.ReadLine(), out price);
                if (price<=0)
                    isDecimal = false;
                if(!isDecimal)
                    Console.WriteLine("Ivedei kaina neteisingai! Ivesk is naujo");
            }
            return name;
        }



    }
}
