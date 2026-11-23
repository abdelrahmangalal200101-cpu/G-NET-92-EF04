using EFCore4.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore4.Enteties
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int NationalId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address  { get; set; }
        public CustomerType CustomerType { get; set; }
        public ICollection<CustomerAccount>? CustomerAccounts { get; set; } = new HashSet<CustomerAccount>();



    }
}
