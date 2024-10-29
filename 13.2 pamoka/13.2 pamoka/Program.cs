using System.Runtime.Serialization;
using System.Threading.Channels;

namespace _13._2_pamoka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zaidimas.ZaidimoPradzia(); 
        }
    }

    public class Zaidimas
    {
       
        
        


        public static void ZaidimoPradzia()
        {
          int[,] laukas = new int[3, 3];
          
            Console.Clear();
            Console.WriteLine("Kiek zaideju zais 1 ar 2: ");
            bool isIntenger1 = false;
            int x1 = 0;
            do
            {
                isIntenger1 = int.TryParse(Console.ReadLine(), out x1);
                if (isIntenger1 && (x1 <= 0 || x >= 3))
                    isIntenger1 = false;
            }
            while (!isIntenger1);

            switch(x1)
            {
                case (1):

                    break;
                    case (2):
                    break;
            }




            NupieskLauka(laukas);
            IveskKoordinates(out int x, out int y);
            

       
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public static void IveskKoordinates(out int x, out int y)
        {
            x=0;
            y=0;
           bool isIntenger = false;

            do
            {
                Console.Write("Ivesk kordinatas x koordinate: ");
                isIntenger = int.TryParse(Console.ReadLine(), out x);
                if (isIntenger && (x <= 0 || x >= 4))
                    isIntenger = false;
            }
            while (!isIntenger);
            do
            {
                Console.Write("Ivesk kordinatas y koordinate: ");
                isIntenger = int.TryParse(Console.ReadLine(), out y);
                if (isIntenger && (x <= 0 || x >= 4))
                    isIntenger = false;
            }
            while (!isIntenger);

        
        }

        public static void NupieskLauka(int[,] laukas)
        {
            Console.Clear();

            Console.WriteLine("     Virsuje - X, sone - Y");
            Console.WriteLine("      1         2         3");

            for (int i = 0; i < 3; i++)
            {


                if (laukas[0, i] == 0 && laukas[1, i] == 0 && laukas[2, i] == 0)

                {
                    for (int j = 0; j < 8; j++)
                        if (j == 4)
                        {
                            Console.WriteLine($"{i+1}         ||        ||        ");
                        }
                    else 
                    { Console.WriteLine("          ||        ||        "); }
                }
                else if (laukas[0, i] == 1 && laukas[1, i] == 0 && laukas[2, i] == 0)
                {
                    Console.WriteLine("          ||        ||        ");
                    Console.WriteLine("   X    X ||        ||        ");
                    Console.WriteLine("    X  X  ||        ||        ");
                    Console.WriteLine($"{i+1}  XX   ||        ||        ");
                    Console.WriteLine("     XX   ||        ||        ");
                    Console.WriteLine("    X  X  ||        ||        ");
                    Console.WriteLine("   X    X ||        ||        ");
                    Console.WriteLine("          ||        ||        ");
                }
                else if (laukas[0, i] == 2 && laukas[1, i] == 0 && laukas[2, i] == 0)
                {
                    Console.WriteLine("          ||        ||        ");
                    Console.WriteLine("     XX   ||        ||        ");
                    Console.WriteLine("    X  X  ||        ||        ");
                    Console.WriteLine($"{i+1}X    X ||        ||        ");
                    Console.WriteLine("   X    X ||        ||        ");
                    Console.WriteLine("    X  X  ||        ||        ");
                    Console.WriteLine("     XX   ||        ||        ");
                    Console.WriteLine("          ||        ||        ");
                }
                else if (laukas[0, i] == 0 && laukas[1, i] == 1 && laukas[2, i] == 0)
                {
                    Console.WriteLine("          ||        ||        ");
                    Console.WriteLine("          || X    X ||        ");
                    Console.WriteLine("          ||  X  X  ||        ");
                    Console.WriteLine($"{i+1}       ||   XX   ||        ");
                    Console.WriteLine("          ||   XX   ||        ");
                    Console.WriteLine("          ||  X  X  ||        ");
                    Console.WriteLine("          || X    X ||        ");
                    Console.WriteLine("          ||        ||        ");
                }
                else if (laukas[0, i] == 2 && laukas[1, i] == 2 && laukas[2, i] == 0)
                {
                    Console.WriteLine("        ||        ||        ");
                    Console.WriteLine("        ||   XX   ||        ");
                    Console.WriteLine("        ||  X  X  ||        ");
                    Console.WriteLine($"{i+1}       || X    X ||        ");
                    Console.WriteLine("        || X    X ||        ");
                    Console.WriteLine("        ||  X  X  ||        ");
                    Console.WriteLine("        ||   XX   ||        ");
                    Console.WriteLine("        ||        ||        ");
                }
                else if (laukas[0, i] == 0 && laukas[1, i] == 0 && laukas[2, i] == 1)
                {
                    Console.WriteLine("        ||        ||        ");
                    Console.WriteLine("        ||        || X    X ");
                    Console.WriteLine("        ||        ||  X  X  ");
                    Console.WriteLine($"{i+1}       ||        ||   XX   ");
                    Console.WriteLine("        ||        ||   XX   ");
                    Console.WriteLine("        ||        ||  X  X  ");
                    Console.WriteLine("        ||        || X    X ");
                    Console.WriteLine("        ||        ||        ");
                }
                else if (laukas[0, i] == 2 && laukas[1, i] == 0 && laukas[2, i] == 2)
                {
                    Console.WriteLine("        ||        ||        ");
                    Console.WriteLine("        ||        ||   XX   ");
                    Console.WriteLine("        ||        ||  X  X  ");
                    Console.WriteLine($"{i+1}       ||        || X    X ");
                    Console.WriteLine("        ||        || X    X ");
                    Console.WriteLine("        ||        ||  X  X  ");
                    Console.WriteLine("        ||        ||   XX   ");
                    Console.WriteLine("        ||        ||        ");
                }
                if (i != 2)
                {
                    Console.WriteLine("  ____________________________");
                    Console.WriteLine("  ____________________________");
                }
            }

        }





    }


}
