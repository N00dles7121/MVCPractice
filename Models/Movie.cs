using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVCPractice.Models;

namespace Models
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public decimal? Rating { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Actor> Actors { get; set; } = new List<Actor>();
    }
}
