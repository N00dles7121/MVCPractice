using System.ComponentModel.DataAnnotations;
using Models;

namespace MVCPractice.Models;
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public List<Movie> Movies { get; set; }


    // Get rid of nullable reference types warning
    public Category(string name, int displayOrder, List<Movie> movies)
    {
        Name = name;
        DisplayOrder = displayOrder;
        Movies = movies;
    }
}