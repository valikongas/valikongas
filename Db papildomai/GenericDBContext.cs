

using Microsoft.EntityFrameworkCore;

namespace Db_papildomai
{
    public class GenericDBContext:DbContext
    {
        public DbSet <Order> Orders { get; set; }
        public DbSet <OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source =sql.bsite.net\\MSSQL2016;Initial Catalog = valikongas_SampleDB; User ID=valikongas_SampleDB;Password=Aaaaaa111999...; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
    }
}
