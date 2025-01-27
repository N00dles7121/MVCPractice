using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.EFConfig;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
    {
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.HasMany(e => e.Movies).WithOne(e => e.Category).HasForeignKey(e => e.CategoryId);
    }
}
