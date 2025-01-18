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
    }
}