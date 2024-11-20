using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_5_pamoka_Nr._2
{
    internal class SavingAccount:BankAccount
    {
        private double InterestRate { get; set; }

        public SavingAccount(double intererstRate)
        {
            InterestRate = intererstRate;
        }
        public SavingAccount(double interestRate, double balance):base(balance)  
        {
            InterestRate = interestRate;
            
        }


        public void CalculateInterest ()
        {
            double suma = Balance + Balance * InterestRate / 100.0;
            NewBalance(suma);
            PrintBalance();
        }
        public sealed override double GetBalance()
        {
            Console.WriteLine("Palukanos lygios: "+InterestRate);
            return base.GetBalance();
        }

    }
}
