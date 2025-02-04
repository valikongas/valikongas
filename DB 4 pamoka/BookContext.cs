using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace DB_4_pamoka
{
    internal class BookContext:DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source =sql.bsite.net\\MSSQL2016;Initial Catalog = valikongas_SampleDB; User ID=valikongas_SampleDB;Password=Aaaaaa111999...; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
    }


}
