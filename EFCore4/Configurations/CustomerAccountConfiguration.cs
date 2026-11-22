using EFCore4.Enteties;
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
        }
    }
}