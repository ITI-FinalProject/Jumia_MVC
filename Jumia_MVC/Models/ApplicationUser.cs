
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Jumia_MVC.Models
{
    public class ApplicationUser: IdentityUser
    {

        [Required(ErrorMessage ="Full Name is requried")]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        public byte[]? ImageProfle { get; set; }
    }
}
