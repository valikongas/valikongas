namespace API_Nr3
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car()
        { 
            
        }

        public Car(int id, string model, int year, string color)
        {
            Id = id;
            Model = model;
            Year = year;
            Color = color;
        }
        public Car(string model, int year, string color)
        {
            Model = model;
            Year = year;
            Color = color;
        }





    }
}
