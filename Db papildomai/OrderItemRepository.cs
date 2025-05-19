using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_papildomai
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IDisposable
    {
        private readonly GenericDBContext _dbcontext; 
        public OrderItemRepository(GenericDBContext dBContext) : base(dBContext) 
        {
        _dbcontext = dBContext;
        }

        public  void Add(OrderItem item)
        {
            _dbcontext.Add(item);
        }
    }
}
