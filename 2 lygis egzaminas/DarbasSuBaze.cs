using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public class DarbasSuBaze: DbContext
    {
        public DbSet<Dishes> Dishes { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source =sql.bsite.net\\MSSQL2016;Initial Catalog = valikongas_SampleDB; User ID=valikongas_SampleDB;Password=Aaaaaa111999...; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }


    }
}
