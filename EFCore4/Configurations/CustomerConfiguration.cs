using EFCore4.Enteties;
using EFCore4.Enums;
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
            builder.HasData(
                new Customer { Id = 1, FullName = "Omar Khaled", NationalId = 295001234, DateOfBirth = new DateTime(1995, 1, 1), Email = "omar.khaled@gmail.com", PhoneNumber = "01112223344", Address = "Nasr City, Cairo", CustomerType = CustomerType.Individual },
                new Customer { Id = 2, FullName = "Sara Ali", NationalId = 298051678, DateOfBirth = new DateTime(1998, 5, 12), Email = "sara.ali@gmail.com", PhoneNumber = "01223334455", Address = "Smouha, Alexandria", CustomerType = CustomerType.Individual },
                new Customer { Id = 3, FullName = "Tech Solutions Co.", NationalId = 300112209, DateOfBirth = new DateTime(2015, 3, 20), Email = "info@techsolutions.com", PhoneNumber = "01098887766", Address = "Maadi, Cairo", CustomerType = CustomerType.Business }
                );
        }
    }
}
