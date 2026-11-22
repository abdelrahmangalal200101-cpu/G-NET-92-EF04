using EFCore4.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore4.Enteties
{
    public class Transaction
    {
        public int TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Note  { get; set; }
        public int AccountNumber { get; set; }
        public Account Account { get; set; } = null!;

        
    }
}
