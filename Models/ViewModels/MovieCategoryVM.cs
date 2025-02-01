using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.DTOs;

namespace Models.ViewModels
{
    public class MovieCategoryVM
    {
        public MovieDTO Movie { get; set; }
        public List<Category> Categories { get; set; }
        public List<Movie> Movies { get; set; }

        public MovieCategoryVM()
        {
            Movie = new MovieDTO { Title = "Title" };
            Categories = new List<Category>();
            Movies = new List<Movie>();
        }
    }
}