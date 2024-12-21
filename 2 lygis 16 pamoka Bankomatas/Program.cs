using System.Security.Cryptography.X509Certificates;

namespace _2_lygis_16_pamoka_Bankomatas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string insertCardGuid = "01A5B5641645545664546446464AA4BB";
            BankProgram.BankProgramRun(insertCardGuid);
            
    }
    }
}
