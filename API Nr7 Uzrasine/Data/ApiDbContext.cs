using API_Nr7_Uzrasine.Object;
using Microsoft.EntityFrameworkCore;

namespace API_Nr7_Uzrasine.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<UserUzrasine> UsersUzrasine { get; set; }
        public DbSet<MessageUzrasine> MessagesUzrasine { get; set; }
        public DbSet<CategoryUzrasine> CategoriesUZrasine { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }


    }
}
