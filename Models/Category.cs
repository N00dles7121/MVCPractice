using System.ComponentModel.DataAnnotations;
using Models;

namespace MVCPractice.Models;
public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }

    [Range(1, 100)]
    public int DisplayOrder { get; set; }
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
