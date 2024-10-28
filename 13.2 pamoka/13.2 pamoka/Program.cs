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
            NupieskLauka();
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

    }


}
