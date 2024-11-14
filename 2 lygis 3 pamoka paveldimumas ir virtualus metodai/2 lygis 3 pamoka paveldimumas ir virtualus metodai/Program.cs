namespace _2_lygis_3_pamoka_paveldimumas_ir_virtualus_metodai
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Car car1 = new Car(150);
            Car car2 = new Car();
            car2.Speed = 100;
            Console.WriteLine($"Automobilio greitis { car1.Speed}, antro automobilio greitis { car2.Speed}");
        }
    }
}
