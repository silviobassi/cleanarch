using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries;

public class GetProductCategoryByIdQuery : IRequest<Product>
{
    public int Id { get; set; }
}