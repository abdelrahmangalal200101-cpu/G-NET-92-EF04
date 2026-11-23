using EFCore4.Enteties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore4.Configurations
{
    internal class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.FullName).IsRequired().HasMaxLength(128);
            builder.Property(m => m.Email).IsRequired().HasMaxLength(128);
            builder.HasIndex(m => m.Email).IsUnique();
            builder.Property(m => m.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(m => m.HireDate).IsRequired();
            builder.HasData(
                new Manager { Id = 1, FullName = "Ahmed Hassan", Email = "ahmed.hassan@nationalbank.com", PhoneNumber = "01001112233", HireDate = new DateTime(2020, 1, 15) },
                new Manager { Id = 2, FullName = "Mona Mahmoud", Email = "mona.mahmoud@nationalbank.com", PhoneNumber = "01004445566", HireDate = new DateTime(2021, 5, 10) }
                );
        }
    }
}
