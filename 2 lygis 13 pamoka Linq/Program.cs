using System.Security.Cryptography.X509Certificates;

namespace _2_lygis_13_pamoka_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] skaiciai = { -1, 2, -3, 4, 5, -6, 7, 8, 9, 10, 11, };
            var newskaiciai = skaiciai.Select(x => x * x);
            foreach (var i in newskaiciai)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();

            var newskaiciai1=skaiciai.Where(x=>x >0);
            foreach (var i in newskaiciai1)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();

            var newskaiciai2 = skaiciai.Where(x => x > 0 && x<11);
            foreach (var i in newskaiciai2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            var newskaiciai3 = skaiciai.Order();
            foreach (var i in newskaiciai3)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            var newskaiciai4 = skaiciai.OrderDescending();
            foreach (var i in newskaiciai4)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            var newskaiciai5 = skaiciai.Max();
            Console.Write(newskaiciai5);
            Console.WriteLine();

            List<Pet> gyvunai =
               [new Pet("Suo",5),
                new Pet("kate",8),
                new Pet("Ryklys",9)];
            List<Pet> gyvunai1 =
                [new Pet("Suo1",4),
                new Pet("kate1",10)];
            List<Pet> gyvunai2 =
               [new Pet("kate2",11)];

            List<Person> list =
                [new Person("Gedas",45,gyvunai),
                new Person("Vaida", 30, gyvunai1),
                new Person("Vytas", 35,gyvunai2),
                new Person("Tomas", 40, gyvunai),];
            var vardai = list.Select(x=>x.Name).ToList();
            var age = list.Select(x=> x.Age).ToList();
            foreach (var x in vardai)
            { Console.Write(x); }

            Console.WriteLine();

            foreach(var x in age)
            { Console.Write(x); }
            Console.WriteLine();

            var sortedAge=list.OrderByDescending(x=>x.Age).ToList();
            foreach(var x in sortedAge)
                { Console.WriteLine(x.Name+" "+x.Age); }
            Console.WriteLine();

            var nameV=list.Where(x=>x.Name.StartsWith("V"));
            foreach (var x in nameV)
            {  Console.Write(x.Name+" "+x.Age); }

            Console.WriteLine();

            var list31=list.Where(x=>x.Age>30).OrderBy(x=>x.Name).ToList();
            foreach( var x in list31)
            { Console.WriteLine(x.Name+" "+x.Age); }

            //Nr.2--------------------------

            var gyvunuSarasIsRaideS = list.SelectMany(x => x.Pets).Where(x=>x.Petname.StartsWith('S')).ToList();
            Console.WriteLine("Gyvunai is S raides:");
            foreach(var x in gyvunuSarasIsRaideS)
            { Console.WriteLine(x.Petname); }

            Console.WriteLine();
            Console.WriteLine("Gyvunai is S raides ir amzius daugiau 4:");
            var gyvunuSarasIsRaideSIrAmziusDaugiau4 = list.SelectMany(x => x.Pets).Where(x => x.Petname.StartsWith('S')).Where(x=>x.PetAge>4).ToList();
            foreach (var x in gyvunuSarasIsRaideSIrAmziusDaugiau4)
            { Console.WriteLine(x.Petname); }

            
            List<string> zodziai=
                ["saule","MENULIS","zvaigzde","TOMAS","Gedas","antanas"];
            zodziai = BigChar(zodziai);
            foreach( var x in zodziai)
                { Console.WriteLine(x); }

            //Nr.3 -------------------------------------------

            string direktorija = @"C:\Users\gedasvalikonis\Desktop\Marleksa\TekstoAtpazinimas";
            string[] failai = Directory.GetFiles(direktorija);
            foreach (var x in failai)
            {Console.WriteLine(x);}

            var ekstensionai=failai.Select(x=>Path.GetExtension(x)).Distinct().ToList();
            foreach( var x in ekstensionai)
            { Console.WriteLine(x);}
            var csfailai = failai.Where(x=>Path.GetExtension(x)==".cs").ToList();
            foreach(var x in csfailai)
                { Console.WriteLine(x); }

            Console.WriteLine("Forms1.cs failai: ");
            var Form1csfailai = failai.Where(x => Path.GetFileName(x) == "Form1.cs").ToList();
            foreach (var x in Form1csfailai)
            { Console.WriteLine(x); }
           



        }
        public static List<string> BigChar(List<string> list)
        {
        list=list.Where(x=>x==x.ToUpper()).ToList();
            return list;
        }
    }
}
