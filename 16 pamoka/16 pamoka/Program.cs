using System.Linq;
using System.Collections.Generic;

namespace _16_pamoka
{
 

    internal class Program
    {
        static void Main(string[] args)
        {
            //Zodynas();

            //Dictionary <string,string> valstybes1=Valstybes();
            //Console.Write("Ivesk valstybe: ");
            //string valstybe=Console.ReadLine();
            //valstybes1.TryGetValue(valstybe, out string atsakymas);     
            //Console.WriteLine("Sostine yra "+atsakymas);
            //PakeiskValstybe(valstybes1);
            //foreach ((string i, string j) in valstybes1)
            //{
            //    Console.WriteLine(i+" "+j);
            //}

            Menesiai();



        }


        public static void Zodynas()
        {
Dictionary<string,int> manoZodynas = new Dictionary<string,int>();
            manoZodynas.Add("Jonas", 54);
            manoZodynas.Add("Antanas", 36);
            manoZodynas.Add("Petras", 45);

            foreach ((string i,int j) in manoZodynas)
            {
                Console.WriteLine(i+" "+j);
            }

        }


        public static Dictionary<string,string> Valstybes ()
        {
            Dictionary<string, string> valstybes = new Dictionary<string, string>()
            {
            { "Lietuva", "Vilnius"},
            { "Latvija", "Ryga"},
            { "Estija","Talinas"}
            };   
            return valstybes;

        }
    
    public static void PakeiskValstybe(Dictionary<string,string> valstybe2)
        {
            Console.Write("Ivesk valstybe, kurios sostine nori pakeisti: ");
            string pakeisti=Console.ReadLine();
            Console.WriteLine();
            Console.Write("Ivesk nauja sostine");
            string naujaSostine=Console.ReadLine();
            Console.WriteLine();
            valstybe2[pakeisti]=naujaSostine;
            Console.Write("Ivesk kuria valstybe nori pakeisti nauja: ");
            pakeisti = Console.ReadLine();
            valstybe2.Remove(pakeisti);
            Console.WriteLine();
            Console.Write("Ivesk nauja valstybe :");
            string naujaValstybe=Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ivesk jos sostine: ");
            naujaSostine= Console.ReadLine();
            valstybe2.Add(naujaValstybe, naujaSostine);
       
        }
    

        public static void Menesiai()
        {
            Dictionary<string, int> menesiai = new Dictionary<string, int>
            {
                {"Sausis",31},
                { "Vasaris", 28},
                { "Kovas", 31},
                {"Balandis", 30 },
                {"Geguze",31 },
                {"Birzelis",30},
                {"Liepa",31 },
                {"Rugpjutis",31 },
                {"Rugsejis",30},
                {"Spalis",31},
                {"lapkritis",30},
                {"Gruodis",31 }
            };
            foreach ((string key2, int day2) in menesiai)
            {
                if (menesiai[key2] < 31 || key2.Contains("tis"))
                {
                   
                    Console.WriteLine(key2 + " " + menesiai[key2]);
                }
            }
            Console.WriteLine();

            
                   var z = menesiai.Where(k => k.Key.Contains("Ru")).Select(k => new {Raktas = k.Key, Reiksme = k.Value}).ToList();
           
            
                   var y = menesiai.Where(k => k.Key.ToLower().Contains("ru")).Select(k => new { Raktas = k.Key, Reiksme = k.Value });


            foreach (var key1 in z)
                {
                   Console.WriteLine(key1.Raktas+" "+key1.Reiksme);
                }
            Console.WriteLine();
            foreach (var key1 in y)
            {
                Console.WriteLine(key1.Raktas + " " + key1.Reiksme);
            }


        }
    
    }

}

