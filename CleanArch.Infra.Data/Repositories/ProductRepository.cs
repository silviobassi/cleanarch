using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories;

public class ProductRepository(ApiDbContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int? id)
    {
        return await context.Products.Include(p => p.Category)
            .SingleOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<Product> CreateAsync(Product product)
    {
        context.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        context.Update(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> RemoveAsync(Product product)
    {
        context.Remove(product);
        await context.SaveChangesAsync();
        return product;
    }
}