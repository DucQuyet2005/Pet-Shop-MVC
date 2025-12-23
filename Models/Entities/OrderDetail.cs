using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }//Gia tai thoi diem dat hang
    }
}