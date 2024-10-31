using System.Diagnostics;

namespace _15_pamoka
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RandomNumber();
            RandomBool();



        }


        //Nr.1 
public static void RandomNumber()
        {   
           Random number = new Random();
            for (int i = 0; i < 10; i++)
            {
              Console.Write(number.Next(1, 11)+" ");
            }  
            Console.WriteLine();
        }

        //Nr.2
        public static void RandomBool()
        {
            Random trueOrNot = new Random();
            bool reiksme = false;
            for (int i = 0; i < 10; i++)
            {
             int number= trueOrNot.Next(1, 3);
                if (number == 1)
                {
                   reiksme=true;
                    Console.Write(reiksme+" ");
                }
                else
                {
                    reiksme = false;
                    Console.Write(reiksme+" ");
                }
            }
       
        }


    }
}
