using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services;

public class ProductService(IMapper mapper, IProductRepository productRepository) : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var product = await productRepository.GetProductsAsync();
        return mapper.Map<IEnumerable<ProductDto>>(product);
    }

    public async Task<ProductDto> GetProductCategoryAsync(int? id)
    {
        var product = await productRepository.GetProductCategoryAsync(id);
        return mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> GetByIdAsync(int? id)
    {
        var product = await productRepository.GetByIdAsync(id);
        return mapper.Map<ProductDto>(product);
    }

    public async Task AddAsync(ProductDto productDto)
    {
        var product = mapper.Map<Product>(productDto);
        await productRepository.CreateAsync(product);
    }

    public async Task UpdateAsync(ProductDto productDto)
    {
        var product = mapper.Map<Product>(productDto);
        await productRepository.UpdateAsync(product);
    }

    public async Task RemoveAsync(int? id)
    {
        var product = productRepository.GetByIdAsync(id).Result;
        if (product == null)
            throw new Exception("Product not found");
        await productRepository.RemoveAsync(product);
    }
}