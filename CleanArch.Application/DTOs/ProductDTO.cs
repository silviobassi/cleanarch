﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.DTOs;

public record ProductDto
{
    public int Id { get; init; }

    [Required(ErrorMessage = "The Name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Product Name")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "The Description is required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description")]
    public string? Description { get; init; }

    [Required(ErrorMessage = "The Price is required")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Price { get; init; }

    [Required(ErrorMessage = "The Stock is required")]
    [Range(1, 9999)]
    [DisplayName("Stock")]
    public int Stock { get; init; }

    [MaxLength(250)]
    [DisplayName("Product Image")]
    public string? Image { get; init; }

    public Category? Category { get; init; }

    [DisplayName("Categories")] public int CategoryId { get; init; }
}