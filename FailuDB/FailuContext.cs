using Microsoft.EntityFrameworkCore;


namespace FailuDB
{
    internal class FailuContext : DbContext
    {
        public DbSet<Failai> Failu { get; set; }
        public DbSet<Folder> FailuFolders { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source =sql.bsite.net\\MSSQL2016;Initial Catalog = valikongas_SampleDB; User ID=valikongas_SampleDB;Password=Aaaaaa111999...; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
    }


}