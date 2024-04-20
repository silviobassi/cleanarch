﻿using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities;

public sealed class Product : Entity
{
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string? Image { get; private set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public Product(string? name, string? description, decimal price, int stock, string? image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        AssignProduct(name, description, price, stock, image, categoryId);
    }


    public Product(int id, string? name, string? description, decimal price, int stock, string? image,
        int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        DomainExceptionValidation.When(id < 0, "Invalid Product Id value");
        Id = id;
        AssignProduct(name, description, price, stock, image, categoryId);
    }

    public void Update(string? name, string? description, decimal price, int stock, string? image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        AssignProduct(name, description, price, stock, image, categoryId);
    }

    private static void ValidateDomain(string? name, string? description, decimal price, int stock, string? image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name?.Length < 3, "Invalid name. Name must have at least 3 characters");
        DomainExceptionValidation.When(string.IsNullOrEmpty(description),
            "Invalid description. Description is required");
        DomainExceptionValidation.When(description?.Length < 5,
            "Invalid description. Description must have at least 5 characters");
        DomainExceptionValidation.When(price < 0, "Invalid price value");
        DomainExceptionValidation.When(stock < 0, "Invalid stock value");
        DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Invalid image. Image is required");
    }

    private void AssignProduct(string? name, string? description, decimal price, int stock, string? image, int categoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
        CategoryId = categoryId;
    }
}