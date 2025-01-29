using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class MovieCategoryVM
    {
        public Movie Movie { get; set; }
        public List<Category> Categories { get; set; }
        public List<Movie> Movies { get; set; }

        public MovieCategoryVM()
        {
            Movie = new Movie { Title = "Title" };
            Categories = new List<Category>();
            Movies = new List<Movie>();
        }
    }
}