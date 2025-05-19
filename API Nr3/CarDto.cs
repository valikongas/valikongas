namespace API_Nr3
{
    public class CarDto
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public CarDto()
        {
            
        }
        public CarDto(string model, int year, string color)
        {
            Model = model;
            Year = year;
            Color = color;
        }

    }
}
