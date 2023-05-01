using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class AdminModel
    {
        [Required]
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string MobileNumber { get; set; }

        [Required]
        public string UserRole { get; set; }
    }
}
