using EFCore4.Enteties;
using EFCore4.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore4.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountNumber);
            builder.Property(a => a.CurrentBalance).IsRequired().HasPrecision(18, 2);
            builder.Property(a => a.AccountType).IsRequired().HasConversion<string>();
            builder.Property(a => a.OpeningDate).IsRequired();
            builder.HasOne(a => a.Branch).WithMany(b => b.Accounts).HasForeignKey(a => a.BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new Account { AccountNumber = 1001, CurrentBalance = 50000.00m, AccountType = AccountType.Savings, OpeningDate = new DateTime(2024, 1, 10), BranchId = 1 },
                new Account { AccountNumber = 1002, CurrentBalance = 120000.00m, AccountType = AccountType.Checking, OpeningDate = new DateTime(2024, 3, 15), BranchId = 1 },
                new Account { AccountNumber = 1003, CurrentBalance = 25000.00m, AccountType = AccountType.Savings, OpeningDate = new DateTime(2025, 2, 1), BranchId = 2 }
                );
        }
    }
}
