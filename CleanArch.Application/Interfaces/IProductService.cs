using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<ProductDto> GetProductCategoryAsync(int? id);
    Task<ProductDto> GetByIdAsync(int? id);
    Task AddAsync(ProductDto productDto);
    Task UpdateAsync(ProductDto productDto);
    Task RemoveAsync(int? id);
}