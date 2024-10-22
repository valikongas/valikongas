namespace _10_pamoka
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string result = "Mano vardas";

            //for (int i = 0; i < result.Length; i++)
            //{

            //    Console.Write(result[i] + " ");

            //}
            //Console.WriteLine();


            //// Nr. 1.1 
            //for (int i = 2; i <= 100; i += 2)
            //{
            //    Console.Write(i + ", ");
            //}

            ////Nr.1.2.
            //Console.Write("Ivesk skaiciu: ");
            //int skaicius;
            //bool isNumber;
            //do
            //{
            //    isNumber = int.TryParse(Console.ReadLine(), out skaicius);
            //}
            //while (!isNumber);

            //int sum = 0;
            //for (int i = 0; i <= skaicius; i++)
            //{
            //    sum += i;
            //}

            //Console.WriteLine($"Suma lygi: {sum}");

            ////Nr.1.3

            //int skaicius;
            //bool isNumber;
            //do
            //{
            //    Console.Write("Ivesk skaiciu: ");
            //    isNumber = int.TryParse(Console.ReadLine(), out skaicius);
            //    if(!isNumber)
            //        Console.WriteLine("Ivedei ne skaiciu !");
            //}
            //while (!isNumber);


            //for (int i = 0; i <= skaicius; i++)
            //{
            //    Console.Write($"{i*i}, ");
            //}

            ////Nr.1.3

            //int skaicius;
            //bool isNumber;
            //do
            //{
            //    Console.Write("Ivesk skaiciu: ");
            //    isNumber = int.TryParse(Console.ReadLine(), out skaicius);
            //    if (!isNumber)
            //        Console.WriteLine("Ivedei ne skaiciu !");
            //}
            //while (!isNumber);

            //int sum = 0;

            //for (int i = 0; i <= skaicius; i++)
            //{
            //    sum += i;
            //}

            //Console.WriteLine($"Skaiciu  vidurkis: {(double)sum / skaicius}");


            ////Nr.1.4

            //int skaicius;
            //bool isNumber;
            //do
            //{
            //    Console.Write("Ivesk auksti: ");
            //    isNumber = int.TryParse(Console.ReadLine(), out skaicius);
            //    if (!isNumber)
            //        Console.WriteLine("Ivedei ne skaiciu !");
            //}
            //while (!isNumber);

            //for (int i = 0; i <= skaicius; i++)
            //{
            //    Console.WriteLine("********");
            //}

            ////Nr.1.4

            int skaicius;
            bool isNumber;
            do
            {
                Console.Write("Ivesk auksti: ");
                isNumber = int.TryParse(Console.ReadLine(), out skaicius);
                if (!isNumber)
                    Console.WriteLine("Ivedei ne skaiciu !");
            }
            while (!isNumber);

            for (int i = 3; i <= skaicius; i+=3)
            {
                Console.Write(i+", ");
            }


        }
    }
}
