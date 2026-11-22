using EFCore4.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore4.Enteties
{
    public class CustomerAccount
    {
        public DateTime OwnerShipStartDate { get; set; }
        public OwnerShipType OwnerShipType { get; set; }
        public bool AccountStatus { get; set; }

    }
}
