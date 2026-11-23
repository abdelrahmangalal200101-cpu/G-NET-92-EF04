using EFCore4.Enteties;
using EFCore4.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore4.Configurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.TransactionNumber);
            builder.Property(t => t.TransactionDate).IsRequired();
            builder.Property(t => t.Amount).IsRequired().HasPrecision(18, 2);
            builder.Property(t => t.TransactionType).IsRequired().HasConversion<string>();
            builder.Property(t => t.Note).HasMaxLength(250);
            builder.HasOne(t => t.Account).WithMany(a => a.Transactions).HasForeignKey(t => t.AccountNumber).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
                new Transaction { TransactionNumber = 1, TransactionDate = new DateTime(2024, 1, 10), Amount = 50000.00m, TransactionType = TransactionType.Diposite, Note = "Initial Deposit", AccountNumber = 1001 },
                new Transaction { TransactionNumber = 2, TransactionDate = new DateTime(2024, 3, 15), Amount = 150000.00m, TransactionType = TransactionType.Diposite, Note = "Company Capital", AccountNumber = 1002 },
                new Transaction { TransactionNumber = 3, TransactionDate = new DateTime(2024, 4, 2), Amount = 30000.00m, TransactionType = TransactionType.Withdraw, Note = "Equipment Purchase", AccountNumber = 1002 },
                new Transaction { TransactionNumber = 4, TransactionDate = new DateTime(2025, 2, 1), Amount = 25000.00m, TransactionType = TransactionType.Diposite, Note = "Account Opening", AccountNumber = 1003 }
                );
        }
    }
}