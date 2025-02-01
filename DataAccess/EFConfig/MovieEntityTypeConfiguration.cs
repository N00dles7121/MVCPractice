using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.EFConfig;

public class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Movie> builder)
    {
        builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
        builder.Property(e => e.ReleaseDate).HasColumnType("date");
        builder.Property(e => e.Rating).HasColumnType("decimal(3, 1)");
        builder.HasOne(e => e.Category).WithMany(e => e.Movies).HasForeignKey(e => e.CategoryId);
        builder.HasMany(e => e.Actors).WithMany(e => e.Movies);
    }
}
