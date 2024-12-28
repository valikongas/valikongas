using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_egzaminas
{
    public  class Table
    {
        public static Table[] Tables = TableOperation.CreateTables();
        public  int Number { get; set; }
        public int  Place { get; set; }
        public bool IsOccupied {  get; set; }

        public Order TableOrder { get; set; }=new Order();

        public Table()
        {
            
        }
        public Table(int number, int place, bool isOccupied, Order tableOrder)
        {
            Number = number;
            Place = place;
            IsOccupied = isOccupied;
            TableOrder = tableOrder;
        }



       





    }
}
