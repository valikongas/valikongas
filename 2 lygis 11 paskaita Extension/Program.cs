using System.ComponentModel.DataAnnotations;

namespace _2_lygis_11_paskaita_Extension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 6;
            int y = 9;
            string text = "Namas pievoj";
            Console.WriteLine($"Ar skaicius {x} teigiamas: " + x.IsPositiv());
            Console.WriteLine($"Ar skaicius {x} lyginis: "+x.IsEven());
            Console.WriteLine($"Ar skaicius {y} yra didesnis uz {x}: {x.IsBiger(y)}");
            Console.WriteLine($"Ar tekstas \"{text}\" turi tarpu: {text.IsSpace()}");

            string fullname = "Gedas";
            int yearOfBirdt = 1999;
            string domain = "gmail.com";
            Console.WriteLine("Mailas yra: "+fullname.MailName(yearOfBirdt, domain));
            
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            int Answer = list.FindAndReturnIfEqual(x);
            if (Answer != default)
            {
                Console.WriteLine($"Skaicius {x} masyve yra.");
            }
            foreach (var i in list.EveryOtherWord())
            {
                Console.WriteLine(i);
            }
            string path= "C:\\Users\\gedasvalikonis\\Desktop\\testui.txt";
            StreamReader failas = new StreamReader(path);
            List<string> strings = new List<string>();
            strings=failas.Failu();
            foreach (var i in strings)
            {
                Console.WriteLine(i);
            }
        }
    }
}
