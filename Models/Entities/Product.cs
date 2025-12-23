using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Product Name cannot exceed 150 characters.")]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string ProductDescription { get; set; } = string.Empty;
        [Required]
        [Range(10000.0, 1000000.0, ErrorMessage = "Price must be between 10,000 and 1,000,000.")]
        public decimal ProductPrice { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Discount must be between 0% and 100%.")]
        public decimal ProductDiscount { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int ProductQuantity { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        // Foreign Key
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}