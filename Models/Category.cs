using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPractice.Models;
public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Range(0, 100)]
    public int DisplayOrder { get; set; }
}