using Models.DTOs;

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

        public MovieDTO ToDto()
        {
            MovieDTO dto = new MovieDTO
            {
                Title = Title,
                ReleaseDate = ReleaseDate,
                Rating = Rating,
                CategoryId = CategoryId,
                Actors = Actors
            };

            return dto;
        }
    }
}
