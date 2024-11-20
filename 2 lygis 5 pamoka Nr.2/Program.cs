namespace _2_lygis_5_pamoka_Nr._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingAccount saskaita1 = new(5.0,1000.0);
            
            saskaita1.CalculateInterest();
            ChekingAccount chekingAccount1 = new ChekingAccount(1000);
            
            chekingAccount1.OverdraftLimit = -300.0;
            chekingAccount1.Withraw(1500);

            BankAccount bankAccount1 = new BankAccount();
            bankAccount1.NewBalance(500);
            bankAccount1.GetBalance();
            saskaita1.GetBalance();



        }
    }
}
