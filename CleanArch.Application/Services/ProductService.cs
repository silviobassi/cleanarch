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
        HasEntity(productsQuery);
        var product = await mediator.Send(productsQuery);
        return mapper.Map<IEnumerable<ProductDto>>(product);
    }

    public async Task<ProductDto> GetByIdAsync(int? id)
    {
        var productQueryByIdQuery = new GetProductByIdQuery() { Id = HasId(id) };
        HasEntity(productQueryByIdQuery);
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
        var productRemoveCommand = new ProductRemoveCommand() { Id = HasId(id) };
        HasEntity(productRemoveCommand);
        await mediator.Send(productRemoveCommand);
    }

    private static void HasEntity<T>(T commandOrQuery)
    {
        if (commandOrQuery == null)
            throw new Exception("Entity could not be loaded.");
    }

    private static int HasId(int? id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));
        return id.Value;
    }
}