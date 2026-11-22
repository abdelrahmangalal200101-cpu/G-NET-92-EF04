using EFCore4.Enteties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore4.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FullName).IsRequired().HasMaxLength(128);
            builder.Property(c => c.NationalId).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.NationalId).IsUnique();
            builder.Property(c => c.DateOfBirth).IsRequired();
            builder.Property(c => c.Email).IsRequired().HasMaxLength(128);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(200);
            builder.Property(c => c.CustomerType).IsRequired().HasConversion<string>();
        }
    }
}
