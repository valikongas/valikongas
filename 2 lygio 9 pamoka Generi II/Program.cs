namespace _2_lygio_9_pamoka_Generi_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var skaiciai = new NR1<int> (new List<int> { 1, 2, 3, 4, 5 });
            skaiciai.PrintMasyvas();
            
            int[] masyvas=skaiciai.ConvertMasyvas();
            foreach (int i in masyvas)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.WriteLine(skaiciai.FindIntenger(5));
            Console.WriteLine(skaiciai.FindIntengerDefault(6));
            Console.WriteLine(skaiciai.isValue(3));

            Console.WriteLine();

            var skaiciai2 =new NR2<int> (new List<int> {1, 2, 3,4, 5,6,5,4,10,1});
         
            skaiciai2.AddMasyvas(1);
            
            skaiciai2.RemoveMasyvas(5);
         
            skaiciai2.RemoveIndexMasyvas(1);
           
            skaiciai2.RemoveAllMasyvas(1);
            skaiciai2.PrintMasyvas();
                



        }
    }
}
