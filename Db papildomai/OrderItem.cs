using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_papildomai
{
    public class OrderItem:IEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
