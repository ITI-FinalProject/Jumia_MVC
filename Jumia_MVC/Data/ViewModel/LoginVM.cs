using System.ComponentModel.DataAnnotations;

namespace Jumia_MVC.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Emaill is Requried")]
        [Display(Name = "Emaill Address")]
        public string Emaill { get; set; }
        [Required(ErrorMessage = "Password is Requried")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
