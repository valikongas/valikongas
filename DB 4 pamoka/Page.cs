using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_4_pamoka
{
    public class Page
    {
        public Guid Id { get; set; }
        public int Number {  get; set; }
        public string Content { get; set; }
        public Page(int number, string content)
        {
            Id = Guid.NewGuid();
            this.Number = number;
            this.Content = content;
        }
    }
}
