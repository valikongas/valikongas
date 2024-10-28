using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks.Dataflow;

namespace _13_pamoka
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] number = { 1, 3, 5, 8, 9 };
            double average = Skaiciavimai.AverageCalc(number);
            Console.WriteLine($"vidurkis yra :{average}");

            int[] number1 = { 1, -1, 5, -5, 8, -7 };
            int[] positiv = Skaiciavimai.Positiv(number1);
            foreach (int i in positiv)
            {
                Console.WriteLine(i);
            }
            double[] number2 = { 10, 10,13.2   };
            double gpm = Skaiciavimai.Gpm(number2);
            Console.WriteLine($"GPM yra: {gpm}");

            Console.Write("Ivesk sakini:");
            string sakinys=Console.ReadLine();
            Console.WriteLine($"Zodziai yra: {Skaiciavimai.Sakinys(sakinys)}");

            string[] zenklas = { "bugnu", "sirdziu", "kryziu", "vynu" };
            string[] korta = { "T", "K", "D", "V", "10", "9", "8", "7", "6", "5", "4", "3", "2" };

            string[,] kalade = Skaiciavimai.ConstructDesk(zenklas, korta);
            foreach (string i in kalade)
            {
                Console.Write(i + ", ");
            }
        }

    }
    


 }

    public class  Skaiciavimai
    {
    public static double AverageCalc(int[] x)
        {
            double average = 0;
            int sum = 0;
            foreach (int i in x)
            {
                sum = sum + i;
            }
            average = (double)sum / x.Length;

            return (average);

        }


    public static int[] Positiv(int[] x)
    {
        int[] y = new int[x.Length];
        int index = 0;
        foreach (int i in x)
        {
            if (i > 0)
            {
                y[index] = i;
                index++;
            }
        }
        int[] z = new int[index];
        index=0;
        foreach (int i in y)
        {
            if (i == 0)
                break;
            else
            {
                z[index] = i;
                index++;
            }
        }

        return (z);
    }

    public static double Gpm(double[] x)
    {

        double sum = 0;

        foreach (double i in x)
        {
            sum += i;
        }
        

        return (Math.Round(sum*0.15,2));
    }

    public static string Sakinys(string x)
    {
        string z = "";
        string[] y = x.Split(' ');
        foreach (string s in y)
            if (s.Length >= 5)
                z += s + " ";     
              return (z);
    }


    public static string[,] ConstructDesk(string[] x, string[] y)
    {
        string[,] kalade = new string[x.Length, y.Length];
        for (int i = 0; i < x.Length; i++)
        {
            for (int j = 0; j < y.Length; j++)
            {
                kalade[i, j] =  y[j]+" "+x[i];
            }
        }
        return kalade;
    }
}




