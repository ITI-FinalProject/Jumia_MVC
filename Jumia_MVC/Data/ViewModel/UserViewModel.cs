using System.ComponentModel.DataAnnotations;

namespace FinalProject.MVC.Data.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        

        public string UserName { get; set; }
        public string Emaill { get; set; }
        public string Address { get; set; }

        public IFormFile File { get; set; }

        public IEnumerable<String> Roles { get; set; }
    }
}
