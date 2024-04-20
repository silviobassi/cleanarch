using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities;

public sealed class Category : Entity
{
    public string? Name { get; private set; }

    public ICollection<Product>? Products { get; set; }

    public Category(string? name)
    {
        ValidateDomain(name);
        AssignCategory(name);
    }

    public void Update(string? name)
    {
        ValidateDomain(name);
        AssignCategory(name);
    }

    public Category(int id, string? name)
    {
        ValidateDomain(name);
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        base.Id = id;
        AssignCategory(name);
    }

    private static void ValidateDomain(string? name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name?.Length < 3, "Invalid name. Name must have at least 3 characters");
    }

    private void AssignCategory(string? name)
    {
        Name = name;
    }
}