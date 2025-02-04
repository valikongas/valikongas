using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_testai
{
    internal static class TClass<T>
    {
        public static List<T> DuomenysIsBazes()
        {
            var sql = $"SELECT * FROM {typeof(T).Name}";
            var connString = $"Data Source =sql.bsite.net\\MSSQL2016;Initial Catalog = valikongas_SampleDB; User ID=valikongas_SampleDB;Password=Aaaaaa111999...; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;";
            using var connection = new SqlConnection(connString);
            //connection.Open();
            var data = connection.Query<T>(sql);
            var result = data.ToList();
            return result;

        }
    }
}
