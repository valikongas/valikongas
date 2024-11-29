using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_10_pamoka_exeption
{
    internal class Netikra_klaida : Exception
    {
        public Netikra_klaida(string? message) : base(message)
        {
        }
    }
}
