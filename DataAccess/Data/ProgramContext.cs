using Microsoft.EntityFrameworkCore;
using Models;

namespace MVCPractice.DataAccess.Data;
public class ProgramContext : DbContext
{
    public ProgramContext(DbContextOptions<ProgramContext> options) : base(options) { }

    public DbSet<Category> Categories { get; init; }
    public DbSet<Movie> Movies { get; init; }
    public DbSet<Actor> Actors { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProgramContext).Assembly);
    }
}