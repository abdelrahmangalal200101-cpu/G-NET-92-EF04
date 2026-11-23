using EFCore4.Enteties;
using EFCore4.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore4.Configurations
{
    internal class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasKey(ca => new { ca.CustomerId, ca.AccountNumber });
            builder.Property(ca => ca.OwnerShipStartDate).IsRequired();
            builder.Property(ca => ca.OwnerShipType).IsRequired().HasConversion<string>();
            builder.Property(ca => ca.AccountStatus).IsRequired();
            builder.HasOne(ca => ca.Customer).WithMany(c => c.CustomerAccounts).HasForeignKey(ca => ca.CustomerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ca => ca.Account).WithMany(a => a.CustomerAccounts).HasForeignKey(ca => ca.AccountNumber).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new CustomerAccount { AccountNumber = 1001, CustomerId = 1, OwnerShipStartDate = new DateTime(2024, 1, 10), OwnerShipType = OwnerShipType.Primary, AccountStatus = true },
                new CustomerAccount { AccountNumber = 1002, CustomerId = 3, OwnerShipStartDate = new DateTime(2024, 3, 15), OwnerShipType = OwnerShipType.Primary, AccountStatus = true },
                new CustomerAccount { AccountNumber = 1002, CustomerId = 1, OwnerShipStartDate = new DateTime(2024, 6, 1), OwnerShipType = OwnerShipType.CoHolder, AccountStatus = true },
                new CustomerAccount { AccountNumber = 1003, CustomerId = 2, OwnerShipStartDate = new DateTime(2025, 2, 1), OwnerShipType = OwnerShipType.Primary, AccountStatus = true }
                );
        }
    }
}