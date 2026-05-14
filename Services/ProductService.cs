using PetShop.Models.Entities;
using PetShop.Repositories.Interfaces;
using PetShop.Services;

namespace PetShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task CreateProductAsync(Product product)
        {
            // Business logic: e.g., validate stock, set default values
            if (product.ProductQuantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (!await _productRepository.ExistsAsync(product.ProductId))
                throw new KeyNotFoundException("Product not found.");
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            if (!await _productRepository.ExistsAsync(id))
                throw new KeyNotFoundException("Product not found.");
            await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _productRepository.GetByCategoryAsync(categoryId);
        }

        public async Task<bool> ProductExistsAsync(int id)
        {
            return await _productRepository.ExistsAsync(id);
        }
    }
}