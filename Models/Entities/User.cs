using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PetShop.Models.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
        public String FullName { get; set; } = String.Empty;
        [Required]
        [MaxLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public String Address { get; set; } = String.Empty;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}