using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPractice.Models;

public class Actor
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    [MaxLength(100)]
    public string CountryOfBirth { get; set; }

    public List<Film> Films { get; set; } = [];
}