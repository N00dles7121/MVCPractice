using System.ComponentModel.DataAnnotations;

namespace MVCPractice.Models;

public class Film
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [MaxLength(100)]
    public string Director { get; set; } = null!;

    [MaxLength(100)]
    public int Year { get; set; }

    [Range(0, 10)]
    public double Rating { get; set; }

    public List<Actor> Actors { get; set; } = [];
}
