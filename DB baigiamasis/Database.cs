using Microsoft.EntityFrameworkCore;


namespace DB_baigiamasis
{
    public class Database:DbContext
    {
        public DbSet<Departament> Departaments {  get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source =sql.bsite.net\\MSSQL2016;Initial Catalog = valikongas_SampleDB; User ID=valikongas_SampleDB;Password=Aaaaaa111999...; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departament>().Property(p => p.Name).HasMaxLength(35);
            modelBuilder.Entity<Lecture>().Property(l => l.Name).IsRequired().HasMaxLength(35);
            modelBuilder.Entity<Student>().Property(l => l.Name).HasMaxLength(20);
            modelBuilder.Entity<Student>().Property(l => l.Surname).HasMaxLength(20);         
        }
    }
}
