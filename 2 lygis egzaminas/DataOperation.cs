using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public static class DataOperation
    {
        public static void DataSave<T>(List<T> list, string path)
        {
            string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public static List<T> DataLoad<T>(string path)
        {
            string json = File.ReadAllText(path);
            var list = JsonSerializer.Deserialize<List<T>>(json);
            if (list == null)
            {
                list = new List<T>();
            }
            return list;
        }

        public static void ListView<T>(string path, string name, bool isOrder=false)
        {
            var list = DataOperation.DataLoad<T>(path);
            

            Console.Clear();
            Console.WriteLine($"    {name} sarasas   ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            int index = 1;
            foreach (var element in list)
            {
                if(element==null)
                    continue;

                var prop=element.GetType().GetProperties();
                Console.WriteLine($"{index}\t{prop[0].GetValue(element)}\t\t {prop[1].Name.ToLower()} {prop[1].GetValue(element)}");
                index++;
            }
            if (!isOrder)
            {
                Console.WriteLine("");
                Console.WriteLine("Spausk bet koki mygtuka");
                Console.ReadKey();
            }
        }

    }
}
