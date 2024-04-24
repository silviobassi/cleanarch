using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers;

public class ProductUpdateCommandHandler(IProductRepository productRepository)
    : IRequestHandler<ProductUpdateCommand, Product>
{
    public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new ApplicationException("Entity could not be found");
        }

        product.Update(
            request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
        return await productRepository.UpdateAsync(product);
    }
}