
using System.ComponentModel.DataAnnotations;

namespace Jumia_MVC.Models.Account
{
    public class UserProfileModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Full Name is requried")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is requried")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    
        [Display(Name = "Address")]
        public string Address { get; set; }
        public byte[]? ImageProfle { get; set; }
    }
}
