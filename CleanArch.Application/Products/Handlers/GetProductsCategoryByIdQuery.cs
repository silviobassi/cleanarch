using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers;

public class GetProductsCategoryByIdQuery(IProductRepository productRepository)
    : IRequestHandler<GetProductCategoryByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductCategoryAsync(request.Id);
        if (product == null)
        {
            throw new ApplicationException("Entity could not be found");
        }

        return product;
    }
}