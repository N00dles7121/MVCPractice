using System.ComponentModel.DataAnnotations;

namespace Models;
public class Category
{
    public int Id { get; set; }

    [MaxLength(100)]
    public required string Name { get; set; }

    [Range(1, 100)]
    public int DisplayOrder { get; set; }
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
