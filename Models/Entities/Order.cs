using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than zero")]
        public decimal TotalAmount { get; set; }
        [Required]
        public string Status { get; set; } = "Pending";//Pending:Chua giai quyet,Shipping:Dang giao,Delivered:Da giao,Cancelled:Da huy
        [Required]
        [MaxLength(50, ErrorMessage = "Payment meothod can not get over 50 characters")]
        public String PaymentMethod { get; set; } = "Cash On Delivery";//CashOnDelivery,OnlinePayment
        [Required]
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}