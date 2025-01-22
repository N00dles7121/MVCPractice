using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;

namespace MVCPractice.Data.Data
{
    public class ProgramContext : DbContext
    {
        public ProgramContext(DbContextOptions<ProgramContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                    .HasMany(f => f.Actors)
                    .WithMany(a => a.Films)
                    .UsingEntity("FilmActor");


            // Seed data for the Category table
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "SciFi",
                    DisplayOrder = 1
                },
                new Category
                {
                    Id = 2,
                    Name = "Fantasy",
                    DisplayOrder = 2
                },
                new Category
                {
                    Id = 3,
                    Name = "Historical",
                    DisplayOrder = 3
                }
            );

            // Seed data for the Film table
            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 1,
                    Title = "The Matrix",
                    Director = "The Wachowskis",
                    Year = 1999,
                    Rating = 8.7
                },
                new Film
                {
                    Id = 2,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Director = "Peter Jackson",
                    Year = 2001,
                    Rating = 8.8
                },
                new Film
                {
                    Id = 3,
                    Title = "Braveheart",
                    Director = "Mel Gibson",
                    Year = 1995,
                    Rating = 8.3
                },
                new Film
                {
                    Id = 4,
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Year = 1994,
                    Rating = 9.3
                },
                new Film
                {
                    Id = 5,
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    Year = 1972,
                    Rating = 9.2
                },
                new Film
                {
                    Id = 6,
                    Title = "The Dark Knight",
                    Director = "Christopher Nolan",
                    Year = 2008,
                    Rating = 9.0
                }
            );

            // Seed data for the Actor table
            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    Id = 1,
                    Name = "Keanu Reeves",
                    DateOfBirth = new DateOnly(1964, 9, 2),
                    CountryOfBirth = "Lebanon"
                },
                new Actor
                {
                    Id = 2,
                    Name = "Hugo Weaving",
                    DateOfBirth = new DateOnly(1960, 4, 4),
                    CountryOfBirth = "Nigeria"
                },
                new Actor
                {
                    Id = 3,
                    Name = "Carrie-Anne Moss",
                    DateOfBirth = new DateOnly(1967, 8, 21),
                    CountryOfBirth = "Canada"
                },
                new Actor
                {
                    Id = 4,
                    Name = "Elijah Wood",
                    DateOfBirth = new DateOnly(1981, 1, 28),
                    CountryOfBirth = "USA"
                },
                new Actor
                {
                    Id = 5,
                    Name = "Ian McKellen",
                    DateOfBirth = new DateOnly(1939, 5, 25),
                    CountryOfBirth = "England"
                },
                new Actor
                {
                    Id = 6,
                    Name = "Mel Gibson",
                    DateOfBirth = new DateOnly(1956, 1, 3),
                    CountryOfBirth = "USA"
                },
                new Actor
                {
                    Id = 7,
                    Name = "Tim Robbins",
                    DateOfBirth = new DateOnly(1958, 10, 16),
                    CountryOfBirth = "USA"
                },
                new Actor
                {
                    Id = 8,
                    Name = "Morgan Freeman",
                    DateOfBirth = new DateOnly(1937, 6, 1),
                    CountryOfBirth = "USA"
                },
                new Actor
                {
                    Id = 9,
                    Name = "Marlon Brando",
                    DateOfBirth = new DateOnly(1924, 4, 3),
                    CountryOfBirth = "USA"
                },
                new Actor
                {
                    Id = 10,
                    Name = "Christian Bale",
                    DateOfBirth = new DateOnly(1974, 1, 30),
                    CountryOfBirth = "Wales"
                }
            );
        }
    }
}