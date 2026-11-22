using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore4.Enteties
{
    public class Manager
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email  { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }

    }
}
