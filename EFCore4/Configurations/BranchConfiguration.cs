using EFCore4.Enteties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore4.Configurations
{
    internal class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Code);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(128);
            builder.Property(b => b.Address).IsRequired().HasMaxLength(128);
            builder.Property(b => b.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.HasOne(b => b.Manager).WithOne(m => m.Branch).HasForeignKey<Branch>(b => b.ManagerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(b => b.ManagerId).IsUnique();
        }
    }
}
