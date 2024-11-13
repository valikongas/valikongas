using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_2_pamoka_Metodai_klasese
{
    internal class Number
    {
        public List<int> numbers { get; set; } = new List<int>();

       

        public void AddNumber(int number)
        {
            numbers.Add(number);
        }

        public void PrintNumbers()
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }

}
