using Egzaminas.Object;
using Microsoft.EntityFrameworkCore;



namespace Egzaminas.Data

{
    public class ApiDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<UserResidence> UserResidence { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }



    }
}
