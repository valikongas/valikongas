using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Nr3.Controllers
{
        [ApiController]
    [Route("[controller]")]
    public class CarControler : Controller
    {
    
        private readonly ICarDatabase _database;

        private readonly ApplicationDbContext _context;



        public CarControler(ICarDatabase carDatabase, ApplicationDbContext context)
        {
            _database = carDatabase;
            _context = context;
        }

        [HttpGet( "GetAllCars")]
        public List<Car> GetAllCars()
        {        
            List<Car> cars= _database.GetAllCars();
            List<Car> cars2=_context.Cars.ToList();
            cars.AddRange(cars2);
            return (cars);



        }

        [HttpGet("GetAllCarsByColors")]
        public ActionResult<List<Car>> GetCarsByColor([FromQuery] string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                return BadRequest("Nurodykite spalvą.");
            }
            var cars = _database.GetCarByColor(color);




            // iesko internetinej duomenu bazej
            List <Car> CarListByColor=_context.Cars.Where(car => car.Color.Equals(color)).ToList();
            cars.AddRange(CarListByColor);

            if (cars.Count == 0)
            {
             return NotFound($"Automobiliai su spalva '{color}' nerasti.");  
            }

            

            return Ok(cars);
        }


        [HttpPost("AddNewCar")]
        public ActionResult AddNewCar([FromBody] CarDto newCarDto)
        {
            if (newCarDto == null)
            {
                return BadRequest("Automobilio duomenys negali būti tušti.");
            }
            _database.AddCar(newCarDto);

            // prideda i internetine duomenu baze
            Car newcar = new Car(newCarDto.Model, newCarDto.Year, newCarDto.Color);
            _context.Cars.Add(newcar);
            _context.SaveChanges();

            return Ok();
        }

    }
}
