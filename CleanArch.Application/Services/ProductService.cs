using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using MediatR;

namespace CleanArch.Application.Services;

public class ProductService(IMapper mapper, IMediator mediator) : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var productsQuery = new GetProductsQuery();
        var product = await mediator.Send(productsQuery);
        return mapper.Map<IEnumerable<ProductDto>>(product);
    }

    public async Task<ProductDto> GetProductCategoryAsync(int? id)
    {
        HasId(id);
        var productCategoryByIdQuery = new GetProductCategoryByIdQuery() { Id = id.Value };
        var product = await mediator.Send(productCategoryByIdQuery);
        return mapper.Map<ProductDto>(product);
    }
    
    public async Task<ProductDto> GetByIdAsync(int? id)
    {
        HasId(id);
        var productQueryByIdQuery = new GetProductByIdQuery() { Id = id.Value };
        var product = await mediator.Send(productQueryByIdQuery);
        return mapper.Map<ProductDto>(product);
    }

    public async Task AddAsync(ProductDto productDto)
    {
        var productCreateCommand = mapper.Map<ProductCreateCommand>(productDto);
        await mediator.Send(productCreateCommand);
    }

    public async Task UpdateAsync(ProductDto productDto)
    {
        var productUpdateCommand = mapper.Map<ProductUpdateCommand>(productDto);
        await mediator.Send(productUpdateCommand);
    }

    public async Task RemoveAsync(int? id)
    {
        HasId(id);
        var productGetByIdQuery = new GetProductByIdQuery() { Id = id.Value };
        var product = await mediator.Send(productGetByIdQuery);
        if (product == null)
            throw new Exception("Product not found");
        var productRemoveCommand = new ProductRemoveCommand() { Id = product.Id };
        await mediator.Send(productRemoveCommand);
    }

    private static void HasId(int? id) => _ = id ?? throw new ArgumentNullException(nameof(id));
    
}