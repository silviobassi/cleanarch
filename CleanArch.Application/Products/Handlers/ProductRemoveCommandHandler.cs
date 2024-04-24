using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers;

public class ProductRemoveCommandHandler(IProductRepository productRepository)
    : IRequestHandler<ProductRemoveCommand, Product>
{
    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new ApplicationException("Entity could not be found");
        }

        return await productRepository.RemoveAsync(product);
    }
}