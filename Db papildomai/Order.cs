using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_papildomai
{
   public class Order:IEntity
    {
        public Guid Number { get; set; }
        public string ShipingAdress { get; set; }
        public bool IsCompleated {  get; set; }
        public DateTime DateCreat { get; set; } 
        List<OrderItem> OrderItems { get; set; }
       

        public int Id {  get; set; }
    }
}
