namespace API_Nr3
{
    public class CarDatabase : ICarDatabase
    {
        private List<Car>  _cars;

        public CarDatabase() 
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, Model = "Toyota Corolla", Year = 2018, Color = "Raudona" },
                new Car { Id = 2, Model = "Honda Civic", Year = 2020, Color = "Mėlyna" },
                new Car { Id = 3, Model = "Ford Focus", Year = 2017, Color = "Juoda" },
                new Car { Id = 4, Model = "BMW 3 Series", Year = 2021, Color = "Balta" },
                new Car { Id = 5, Model = "Audi A4", Year = 2019, Color = "Pilka" },
                new Car { Id = 6, Model = "Volkswagen Golf", Year = 2016, Color = "Žalia" },
                new Car { Id = 7, Model = "Mercedes-Benz C-Class", Year = 2022, Color = "Sidabrinė" },
                new Car { Id = 8, Model = "Tesla Model 3", Year = 2023, Color = "Mėlyna" },
                new Car { Id = 9, Model = "Hyundai Tucson", Year = 2015, Color = "Ruda" },
                new Car { Id = 10, Model = "Kia Sportage", Year = 2014, Color = "Geltona" }
            };
        }

        public void AddCar(CarDto newCar)
        {
            int id = _cars.Count + 1;
            Car newCar1=new Car(id, newCar.Model, newCar.Year, newCar.Color);
             _cars.Add(newCar1);
        }

        public List<Car> GetAllCars()
        {
            return _cars;
        }

        public List<Car> GetCarByColor(string color)
        { 
            return _cars.Where(car => car.Color.Equals(color)).ToList();       
        }
    }
}
