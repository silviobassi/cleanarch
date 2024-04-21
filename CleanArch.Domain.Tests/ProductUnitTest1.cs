using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArch.Domain.Tests;

public class ProductUnitTest1
{
    [Fact]
    public void CreateProductId_WithValidParameters_ResultObjectValidState()
    {
        var action = () => new Product(
            1, "Product Name", "Product Description", 100, 10,
            "product-image.png", 1);
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProductId_NegativeIdValue_DomainExceptionValidation()
    {
        var action = () => new Product(
            -1, "Product Name", "Product Description", 100, 10,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Product Id value");
    }

    [Fact]
    public void CreateProductId_WithNullNameValue_DomainExceptionValidation()
    {
        var action = () => new Product(
            1, null, "Product Description", 100, 10,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
    }

    [Fact]
    public void CreateProductId_WithShortNameValue_DomainExceptionValidation()
    {
        var action = () => new Product(
            1, "Pr", "Product Description", 100, 10,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name must have at least 3 characters");
    }

    [Fact]
    public void CreateProductId_WithNullDescriptionValue_DomainExceptionValidation()
    {
        var action = () => new Product(
            1, "Product Name", null, 100, 10,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description. Description is required");
    }

    [Fact]
    public void CreateProductId_WithShortDescriptionValue_DomainExceptionValidation()
    {
        var action = () => new Product(
            1, "Product Name", "Prod", 100, 10,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description. Description must have at least 5 characters");
    }

    [Fact]
    public void CreateProductId_WithNegativePriceValue_DomainExceptionValidation()
    {
        var action = () => new Product(
            1, "Product Name", "Product Description", -1, 10,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
    }

    [Fact]
    public void CreateProductId_WithNegativeStockValue_DomainExceptionValidation()
    {
        var action = () => new Product(
            1, "Product Name", "Product Description", 100, -1,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value");
    }
    
    [Fact]
    public void CreateProductId_WithLongImageValue_DomainExceptionValidation()
    {
        var action = () => new Product(
            1, "Product Name", "Product Description", 100, 5,
            "product-imagemfsfmsalçfjasçfjasçlgjasçgjçlagjaçlsgjaçlsgjasçljgçlajgçlajgçlajgçlajgçlajgçldjçlgjçdlgjdçlgjçldgjçldgjçldjgçldjdgçldjgçldjgçldjgçldsjgçldjgçlGJÇLSDGJÇLSDGJSDÇLGJÇLgjdçlsgjçlsdjgçljgçljçljgçljçljçlgJGÇLJçgdljgçlJSGÇLJGSÇLjgçlgjdçlgdjÇLGJ.png",
            1);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image name. Image must have at most 250 characters");
    }

    [Fact]
    public void CreateProductWithoutId_WithValidParameters_ResultObjectValidState()
    {
        var action = () => new Product("Product Name", "Product Description", 100, 10,
            "product-image.png", 1);
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProductWithoutId_WithNullNameValue_DomainExceptionValidation()
    {
        var action = () => new Product(null, "Product Description", 100, 10,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
    }

    [Fact]
    public void CreateProductWithoutId_WithShortNameValue_DomainExceptionValidation()
    {
        var action = () => new Product("Pr", "Product Description", 100, 10,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name must have at least 3 characters");
    }

    [Fact]
    public void CreateProductWithoutId_WithNullDescriptionValue_DomainExceptionValidation()
    {
        var action = () => new Product("Product Name", null, 100, 10,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description. Description is required");
    }

    [Fact]
    public void CreateProductWithoutId_WithShortDescriptionValue_DomainExceptionValidation()
    {
        var action = () => new Product("Product Name", "Prod", 100, 10,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description. Description must have at least 5 characters");
    }

    [Fact]
    public void CreateProductWithoutId_WithNegativePriceValue_DomainExceptionValidation()
    {
        var action = () => new Product("Product Name", "Product Description", -1, 10,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
    }

    [Fact]
    public void CreateProductWithoutId_WithNegativeStockValue_DomainExceptionValidation()
    {
        var action = () => new Product("Product Name", "Product Description", 100, -1,
            "product-image.png", 1);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value");
    }
    
    [Fact]
    public void UpdateProduct_WithValidParameters_ResultObjectValidState()
    {
        var product = new Product("Product Name", "Product Description", 100, 10,
            "product-image.png", 1);
        var action = () => product.Update("Product Name Updated", "Product Description Updated", 200, 20,
            "product-image-updated.png", 2);
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void UpdateProduct_WithNullNameValue_DomainExceptionValidation()
    {
        var product = new Product("Product Name", "Product Description", 100, 10,
            "product-image.png", 1);
        var action = () => product.Update(null, "Product Description Updated", 200, 20,
            "product-image-updated.png", 2);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
    }

    [Fact]
    public void UpdateProduct_WithShortNameValue_DomainExceptionValidation()
    {
        var product = new Product("Product Name", "Product Description", 100, 10,
            "product-image.png", 1);
        var action = () => product.Update("Pr", "Product Description Updated", 200, 20,
            "product-image-updated.png", 2);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name must have at least 3 characters");
    }

    [Fact]
    public void UpdateProduct_WithNullDescriptionValue_DomainExceptionValidation()
    {
        var product = new Product("Product Name", "Product Description", 100, 10,
            "product-image.png", 1);
        var action = () => product.Update("Product Name Updated", null, 200, 20,
            "product-image-updated.png", 2);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description. Description is required");
    }

    [Fact]
    public void UpdateProduct_WithShortDescriptionValue_DomainExceptionValidation()
    {
        var product = new Product("Product Name", "Product Description", 100, 10,
            "product-image.png", 1);
        var action = () => product.Update("Product Name Updated", "Prod", 200, 20,
            "product-image-updated.png", 2);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description. Description must have at least 5 characters");
    }

    [Fact]
    public void UpdateProduct_WithNegativePriceValue_DomainExceptionValidation()
    {
        var product = new Product("Product Name", "Product Description", 100, 10,
            "product-image.png", 1);
        var action = () => product.Update("Product Name Updated", "Product Description Updated", -1, 20,
            "product-image-updated.png", 2);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
    }

    [Fact]
    public void UpdateProduct_WithNegativeStockValue_DomainExceptionValidation()
    {
        var product = new Product("Product Name", "Product Description", 100, 10,
            "product-image.png", 1);
        var action = () => product.Update("Product Name Updated", "Product Description Updated", 200, -1,
            "product-image-updated.png", 2);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value");
    }
    
    [Fact]
    public void CreateProductWithoutId_WithLongImageValue_DomainExceptionValidation()
    {
        var action = () => new Product(
             "Product Name", "Product Description", 100, 5,
            "product-imagemfsfmsalçfjasçfjasçlgjasçgjçlagjaçlsgjaçlsgjasçljgçlajgçlajgçlajgçlajgçlajgçldjçlgjçdlgjdçlgjçldgjçldgjçldjgçldjdgçldjgçldjgçldjgçldsjgçldjgçlGJÇLSDGJÇLSDGJSDÇLGJÇLgjdçlsgjçlsdjgçljgçljçljgçljçljçlgJGÇLJçgdljgçlJSGÇLJGSÇLjgçlgjdçlgdjÇLGJ.png",
            1);
        action.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image name. Image must have at most 250 characters");
    }
}