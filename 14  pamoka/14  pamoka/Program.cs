using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace _14__pamoka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <string> sarasas = new List<string> { "4", "5", "pirmas", "tomas", "antanas", "kaunas", "vilnius"};
            
            PrintList(sarasas);

            List<int> numbers = new List<int>();
            UzpildymasSkaiciais(numbers);
            SkaiciuVidurkis (numbers);
            Skaiciaididesninei10(numbers);
            Raidziusuma(sarasas);
            Pirminiai(sarasas);

        }





        static void PrintList(List<string> sarasas)
        {
            foreach (string s in sarasas)
            {
                Console.WriteLine(s + "- ilgis: " + s.Length);
            }

        }

        static void UzpildymasSkaiciais(List<int> numbers)
        { 
        for(int i=0;i<=50;i++)
            {
                numbers.Add(i);
            }
        
        }

        static void SkaiciuVidurkis(List<int> numbers)
        {
            Console.WriteLine("Skaiciu vidurkis yra: "+numbers.Average());
        }

        static void Skaiciaididesninei10(List<int> numbers)
        {
            numbers.Add (0);
            for (int i=numbers.Count-1;i>=0;i--)
            {
                
                if (numbers[i] <= 10)
                { numbers.Remove(numbers[i]);
                                        
                }
            }
            foreach (int i in numbers)
                Console.WriteLine(i);
        
        }


        static void Raidziusuma(List<string> sarasas )
        {
             List<string> naujassarasas= new List<string>();
            foreach (string i in sarasas)
            {
                int suma = 0;
                foreach (char s in i)
                {
                    suma=suma+(int)s;
                }
               

                if (suma%2==0)
                        naujassarasas.Add(i);
            }

            foreach(string i in naujassarasas)
            { Console.WriteLine(i); }

        }

        static void Pirminiai(List<string> sarasas)
        {
            List<string> naujassarasas1 = new List<string>();
            foreach (string i in sarasas)
            {
                int suma = 0;
                foreach (char s in i)
                {
                    suma = suma + (int)s;
                }
                Console.WriteLine(suma);
                bool isGeras = true;
                for (int j = 2; j < suma - 1; j++)
                {
                    if (suma % j == 0)
                    {
                        isGeras = false;
                        break;
                    }

                }
                if (isGeras)
                    naujassarasas1.Add(i);
            }
                foreach (string k in naujassarasas1)
                {
                    Console.WriteLine(k);
                }
            
        }


    }
}
