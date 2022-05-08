using System.ComponentModel.DataAnnotations;

namespace Jumia_MVC.Data.ViewModel
{
    public class ProfileModelVM
    {
       

        public string Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Full Name")]

        public string FullName { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        public string? Address { get; internal set; }
        public string Phone { get; set; }
        public byte[]? Image { get; set; }
    }
}
