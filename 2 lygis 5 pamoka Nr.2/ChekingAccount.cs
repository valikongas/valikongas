using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_5_pamoka_Nr._2
{
    internal class ChekingAccount:BankAccount
    {
        public double OverdraftLimit { get; set; }

        public ChekingAccount(double balance):base(balance) 
        {
            
        }


        public void Withraw(double withdraw)
        {
            if ((Balance - withdraw) > OverdraftLimit)
            {
                double likutis = Balance - withdraw;
                NewBalance(likutis);
                PrintBalance();

            }
            else
                Console.WriteLine("Tau neuztenka pinigu");

        }
    }
}
