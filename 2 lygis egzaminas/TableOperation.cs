using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public static class TableOperation
    {
        public static Table[] CreateTables()
        {
            Table[] tables = new Table[10];
            int place = 2;
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    place = 2;
                }
                else
                {
                    place = 4;
                }
                tables[i] = new Table(i + 1, place, false, new Order());
            }

            return tables;
        }

        public static void TableView(bool allTablePrinted=true, bool printOnlyTableOccupied=false)
        {
            Console.Clear();
            Console.WriteLine("                           Staliuku apzvalga");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine($"Satliuko Nr.\t Ar staliukas uzimtas\t Vietus skaicius\t Prie staliuko \t\t  Uzsakymo suma");
            Console.WriteLine($"\t\t\tuzimtas\t\t\t\t\tpraleistas laikas");
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                string text1 = Table.Tables[i].IsOccupied ? "uzimtas" : "laisvas";
                string text2 = "";
                string text3 = "";
                if(Table.Tables[i].IsOccupied)
                {
                   DateTime dateTime = DateTime.Now;
                   TimeSpan time= (dateTime - Table.Tables[i].TableOrder.OrderReceived);
                   text2=time.Hours.ToString()+":"+time.Minutes.ToString()+":"+time.Seconds.ToString();
                   text3 = Table.Tables[i].TableOrder.Sum.ToString();
                }
                if (!printOnlyTableOccupied)
                {
                    if (!Table.Tables[i].IsOccupied || allTablePrinted)
                        Console.WriteLine($"   {Table.Tables[i].Number}\t\t\t {text1}\t\t {Table.Tables[i].Place}\t\t    {text2}\t\t\t {text3}");
                }
                else
                {
                    if (Table.Tables[i].IsOccupied)
                        Console.WriteLine($"   {Table.Tables[i].Number}\t\t\t {text1}\t\t {Table.Tables[i].Place}\t\t    {text2}\t\t\t {text3}");
                }
            }

            if (allTablePrinted)
            {
                Console.WriteLine("");
                Console.WriteLine("Spausk bet koki mygtuka");
                Console.ReadKey();
            }
        }

       
    }
}
