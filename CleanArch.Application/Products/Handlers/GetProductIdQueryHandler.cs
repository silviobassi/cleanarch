using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers;

public class GetProductIdQueryHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            throw new ApplicationException("Entity could not be found");
        }

        return product;
    }
}