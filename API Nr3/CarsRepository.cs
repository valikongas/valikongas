namespace API_Nr3
{
    public class CarsRepository : ICarsRepository
    {
        private readonly ApplicationDbContext _context;

        public CarsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
