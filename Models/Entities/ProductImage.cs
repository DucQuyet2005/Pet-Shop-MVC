using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models.Entities
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "Image URL cannot exceed 300 characters.")]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        public bool IsPrimary { get; set; }
        // Foreign Key
        [Required]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
    }
}