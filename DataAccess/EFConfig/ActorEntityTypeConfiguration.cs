using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.EFConfig;

public class ActorEntityTypeConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Actor> builder)
    {
        builder.Property(e => e.FullName).IsRequired().HasMaxLength(100);
        builder.HasMany(e => e.Movies).WithMany(e => e.Actors);
        builder.Property(e => e.CounryOfBirth).HasMaxLength(100);
    }
}
