using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class MovieDTO
    {
        public required string Title { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public decimal? Rating { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<Actor> Actors { get; set; } = new List<Actor>();

        public void ToModel(Movie movie)
        {
            movie.Title = Title;
            movie.ReleaseDate = ReleaseDate;
            movie.Rating = Rating;
            movie.CategoryId = CategoryId;
            movie.Actors = Actors;
        }

        public Movie ToModel()
        {
            Movie movie = new Movie
            {
                Title = Title,
                ReleaseDate = ReleaseDate,
                Rating = Rating,
                CategoryId = CategoryId,
                Actors = Actors
            };

            return movie;
        }
    }
}