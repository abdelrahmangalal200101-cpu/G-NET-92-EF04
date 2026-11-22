using EFCore4.Enteties;
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
        }
    }
}
