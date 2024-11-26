namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var muList = new Generic<int>();
            
            for (int i = 0;i<5;i++)
            {
                if(i%2==0)
                muList.AddItem(i);
                else
               muList.AddItem(i*5);
                 
            }

            //Uzduotis 7 pamokos 4
            muList.RemoveItem1(0);
            muList.RemoveItem1(2);
            muList.RemoveItem1(5);
             muList.RemoveItem1(15);            
            //---------------


            var vardas = new List<int>(); 
            vardas = muList.GetArray1();
         
            foreach (var mu in vardas)
                Console.WriteLine(mu);



        }
    }
}
