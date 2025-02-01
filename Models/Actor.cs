namespace Models
{
    public class Actor
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public string? CounryOfBirth { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public List<Movie> Movies { get; set; } = null!;
    }
}