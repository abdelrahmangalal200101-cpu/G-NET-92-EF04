using EFCore4.Enteties;
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
        }
    }
}