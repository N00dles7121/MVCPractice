using System.ComponentModel.DataAnnotations;

namespace MVCPractice.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Range(0, 100)]
    public int DisplayOrder { get; set; }

    public List<Film> Films { get; set; } = [];
}