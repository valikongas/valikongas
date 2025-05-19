using API_Nr5.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Nr5.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<TaskApi> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

    }
}
