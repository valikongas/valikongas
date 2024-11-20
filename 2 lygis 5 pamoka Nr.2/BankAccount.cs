using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_5_pamoka_Nr._2
{
    internal class BankAccount
    {
       protected double Balance { get; private set; }

        public BankAccount()
        {
            
        }

        public BankAccount(double balance )
        {
            Balance = balance;
        }

       

        protected void PrintBalance()
        {
            Console.WriteLine("Balansas: "+Balance);

        }
        public void NewBalance (double suma)
        { Balance = suma; }
 
       
        public virtual double GetBalance() 
        {
            Console.WriteLine("Balansas yra: "+Balance );
            return Balance;
        }

    }
}
