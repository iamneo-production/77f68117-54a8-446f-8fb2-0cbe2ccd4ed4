using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class AdminModel
    {
        [Required]
        [Key]
<<<<<<< HEAD
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string MobileNumber { get; set; }

        [Required]
        public string UserRole { get; set; }
=======
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? MobileNumber { get; set; }

        [Required]
        public string? UserRole { get; set; }
>>>>>>> ce8665c87d36bb2bf5997e3d7212fca6efe7b14a
    }
}
