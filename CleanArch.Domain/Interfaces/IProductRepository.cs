﻿using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetByIdAsyncAsync(int? id);
    Task<Product> GetProductCategoryAsync(int? id);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> RemoveAsync(Product product);
}