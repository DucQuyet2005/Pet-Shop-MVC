using PetShop.Models.Entities;
using PetShop.Repositories.Interfaces;
using PetShop.Services;

namespace PetShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task CreateCategoryAsync(Category category)
        {
            // Business logic: e.g., check for duplicate names
            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            if (!await _categoryRepository.ExistsAsync(category.CategoryId))
                throw new KeyNotFoundException("Category not found.");
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            if (!await _categoryRepository.ExistsAsync(id))
                throw new KeyNotFoundException("Category not found.");
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await _categoryRepository.ExistsAsync(id);
        }
    }
}