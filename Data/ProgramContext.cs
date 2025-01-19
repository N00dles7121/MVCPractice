using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCPractice.Models;

namespace MVCPractice.Data
{
    public class ProgramContext : DbContext
    {
        public ProgramContext(DbContextOptions<ProgramContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}