using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_5_pamoka_Nr._2
{
    internal class SealedClass:SavingAccount
    {
        public SealedClass(double interestrate):base(interestrate)
        {
            
        }
        public  override double GetBalance()
        {
            Console.WriteLine("Apsaugotas metodas");
            return base.GetBalance();
        }
    }
}
