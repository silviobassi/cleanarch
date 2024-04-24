using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers;

public class ProductCreateCommandHandler(IProductRepository productRepository)
    : IRequestHandler<ProductCreateCommand, Product>
{
    public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        Product product = new(request.Name, request.Description, request.Price, request.Stock, request.Image);
        if(product == null)
        {
            throw new ApplicationException("Error creating entity");
        }
        product.CategoryId = request.CategoryId;
        return await productRepository.CreateAsync(product);
    }
}