using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_11_paskaita_Extension
{
    internal static class Extension
    {
        public static bool IsPositiv(this int number)
        {
            return number > 0 ? true : false;
        }
        public static bool IsEven(this int number)
        {
            return number % 2 == 0 ? true : false;
        }
        public static bool IsBiger(this int number, int number2)
        {
            return number2 > number ? true : false;
        }

        public static bool IsSpace(this string text)
        {
            return text.IndexOf(' ') > -1 ? true : false;
        }

        public static string MailName(this string fullname, int yearOfBirdt, string domain)
        {
            return String.Concat(fullname, yearOfBirdt.ToString(), "@", domain);
        }

        public static T FindAndReturnIfEqual<T>(this List<T> obj, T obj2)
        {

            foreach (T item in obj)
            {
                if (Equals(item, obj2))
                    return item;
            }
            return default;
        }
        public static List<T> EveryOtherWord<T>(this List<T> obj)
        {
            List<T> list = new List<T>();
            int i = 0;
            foreach (T item in obj)
            {
                if (i == 0)
                {
                    list.Add(item);
                    i++;
                }
                else
                    i--;

            }
            return list;
        }
        public static List<string> Failu(this StreamReader file)
        {
            List<string> list = new List<string>();
            string line="";
            int i = 1;
            while ((line = file.ReadLine()) != null)
            {
                if (i % 2 != 0)
                { 
                list.Add(line);
                }
                i++;
            }
            return list;
        }






    }
}
