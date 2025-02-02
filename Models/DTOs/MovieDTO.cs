using System.Linq.Expressions;

namespace Models.DTOs
{
    public class MovieDTO : DTO<Movie>
    {
        public required string Title { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public decimal? Rating { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<Actor> Actors { get; set; } = new List<Actor>();

        public static MovieDTO FromModel(Movie model)
        {
            return new MovieDTO
            {
                Title = model.Title,
                ReleaseDate = model.ReleaseDate,
                Rating = model.Rating,
                CategoryId = model.CategoryId,
                Actors = model.Actors
            };
        }

        public override void ToModel(Movie movie)
        {
            movie.Title = Title;
            movie.ReleaseDate = ReleaseDate;
            movie.Rating = Rating;
            movie.CategoryId = CategoryId;
            movie.Actors = Actors;
        }

        public override Movie ToModel()
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

        public static Expression<Func<Movie, DTO<Movie>>> ToDto = (model) => new MovieDTO
        {
            Title = model.Title,
            ReleaseDate = model.ReleaseDate,
            Rating = model.Rating,
            CategoryId = model.CategoryId,
            Actors = model.Actors
        };
    }
}