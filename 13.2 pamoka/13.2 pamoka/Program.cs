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
            string vardas = "";
            Console.Clear();
            
            Console.Write("Ivesk savo varda: ");

            do {
                vardas = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(vardas) || string.IsNullOrEmpty(vardas));

            Console.Clear();

            Console.WriteLine("Kiek zaideju zais 1 ar 2: ");
            bool isIntenger1 = false;
            int x1 = 0;
            do
            {
                isIntenger1 = int.TryParse(Console.ReadLine(), out x1);
                if (isIntenger1 && (x1 <= 0 || x1 >= 3))
                    isIntenger1 = false;
            }
            while (!isIntenger1);

            switch(x1)
            {
                case (1):
                    {
                        ZaidimasVienam(vardas, laukas);
                        break;
                    }
                    case (2):
                    {
                        Console.WriteLine("Deja, kolkas sukurtas zaidimas tik vienam");


                        break;
                    }
            }




          
            

       
        }
        
        public static void ZaidimasVienam(string vardas, int[,] laukas)
        {
            Console.Clear();
            Console.WriteLine("       " + vardas);
            Console.WriteLine();
            NupieskLauka(laukas);

            for (int i = 1; i < 10; i++)
            {
                IveskKoordinates(laukas, out int x,  out int y);
                laukas[y-1, x-1] = 1;
                Console.Clear() ;
                Console.WriteLine("       "+vardas);
                Console.WriteLine();
                NupieskLauka(laukas);
            }
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        public static void IveskKoordinates(int[,] laukas,out int x, out int y)
        {
            x=0;
            y=0;
           bool isIntenger = false;
            do
            {
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
                


                while (laukas[y-1, x-1] == 1 || laukas[y-1, x-1] == 2) ;
        
        }

        public static void NupieskLauka(int[,] laukas)
        {
           

            Console.WriteLine("     Virsuje - X, sone - Y");
            Console.WriteLine("      1         2         3");

            for (int i = 0; i < 3; i++)
            {
                // 2 varianta bandau
                for (int j = 0; j < 3; j++)
                {
                    if (laukas[i, j] == 0)
                        Console.Write("|        |");
                    else if (laukas[i, j] == 1)
                        Console.Write("|        |");
                    else if (laukas[i, j] == 2)
                        Console.Write("|        |");
                }
                    Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    if (laukas[i, j] == 0)
                        Console.Write("|        |");
                    else if (laukas[i, j] == 1)
                        Console.Write("| X    X |");
                    else if (laukas[i, j] == 2)
                        Console.Write("|   XX   |");
                }
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    if (laukas[i, j] == 0)
                        Console.Write("|        |");
                    else if (laukas[i, j] == 1)
                        Console.Write("|  X  X  |");
                    else if (laukas[i, j] == 2)
                        Console.Write("|  X  X  |");
                }
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        if (laukas[i, j] == 0)
                            Console.Write((i + 1) + "        |");
                        else if (laukas[i, j] == 1)
                            Console.Write((i + 1) + "   XX   |");
                        else if (laukas[i, j] == 2)
                            Console.Write((i + 1) + " X    X |");
                    }
                    else
                    {
                        if (laukas[i, j] == 0)
                            Console.Write("|        |");
                        else if (laukas[i, j] == 1)
                            Console.Write("|   XX   |");
                        else if (laukas[i, j] == 2)
                            Console.Write("| X    X |");


                    }
                }
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    if (laukas[i, j] == 0)
                        Console.Write("|        |");
                    else if (laukas[i, j] == 1)
                        Console.Write("|   XX   |");
                    else if (laukas[i, j] == 2)
                        Console.Write("| X    X |");
                }
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    if (laukas[i, j] == 0)
                        Console.Write("|        |");
                    else if (laukas[i, j] == 1)
                        Console.Write("|  X  X  |");
                    else if (laukas[i, j] == 2)
                        Console.Write("|  X  X  |");
                }
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    if (laukas[i, j] == 0)
                        Console.Write("|        |");
                    else if (laukas[i, j] == 1)
                        Console.Write("| X    X |");
                    else if (laukas[i, j] == 2)
                        Console.Write("|   XX   |");
                }
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    if (laukas[i, j] == 0)
                        Console.Write("|        |");
                    else if (laukas[i, j] == 1)
                        Console.Write("|        |");
                    else if (laukas[i, j] == 2)
                        Console.Write("|        |");
                }
                Console.WriteLine();
                {
                    Console.WriteLine("    ____________________________");
                    Console.WriteLine("    ____________________________");
                }






                // 2 varianto pabaiga



            }

        }





    }


}
