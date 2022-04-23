using System.ComponentModel.DataAnnotations;

namespace Jumia_MVC.Models
{
    public class ContactUs
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Name")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Name Should be min 5 and max 20 length")] 
           public string Name { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide your Email")]
            [EmailAddress (ErrorMessage = "Ex...@cdf.com")]
        public string Email { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Subject")]
            public string Subject { get; set; }
            [Required]
            public string Message { get; set; }
        }
    }
