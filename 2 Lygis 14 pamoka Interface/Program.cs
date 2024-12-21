namespace _2_Lygis_14_pamoka_Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bmw = new BmwCar(true, "BMW", 50, 70);
            var audi = new AudiCar(false, "Audi", 60,70);
            Console.WriteLine("Modelis: "+bmw.Model );
            Console.WriteLine("Ar uztenka kuro toliau vaziuoti: " +bmw.Drive());
            Console.WriteLine($"Ar galima uzsipilti {50} litru: {bmw.Refuel(50)}");

            var bmwCars = new List<BmwCar> { new BmwCar(true, "525", 50, 70), new BmwCar(false, "315", 40, 60), new BmwCar(false, "210", 30, 70) };
            CarInumerable carInumerable = new CarInumerable();
           bmwCars.Sort(carInumerable);
            foreach (Car bmwCar in bmwCars)
            {
                Console.WriteLine(bmwCar.Model+" "+bmwCar.Fuel);
            }
            IVehicle vehicle = new AudiCar(true, "A4", 50, 100);
            IVehicle vehicle1 = new BmwCar(false, "315", 60, 90);

            testas aaa = new testas();
            aaa.Xestas(vehicle1);
        

        }
    }
}
