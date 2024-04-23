using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services;

public class CategoryService(IMapperBase mapper, ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await categoryRepository.GetCategoriesAsync();
        return mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetByIdAsync(int? id)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        return mapper.Map<CategoryDto>(category);
    }

    public async Task AddAsync(CategoryDto categoryDto)
    {
        var category = mapper.Map<Category>(categoryDto);
        await categoryRepository.CreateAsync(category);
    }

    public async Task UpdateAsync(CategoryDto categoryDto)
    {
        var category = mapper.Map<Category>(categoryDto);
        await categoryRepository.UpdateAsync(category);
    }

    public async Task RemoveAsync(int? id)
    {
        var category = categoryRepository.GetByIdAsync(id).Result;
        if (category == null)
            throw new Exception("Category not found");
        await categoryRepository.RemoveAsync(category);
    }
}