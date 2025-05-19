using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_papildomai
{
    public class OderRepository : GenericRepository<Order>, IDisposable
    {
        public OderRepository(GenericDBContext dBContext) : base(dBContext){ }


    }
}
