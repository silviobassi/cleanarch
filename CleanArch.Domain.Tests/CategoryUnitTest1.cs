using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArch.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact]
    public void CreateCategoryId_WithValidParameters_ResultObjectValidState()
    {
        var action = () => new Category(1, "Category Name");
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateCategoryId_NegativeIdValue_DomainExceptionValidation()
    {
        var action = () => new Category(-1, "Category Name");
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
    }

    [Fact]
    public void CreateCategoryId_WithNullNameValue_DomainExceptionValidation()
    {
        var action = () => new Category(1, null);
        action.Should()
            .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
    }

    [Fact]
    public void CreateCategoryId_WithShortNameValue_DomainExceptionValidation()
    {
        var action = () => new Category(1, "Ca");
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name must have at least 3 characters");
    }

    [Fact]
    public void UpdateCategoryWithoutId_WithValidParameters_ResultObjectValidState()
    {
        var category = new Category("Category Name");
        var action = () => category.Update("Category Name Updated");
        action.Should().NotThrow<DomainExceptionValidation>();
    }
    
    [Fact]
    public void UpdateCategoryWithoutId_WithNullNameValue_DomainExceptionValidation()
    {
        var category = new Category("Category Name");
        var action = () => category.Update(null);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
    }
    
    [Fact]
    public void UpdateCategoryWithoutId_WithShortNameValue_DomainExceptionValidation()
    {
        var category = new Category("Category Name");
        var action = () => category.Update("Ca");
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name must have at least 3 characters");
    }
    
    [Fact]
    public void UpdateCategory_WithValidParameters_ResultObjectValidState()
    {
        var category = new Category(1, "Category Name");
        var action = () => category.Update("Category Name Updated");
        action.Should().NotThrow<DomainExceptionValidation>();
    }
    
    [Fact]
    public void UpdateCategory_WithNullNameValue_DomainExceptionValidation()
    {
        var category = new Category(1, "Category Name");
        var action = () => category.Update(null);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
    }
    
    [Fact]
    public void UpdateCategory_WithShortNameValue_DomainExceptionValidation()
    {
        var category = new Category(1, "Category Name");
        var action = () => category.Update("Ca");
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name must have at least 3 characters");
    }
}