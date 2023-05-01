using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Login
    {
        [Required]
<<<<<<< HEAD
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
=======
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
>>>>>>> ce8665c87d36bb2bf5997e3d7212fca6efe7b14a


    }
}
