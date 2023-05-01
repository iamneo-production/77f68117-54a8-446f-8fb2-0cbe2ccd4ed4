using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class UserModel
    {


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }

        public string UserName { get; set; }

        public string MobileNumber { get; set; }

        [Required(ErrorMessage ="Role is required")]
        public string UserRole { get; set; }

    }
}
