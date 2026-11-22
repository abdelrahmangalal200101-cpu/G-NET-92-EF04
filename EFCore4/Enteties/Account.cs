using EFCore4.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore4.Enteties
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime OpeningDate { get; set; }



    }
}
