using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygis_16_pamoka_Bankomatas
{
    public class Card
    {
        public long CardNr { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Guid {  get; set; }
        public int Password {  get; set; }
        public decimal CashSum {  get; set; }
        public int OperationCount {  get; set; }

        public DateOnly LastOperationDate { get; set; }

        public List<decimal> Operation {  get; set; }
        public Card()
        {
            
        }

        public Card(long cardNr, string name, string surname, string guid, int password, decimal cashSum,int operationCount, DateOnly lastOperationDate, List<decimal> opertation)
        {
            CardNr = cardNr;
            Name = name;
            Surname = surname;
            Guid = guid;
            Password = password;
            CashSum = cashSum;
            OperationCount = operationCount;
            LastOperationDate = lastOperationDate;
            Operation = opertation;
        }





    }
}
