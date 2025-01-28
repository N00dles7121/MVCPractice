using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class MovieCategoryVM
    {
        public Movie? Movie { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}