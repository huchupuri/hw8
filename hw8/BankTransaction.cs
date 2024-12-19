using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw8
{
    internal class BankTransaction
    {
        public readonly DateTime transactionDate;
        public readonly decimal Amount;

        // Конструктор
        public BankTransaction(decimal Amount)
        {
            this.transactionDate = DateTime.Now;
            this.Amount = Amount; 
        }
    }
}
