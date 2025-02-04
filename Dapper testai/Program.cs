using Dapper;
using Microsoft.Data.SqlClient;

namespace Dapper_testai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sql = "SELECT * FROM Dishes";
            var connString = $"Data Source =sql.bsite.net\\MSSQL2016;Initial Catalog = valikongas_SampleDB; User ID=valikongas_SampleDB;Password=Aaaaaa111999...; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;";
            using var connection =new SqlConnection(connString);
            //connection.Open();
            var data = connection.Query<Dishes>(sql);

            var sql1 = "Execute kaina @kaina1";
            var value = new { kaina1 = 4 };
            var data1=connection.Query<Dishes>(sql1,value);


            var sql2 = "kaina";
            var value1 = new { kaina1 = 4 };
            var data2=connection.Query<Dishes>(sql2,value1, commandType: System.Data.CommandType.StoredProcedure);

            var sql3 = "SELECT * FROM Dishes Where Price>@kaina1";
            var value3 = new { kaina1 = 4 };
            var data3 = connection.Query<Dishes>(sql3, value3);

         
            var duomenys=new List<Darbuotojas>();
            duomenys = TClass<Darbuotojas>.DuomenysIsBazes();



            Console.WriteLine();
        }
    }
}
