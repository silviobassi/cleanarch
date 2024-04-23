using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs;

public record CategoryDto
{
    public int Id { get; init; }

    [Required(ErrorMessage = "The Name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string? Name { get; init; }
}