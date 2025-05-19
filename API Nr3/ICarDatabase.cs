namespace API_Nr3
{
    public interface ICarDatabase
    {
        public List<Car> GetAllCars();
        public List<Car> GetCarByColor(string color);
        public void AddCar(CarDto newCar);
    }
}
