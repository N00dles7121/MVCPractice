using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? CounryOfBirth { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public List<Movie> Movies { get; set; }


        // Get rid of nullable reference types warning
        public Actor(string fullName, string counryOfBirth, List<Movie> movies)
        {
            FullName = fullName;
            CounryOfBirth = counryOfBirth;
            Movies = movies;
        }
    }
}